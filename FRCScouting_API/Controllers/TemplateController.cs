using FRCScouting_API.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Dbo;

namespace FRCScouting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IAppDataRepository _repository;

        public TemplateController(IAppDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Template>>> GetTemplates()
        {
            var templates = await _repository.GetTemplatesAsync();

            if (templates == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (templates.Count == 0)
                return NotFound();

            return Ok(templates);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddTemplates(IList<Template> templates)
        {
            if (templates == null || templates.Count == 0)
                return BadRequest();

            var sucsess = await _repository.AddTemplatesAsync(templates);
            if (!sucsess)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Created("api/Templates", templates);
        }
    }
}
