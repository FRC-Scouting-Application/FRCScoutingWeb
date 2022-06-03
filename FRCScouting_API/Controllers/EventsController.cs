using FRCScouting_API.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Dbo;

namespace FRCScouting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {

        private readonly IAppDataRepository _repository;

        public EventsController(IAppDataRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Event>>> GetEvents()
        {
            var events = await _repository.GetEventsAsync();

            if (events == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (events.Count == 0)
                return NotFound();

            return Ok(events);
        }

        [HttpPost("Custom")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddEvents(IList<Event> events)
        {
            if (events == null || events.Count == 0)
                return BadRequest();

            foreach (var e in events)
                e.Id = null;

            var sucsess = await _repository.AddEventsAsync(events);
            if (!sucsess)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Created("api/Events", events);
        }
    }
}
