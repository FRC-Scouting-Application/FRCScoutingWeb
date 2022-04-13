

using FRCScouting_API.Models;

namespace FRCScouting_API.Services
{
    public interface ITBAService
    {

        Task<IList<Team>?> GetTeamsAsync();
        Task<IList<Team>?> GetTeamsAsync(int pageNum);
        Task<IList<Event>?> GetEventsAsync(int year);
        Task<IList<Match>?> GetMatchesAsync(string eventKey);
        Task<IList<Match>?> GetMatchesAsync(IList<Event>? events);
        Task<byte[]?> GetTeamMediaAsync(string teamKey, int year);
    }
}
