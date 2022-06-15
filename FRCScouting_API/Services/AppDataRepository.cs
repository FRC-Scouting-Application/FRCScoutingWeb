using FRCScouting_API.Helpers;
using FRCScouting_API.Services.Interfaces;
using Microsoft.ApplicationInsights;
using Models.Dbo;

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

        public async Task<bool> AddEventsAsync(IList<Event> events)
        {
            try
            {
                foreach (var item in events)
                    if (item.Id == null)
                        item.Id = $"custom-{Guid.NewGuid()}";

                EFHelper.AddUpdateRange<Event, string>(_dbContext.Events, events);

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
                foreach (var item in teams)
                    if (item.Id == null)
                        item.Id = $"custom-{Guid.NewGuid()}";

                EFHelper.AddUpdateRange<Team, string>(_dbContext.Teams, teams);

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
                foreach (var item in matches)
                    if (item.Id == null)
                        item.Id = $"custom-{Guid.NewGuid()}";

                EFHelper.AddUpdateRange<Match, string>(_dbContext.Matches, matches);

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

        public async Task<bool> AddTemplatesAsync(IList<Template> templates)
        {
            try
            {
                EFHelper.AddUpdateRange<Template, int>(_dbContext.Templates, templates);

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
        #region Scout

        public async Task<IList<Scout>?> GetScoutsByEventAsync(string eventKey)
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

        public async Task<IList<Scout>?> GetScoutsByTeamAsync(string teamKey)
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

        public async Task<bool> AddScoutsAsync(IList<Scout> scouts)
        {
            try
            {
                EFHelper.AddUpdateRange<Scout, int>(_dbContext.Scouts, scouts);

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

        public async Task<bool> AddNotesAsync(IList<Note> notes)
        {
            try
            {
                EFHelper.AddUpdateRange<Note, int>(_dbContext.Notes, notes);

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
    }
}
