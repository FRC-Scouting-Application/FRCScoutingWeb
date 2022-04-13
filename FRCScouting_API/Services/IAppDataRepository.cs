using FRCScouting_API.Models;

namespace FRCScouting_API.Services
{
    public interface IAppDataRepository
    {
        #region Events

        Task<IList<Event>?> GetEventsAsync();
        Task<Event?> AddCustomEventAsync(Event @event);
        Task<bool> AddEventsAsync(IList<Event> events);
        Task<bool> AddEventAsync(Event @event, bool save = true);

        #endregion
        #region Teams

        Task<IList<Team>?> GetTeamsAsync();
        Task<IList<Team>?> GetTeamsAsync(string eventKey);
        Task<bool> AddTeamsAsync(IList<Team> teams);
        Task<bool> AddTeamAsync(Team team, bool save=true);

        #endregion
        #region Matches

        Task<IList<Match>?> GetMatchesAsync(string eventKey);
        Task<bool> AddMatchesAsync(IList<Match> matches);
        Task<bool> AddMatchAsync(Match match, bool save = true);

        #endregion
        #region Templates

        Task<IList<Template>?> GetTemplatesAsync();
        Task<Template?> AddTemplateAsync(Template template);
        Task<IList<Template>?> AddTemplatesAsync(IList<Template> templates);

        #endregion
        #region Scout

        Task<IList<Scout>?> GetScoutsByEvent(string eventKey);
        Task<IList<Scout>?> GetScoutsByTeam(string teamKey);
        Task<bool> AddScoutAsync(Scout scout);
        Task<bool> AddScouts(IList<Scout> scouts);

        #endregion
        #region Notes

        Task<IList<Note>?> GetNotesByEventAsync(string eventKey);
        Task<IList<Note>?> GetNotesByTeamAsync(string teamKey);
        Task<bool> AddNoteAsync(Note note);
        Task<bool> AddNotesAsync(IList<Note> notes);

        #endregion
    }
}
