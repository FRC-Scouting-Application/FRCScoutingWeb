using Models.Dbo;

namespace FRCScouting_API.Services
{
    public interface IAppDataRepository
    {
        #region Events

        Task<IList<Event>?> GetEventsAsync();
        Task<bool> AddEventsAsync(IList<Event> events);

        #endregion
        #region Teams

        Task<IList<Team>?> GetTeamsAsync();
        Task<IList<Team>?> GetTeamsAsync(string eventKey);
        Task<bool> AddTeamsAsync(IList<Team> teams);

        #endregion
        #region Matches

        Task<IList<Match>?> GetMatchesAsync(string eventKey);
        Task<bool> AddMatchesAsync(IList<Match> matches);

        #endregion
        #region Templates

        Task<IList<Template>?> GetTemplatesAsync();
        Task<bool> AddTemplatesAsync(IList<Template> templates);

        #endregion
        #region Scout

        Task<IList<Scout>?> GetScoutsByEventAsync(string eventKey);
        Task<IList<Scout>?> GetScoutsByTeamAsync(string teamKey);
        Task<bool> AddScoutsAsync(IList<Scout> scouts);

        #endregion
        #region Notes

        Task<IList<Note>?> GetNotesByEventAsync(string eventKey);
        Task<IList<Note>?> GetNotesByTeamAsync(string teamKey);
        Task<bool> AddNotesAsync(IList<Note> notes);

        #endregion
    }
}
