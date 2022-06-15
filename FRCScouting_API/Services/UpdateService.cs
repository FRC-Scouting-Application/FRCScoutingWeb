using FRCScouting_API.Services.Interfaces;

namespace FRCScouting_API.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly ITBAService _tbaService;
        private readonly IAppDataRepository _repository;

        public UpdateService(ITBAService tbaService, IAppDataRepository repository)
        {
            _tbaService = tbaService;
            _repository = repository;
        }

        public async Task<bool> UpdateAll()
        {
            var teams = await UpdateTeams();
            var events = await UpdateEvents();

            return teams && events;
        }

        public async Task<bool> UpdateTeams()
        {
            var teams = await _tbaService.GetTeamsAsync();
            if (teams == null || teams.Count == 0)
                return false;

            var addTeams = await _repository.AddTeamsAsync(teams);
            if (!addTeams)
                return false;

            return true;
        }

        public async Task<bool> UpdateEvents()
        {
            // Events
            var events = await _tbaService.GetEventsAsync(2022);
            if (events == null || events.Count == 0)
                return false;

            var addEvents = await _repository.AddEventsAsync(events);
            if (!addEvents)
                return false;

            // Matches
            var matches = await _tbaService.GetMatchesAsync(events);
            if (matches == null || events.Count == 0)
                return false;

            var addMatches = await _repository.AddMatchesAsync(matches);
            if (!addMatches)
                return false;

            return true;
        }

    }
}
