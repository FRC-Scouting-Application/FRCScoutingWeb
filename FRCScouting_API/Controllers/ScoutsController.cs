using FRCScouting_API.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Dbo;

namespace FRCScouting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoutsController : ControllerBase
    {
        private readonly IAppDataRepository _repository;

        public ScoutsController(IAppDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Event/{event_key}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Scout>>> GetScoutsByEvent(string event_key)
        {
            var scouts = await _repository.GetScoutsByEventAsync(event_key);

            if (scouts == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (scouts.Count == 0)
                return NotFound();

            return Ok(scouts);
        }

        [HttpGet("Team/{team_key}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Scout>>> GetScoutsByTeam(string team_key)
        {
            var scouts = await _repository.GetScoutsByTeamAsync(team_key);

            if (scouts == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (scouts.Count == 0)
                return NotFound();

            return Ok(scouts);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddScouts(IList<Scout> scouts)
        {
            if (scouts == null || scouts.Count == 0)
                return BadRequest();

            var sucsess = await _repository.AddScoutsAsync(scouts);
            if (!sucsess)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Created("api/Scouts", scouts);
        }
    }
}
