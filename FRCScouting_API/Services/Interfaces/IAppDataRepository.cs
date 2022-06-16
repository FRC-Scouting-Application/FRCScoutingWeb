using Models.Dbo;
using Models.Reports;

namespace FRCScouting_API.Services.Interfaces
{
    public interface IAppDataRepository
    {
        #region Events

        Task<IList<Event>?> GetEventsAsync();
        Task<bool> AddEventsAsync(IList<Event> events);
        DataReport.FRCDataCounts GenerateEventsDataReport();

        #endregion
        #region Teams

        Task<IList<Team>?> GetTeamsAsync();
        Task<IList<Team>?> GetTeamsAsync(string eventKey);
        Task<bool> AddTeamsAsync(IList<Team> teams);
        DataReport.FRCDataCounts GenerateTeamsDataReport();

        #endregion
        #region Matches

        Task<IList<Match>?> GetMatchesAsync(string eventKey);
        Task<bool> AddMatchesAsync(IList<Match> matches);
        DataReport.FRCDataCounts GenerateMatchesDataReport();

        #endregion
        #region Templates

        Task<IList<Template>?> GetTemplatesAsync();
        Task<bool> AddTemplatesAsync(IList<Template> templates);
        DataReport.CountPerType GenerateTemplatesDataReport();

        #endregion
        #region Scout

        Task<IList<Scout>?> GetScoutsByEventAsync(string eventKey);
        Task<IList<Scout>?> GetScoutsByTeamAsync(string teamKey);
        Task<bool> AddScoutsAsync(IList<Scout> scouts);
        DataReport.ScoutDataCounts GenerateScoutsDataReport();

        #endregion
        #region Notes

        Task<IList<Note>?> GetNotesByEventAsync(string eventKey);
        Task<IList<Note>?> GetNotesByTeamAsync(string teamKey);
        Task<bool> AddNotesAsync(IList<Note> notes);
        DataReport.ScoutDataCounts GenerateNotesDataReport();

        #endregion
    }
}
