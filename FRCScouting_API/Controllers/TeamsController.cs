using FRCScouting_API.Models;
using FRCScouting_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FRCScouting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IAppDataRepository _repository;

        public TeamsController(IAppDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Team>>> GetTeams()
        {
            var teams = await _repository.GetTeamsAsync();

            if (teams == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (teams.Count == 0)
                return NotFound();

            return Ok(teams);
        }
    }
}
