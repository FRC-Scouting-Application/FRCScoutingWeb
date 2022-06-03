using FRCScouting_API.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Dbo;

namespace FRCScouting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IAppDataRepository _repository;

        public NotesController(IAppDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Event/{event_key}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Note>>> GetNotesByEvent(string event_key)
        {
            var notes = await _repository.GetNotesByEventAsync(event_key);

            if (notes == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (notes.Count == 0)
                return NotFound();

            return Ok(notes);
        }

        [HttpGet("Team/{team_key}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Note>>> GetNotesByTeam(string team_key)
        {
            var notes = await _repository.GetNotesByTeamAsync(team_key);

            if (notes == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (notes.Count == 0)
                return NotFound();

            return Ok(notes);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddScouts(IList<Note> notes)
        {
            if (notes == null || notes.Count == 0)
                return BadRequest();

            var sucsess = await _repository.AddNotesAsync(notes);
            if (!sucsess)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Created("api/Scouts", notes);
        }
    }
}
