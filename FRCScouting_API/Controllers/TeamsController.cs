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
        private readonly ITBAService _tbaService;

        public TeamsController(IAppDataRepository repository, ITBAService tbaService)
        {
            _repository = repository;
            _tbaService = tbaService;
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

        [HttpGet("{team_key}/media")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<byte[]>> GetTeamMedia(string team_key)
        {
            var media = await _tbaService.GetTeamMediaAsync(team_key, 2022);

            if (media == null)
                return NotFound();

            return Ok(media);
        }
    }
}
