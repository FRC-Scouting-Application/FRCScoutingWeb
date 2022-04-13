using FRCScouting_API.Models;

namespace FRCScouting_API.Services
{
    public class AppDataRepository : IAppDataRepository
    {

        #region Events

        public Task<IList<Event>> GetEventsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Event>> GetEventsAsync(string teamKey)
        {
            throw new NotImplementedException();
        }

        public Task<Event> AddCustomEventAsync(Event @event)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Event>> AddCustomEventsAsync(IList<Event> events)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Teams

        public Task<IList<Team>> GetTeamsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Team>> GetTeamsAsync(string eventKey)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Matches

        public Task<IList<Match>> GetMatchesAsync(string eventKey)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Templates

        public Task<IList<Template>> GetTemplatesAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Template> AddTemplateAsync(Template template)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Template>> AddTemplatesAsync(IList<Template> templates)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Scout

        public Task<IList<Scout>> GetScoutsByEvent(string eventKey)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Scout>> GetScoutsByTeam(string teamKey)
        {
            throw new NotImplementedException();
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

        public Task<IList<Note>> GetNotesByEventAsync(string eventKey)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Note>> GetNotesByTeamAsync(string teamKey)
        {
            throw new NotImplementedException();
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
