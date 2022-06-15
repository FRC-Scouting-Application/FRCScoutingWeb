namespace FRCScouting_API.Services.Interfaces
{
    public interface IUpdateService
    {
        Task<bool> UpdateAll();
        Task<bool> UpdateTeams();
        Task<bool> UpdateEvents();
    }
}
