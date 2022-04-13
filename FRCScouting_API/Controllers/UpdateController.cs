using FRCScouting_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FRCScouting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : Controller
    {
        private readonly ITBAService _tbaService;
        private readonly IAppDataRepository _repository;

        public UpdateController(ITBAService tbaService, IAppDataRepository repository)
        {
            _tbaService = tbaService;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Update()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Teams
            var teams = await _tbaService.GetTeamsAsync();
            if (teams == null || teams.Count == 0) 
                return StatusCode(StatusCodes.Status500InternalServerError);

            var addTeams = await _repository.AddTeamsAsync(teams);
            if (!addTeams)
                return StatusCode(StatusCodes.Status500InternalServerError);

            // Events
            var events = await _tbaService.GetEventsAsync(2022);
            if (events == null || events.Count == 0) 
                return StatusCode(StatusCodes.Status500InternalServerError);

            var addEvents = await _repository.AddEventsAsync(events);
            if (!addEvents)
                return StatusCode(StatusCodes.Status500InternalServerError);

            // Matches
            var matches = await _tbaService.GetMatchesAsync(events);
            if (matches == null || events.Count == 0) 
                return StatusCode(StatusCodes.Status500InternalServerError);

            var addMatches = await _repository.AddMatchesAsync(matches);
            if (!addMatches)
                return StatusCode(StatusCodes.Status500InternalServerError);

            stopwatch.Stop();

            return Ok($"Time to update: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
