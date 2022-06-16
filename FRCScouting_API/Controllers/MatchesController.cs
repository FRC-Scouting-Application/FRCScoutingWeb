using FRCScouting_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Dbo;

namespace FRCScouting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IAppDataRepository _repository;

        public MatchesController(IAppDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{event_key}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Match>>> GetMatches(string event_key)
        {
            var matches = await _repository.GetMatchesAsync(event_key);

            if (matches == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (matches.Count == 0)
                return NotFound();

            return Ok(matches);
        }

        [HttpPost("Custom")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddMatches(IList<Match> matches)
        {
            if (matches == null || matches.Count == 0)
                return BadRequest();

            foreach (var m in matches)
                m.Id = null;

            var sucsess = await _repository.AddMatchesAsync(matches);
            if (!sucsess)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Created("api/Matches", matches);
        }
    }
}
