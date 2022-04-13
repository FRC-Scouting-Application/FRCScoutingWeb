using FRCScouting_API.Models;
using FRCScouting_API.Models.TBA;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SixLabors.ImageSharp;
using System.Collections.Generic;
using System.Drawing;

namespace FRCScouting_API.Services
{
    public class TBAService : ITBAService
    {
        private readonly ApiSettings _apiSettings;
        private readonly HttpClient _httpClient;
        private readonly TelemetryClient _telemetryClient;

        public TBAService(IOptions<ApiSettings> apiSettings, HttpClient httpClient, TelemetryClient telemetryClient)
        {
            _apiSettings = apiSettings.Value;
            _httpClient = httpClient;
            _telemetryClient = telemetryClient;

            _httpClient.DefaultRequestHeaders.Add("X-TBA-Auth-Key", _apiSettings.TbaApiKey!);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<IList<Event>?> GetEventsAsync(int year)
        {
            try
            {
                var serializer = new JsonSerializer();
                var response = await _httpClient.GetAsync($"{_apiSettings.TbaApiUrl}/events/{year}");

                if (!response.IsSuccessStatusCode) return null;

                var streamReader = new StreamReader(response.Content.ReadAsStream());
                var jsonReader = new JsonTextReader(streamReader);
                var tbaEvents = serializer.Deserialize<List<TBAEvent>>(jsonReader);

                if (tbaEvents == null) return null;

                List<Event> events = new();
                foreach (var tbaEvent in tbaEvents)
                {
                    events.Add(new()
                    {
                        Key = tbaEvent.Key,
                        Name = tbaEvent.Name,
                        ShortName = tbaEvent.Short_Name,
                        City = tbaEvent.City,
                        StateProv = tbaEvent.State_Prov,
                        Country = tbaEvent.Country,
                        PostalCode = tbaEvent.Postal_Code,
                        LocationName = tbaEvent.Location_Name,
                        Address = tbaEvent.Address,
                        Website = tbaEvent.Website,
                        StartDate = tbaEvent.Start_Date,
                        EndDate = tbaEvent.End_Date,
                        Year = tbaEvent.Year ?? year,
                        Week = tbaEvent.Week ?? -1, 
                        EventType = tbaEvent.Event_Type_String 
                    });
                }

                return events;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        public async Task<IList<Match>?> GetMatchesAsync(IList<Event>? events)
        {
            if (events == null) return null;

            var tasks = new List<Task<IList<Match>?>>();
            foreach (var e in events)
            {
                if (e.Key == null) continue;
                tasks.Add(GetMatchesAsync(e.Key));
            }

            await Task.WhenAll(tasks);

            List<Match> matches = new();
            foreach (var task in tasks)
                if (task.Result != null)
                    matches.AddRange(task.Result);

            return matches;
        }

        public async Task<IList<Match>?> GetMatchesAsync(string eventKey)
        {
            try
            {
                var serializer = new JsonSerializer();
                var response = await _httpClient.GetAsync($"{_apiSettings.TbaApiUrl}/event/{eventKey}/matches");

                if (!response.IsSuccessStatusCode) return null;

                var streamReader = new StreamReader(response.Content.ReadAsStream());
                var jsonReader = new JsonTextReader(streamReader);
                var tbaMatches = serializer.Deserialize<List<TBAMatch>>(jsonReader);

                if (tbaMatches == null) return null;

                List<Match> matches = new();
                foreach (var tbaMatch in tbaMatches)
                {
                    matches.Add(new()
                    {
                        Key = tbaMatch.Key,
                        MatchNumber = tbaMatch.Match_Number ?? -1,
                        EventKey = tbaMatch.Event_Key ?? eventKey,
                        Red1 = tbaMatch.Alliances?.Red?.Team_Keys?[0] ?? "",
                        Red2 = tbaMatch.Alliances?.Red?.Team_Keys?[1] ?? "",
                        Red3 = tbaMatch.Alliances?.Red?.Team_Keys?[2] ?? "",
                        Blue1 = tbaMatch.Alliances?.Blue?.Team_Keys?[0] ?? "",
                        Blue2 = tbaMatch.Alliances?.Blue?.Team_Keys?[1] ?? "",
                        Blue3 = tbaMatch.Alliances?.Blue?.Team_Keys?[2] ?? "",
                        RedScore = tbaMatch.Alliances?.Red?.Score ?? 0,
                        BlueScore = tbaMatch.Alliances?.Blue?.Score ?? 0,
                        WinningAlliance = tbaMatch.Winning_Alliance,
                        Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(tbaMatch.Time ?? 0),
                        ActualTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(tbaMatch.Actual_Time ?? 0),
                        PredictedTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(tbaMatch.Predicted_Time ?? 0)
                    });
                }

                return matches;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        public async Task<byte[]?> GetTeamMediaAsync(string teamKey, int year)
        {
            try
            {
                var serializer = new JsonSerializer();
                var response = await _httpClient.GetAsync($"{_apiSettings.TbaApiUrl}/team/{teamKey}/media/{year}");

                if (!response.IsSuccessStatusCode) return null;

                var streamReader = new StreamReader(response.Content.ReadAsStream());
                var jsonReader = new JsonTextReader(streamReader);
                var tbaMedia = serializer.Deserialize<List<TBAMedia>>(jsonReader);

                if (tbaMedia == null) return null;

                var media = tbaMedia.Where(m => m.Preferred == true).First();

                if (media == null) return null;
                if (media.Direct_Url == null) return null;

                return await DonwloadMediaAsync(media.Direct_Url);
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        private async Task<byte[]?> DonwloadMediaAsync(string mediaUrl)
        {
            var response = await _httpClient.GetAsync(mediaUrl);

            if (!response.IsSuccessStatusCode) return null;
            if (response.Content == null) return null;

            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<IList<Team>?> GetTeamsAsync()
        {
            try
            {
                List<Team> teams = new();
                for (int i = 0; i < 50; i++)
                {
                    var subList = await GetTeamsAsync(i);

                    if (subList == null) break;
                    teams.AddRange(subList);
                }
                return teams;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        public async Task<IList<Team>?> GetTeamsAsync(int pageNum)
        {
            try
            {
                var serializer = new JsonSerializer();
                var response = await _httpClient.GetAsync($"{_apiSettings.TbaApiUrl}/teams/{pageNum}");

                if (!response.IsSuccessStatusCode) return null;

                var streamReader = new StreamReader(response.Content.ReadAsStream());
                var jsonReader = new JsonTextReader(streamReader);
                var tbaTeams = serializer.Deserialize<List<TBATeam>>(jsonReader);

                if (tbaTeams == null) return null;

                List<Team> teams = new();
                foreach (var tbaTeam in tbaTeams)
                {
                    if (tbaTeam.Team_number == null || tbaTeam.Team_number == 0) continue;

                    teams.Add(new()
                    {
                        Key = tbaTeam.Key,
                        TeamNumber = tbaTeam.Team_number ?? -1,
                        Nickname = tbaTeam.Nickname,
                        Name = tbaTeam.Name,
                        City = tbaTeam.City,
                        StateProv = tbaTeam.State_Prov,
                        Country = tbaTeam.Country,
                        PostalCode = tbaTeam.Postal_Code,
                        LocationName = tbaTeam.Location_Name,
                        Address = tbaTeam.Address,
                        Website = tbaTeam.Website,
                        RookieYear = tbaTeam.Rookie_Year ?? -1
                    });
                }

                return teams;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }
    }
}
