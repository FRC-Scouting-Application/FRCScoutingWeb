using FRCScouting_API.Models;
using Microsoft.ApplicationInsights;

namespace FRCScouting_API.Services
{
    public class AppDataRepository : IAppDataRepository
    {
        private readonly AppDataContext _dbContext;
        private readonly TelemetryClient _telemetryClient;  

        public AppDataRepository(AppDataContext dbContext, TelemetryClient telemetryClient)
        {
            _dbContext = dbContext;
            _telemetryClient = telemetryClient;
        }

        #region Events

        public async Task<IList<Event>?> GetEventsAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                var events = _dbContext.Events.ToList();
                
                return events;
            } 
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        public Task<Event?> AddCustomEventAsync(Event @event)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddEventsAsync(IList<Event> events)
        {
            try
            {
                var eventsStack = new Stack<Event>(events);
                var existing = _dbContext.Events.ToList();

                var add = new List<Event>();
                var update = new List<Event>();

                while (eventsStack.Count > 0)
                {
                    var e = eventsStack.Pop();
                    var index = existing.IndexOf(e);

                    if (index == -1)
                    {
                        add.Add(e);
                    }
                    else
                    {
                        var match = existing[index];

                        if (match.NeedsUpdate(e))
                            update.Add(e);
                    }
                }

                await _dbContext.Events.AddRangeAsync(add);
                await _dbContext.SaveChangesAsync();

                _dbContext.Events.UpdateRange(update);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return false;
            }
        }

        public Task<bool> AddEventAsync(Event @event, bool save = true)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Teams

        public async Task<IList<Team>?> GetTeamsAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                var teams = _dbContext.Teams.ToList();

                return teams;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        public Task<IList<Team>?> GetTeamsAsync(string eventKey)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddTeamsAsync(IList<Team> teams)
        {
            try
            {
                var teamsStack = new Stack<Team>(teams);
                var existing = _dbContext.Teams.ToList();

                var add = new List<Team>();
                var update = new List<Team>();

                while (teamsStack.Count > 0)
                {
                    var team = teamsStack.Pop();
                    var index = existing.IndexOf(team);

                    if (index == -1)
                    {
                        add.Add(team);
                    }  
                    else {
                        var match = existing[index];

                        if (match.NeedsUpdate(team))
                            update.Add(team);
                    }                 
                }

                await _dbContext.Teams.AddRangeAsync(add);
                await _dbContext.SaveChangesAsync();

                _dbContext.Teams.UpdateRange(update);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return false;
            }
        }

        public async Task<bool> AddTeamAsync(Team team, bool save = true)
        {
            try
            {
                var t = _dbContext.Teams.Find(team.Key);
                if (t == null)
                    _dbContext.Teams.Add(team);
                else
                    _dbContext.Teams.Update(team);
                
                if (save)
                    await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return false;
            }
        }

        #endregion
        #region Matches

        public async Task<IList<Match>?> GetMatchesAsync(string eventKey)
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                var matches = _dbContext.Matches.Where(e => e.EventKey == eventKey).ToList();

                return matches;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        public async Task<bool> AddMatchesAsync(IList<Match> matches)
        {
            try
            {
                var matchesStack = new Stack<Match>(matches);
                var existing = _dbContext.Matches.ToList();

                var add = new List<Match>();
                var update = new List<Match>();

                while (matchesStack.Count > 0)
                {
                    var match = matchesStack.Pop();
                    var index = existing.IndexOf(match);

                    if (index == -1)
                    {
                        add.Add(match);
                    }
                    else
                    {
                        var matched = existing[index];

                        if (match.NeedsUpdate(match))
                            update.Add(match);
                    }
                }

                await _dbContext.Matches.AddRangeAsync(add);
                await _dbContext.SaveChangesAsync();

                _dbContext.Matches.UpdateRange(update);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return false;
            }
        }

        public Task<bool> AddMatchAsync(Match match, bool save = true)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Templates

        public async Task<IList<Template>?> GetTemplatesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                var templates = _dbContext.Templates.ToList();

                return templates;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }
        public Task<Template?> AddTemplateAsync(Template template)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Template>?> AddTemplatesAsync(IList<Template> templates)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Scout

        public async Task<IList<Scout>?> GetScoutsByEvent(string eventKey)
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                var scouts = _dbContext.Scouts.Where(s => s.EventKey == eventKey).ToList();

                return scouts;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        public async Task<IList<Scout>?> GetScoutsByTeam(string teamKey)
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                var scouts = _dbContext.Scouts.Where(s => s.TeamKey == teamKey).ToList();

                return scouts;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        public Task<bool> AddScoutAsync(Scout scout)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddScouts(IList<Scout> scouts)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Notes

        public async Task<IList<Note>?> GetNotesByEventAsync(string eventKey)
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                var notes = _dbContext.Notes.Where(s => s.EventKey == eventKey).ToList();

                return notes;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        public async Task<IList<Note>?> GetNotesByTeamAsync(string teamKey)
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                var notes = _dbContext.Notes.Where(s => s.TeamKey == teamKey).ToList();

                return notes;
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return null;
            }
        }

        public Task<bool> AddNoteAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddNotesAsync(IList<Note> notes)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
