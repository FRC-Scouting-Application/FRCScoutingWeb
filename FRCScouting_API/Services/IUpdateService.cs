namespace FRCScouting_API.Services
{
    public interface IUpdateService
    {
        Task<bool> UpdateAll();
        Task<bool> UpdateTeams();
        Task<bool> UpdateEvents();
    }
}
