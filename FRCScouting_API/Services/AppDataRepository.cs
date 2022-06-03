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
                var eventsStack = new Stack<Event>(events);
                var existing = _dbContext.Events.ToList();

                var add = new List<Event>();
                var update = new List<Event>();

                while (eventsStack.Count > 0)
                {
                    var e = eventsStack.Pop();

                    if (e.Id == null)
                    {
                        e.Id = $"custom-{Guid.NewGuid()}";
                    }

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

                    if (team.Id == null)
                    {
                        team.Id = $"custom-{Guid.NewGuid()}";
                    }

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

                    if (match.Id == null)
                    {
                        match.Id = $"custom-{Guid.NewGuid()}";
                    }

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
                var templateStack = new Stack<Template>(templates);
                var existing = _dbContext.Templates.ToList();

                var add = new List<Template>();
                var update = new List<Template>();

                while (templateStack.Count > 0)
                {
                    var template = templateStack.Pop();

                    var index = existing.IndexOf(template);

                    if (index == -1)
                    {
                        add.Add(template);
                    }
                    else
                    {
                        var matched = existing[index];

                        if (template.NeedsUpdate(template))
                        {
                            var maxVersion = (existing.Where(t => t.Id == template.Id)).Max(t => t.Version);
                            template.Version = maxVersion + 1;

                            update.Add(template);
                        }   
                    }
                }

                await _dbContext.Templates.AddRangeAsync(add);
                await _dbContext.SaveChangesAsync();

                _dbContext.Templates.UpdateRange(update);
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
                var scoutStack = new Stack<Scout>(scouts);
                var existing = _dbContext.Scouts.ToList();

                var add = new List<Scout>();
                var update = new List<Scout>();

                while (scoutStack.Count > 0)
                {
                    var scout = scoutStack.Pop();

                    var index = existing.IndexOf(scout);

                    if (index == -1)
                    {
                        add.Add(scout);
                    }
                    else
                    {
                        var matched = existing[index];

                        if (scout.NeedsUpdate(scout))
                            update.Add(scout);
                    }
                }

                await _dbContext.Scouts.AddRangeAsync(add);
                await _dbContext.SaveChangesAsync();

                _dbContext.Scouts.UpdateRange(update);
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
                var noteStack = new Stack<Note>(notes);
                var existing = _dbContext.Notes.ToList();

                var add = new List<Note>();
                var update = new List<Note>();

                while (noteStack.Count > 0)
                {
                    var note = noteStack.Pop();

                    var index = existing.IndexOf(note);

                    if (index == -1)
                    {
                        add.Add(note);
                    }
                    else
                    {
                        var matched = existing[index];

                        if (note.NeedsUpdate(note))
                            update.Add(note);
                    }
                }

                await _dbContext.Notes.AddRangeAsync(add);
                await _dbContext.SaveChangesAsync();

                _dbContext.Notes.UpdateRange(update);
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
