using FRCScouting_API.Models;
using FRCScouting_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IList<Match>>> GetEvents(string event_key)
        {
            var matches = await _repository.GetMatchesAsync(event_key);

            if (matches == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (matches.Count == 0)
                return NotFound();

            return Ok(matches);
        }
    }
}
