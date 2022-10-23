using FRCScouting_API.Data;
using FRCScouting_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FRCScouting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;
        private readonly SeedExampleData _seedExampleData;

        public UpdateController(IUpdateService updateService, SeedExampleData seedExampleData)
        {
            _updateService = updateService;
            _seedExampleData = seedExampleData;
        }

        [HttpGet]
        [Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Update()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var success = await _updateService.UpdateAll();
            if (!success)
                return StatusCode(StatusCodes.Status500InternalServerError);

            stopwatch.Stop();

            return Ok($"Time to update: {stopwatch.ElapsedMilliseconds} ms");
        }

        [HttpGet("Seed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SeedExamples()
        {
            if (!(await _seedExampleData.SeedTemplates()))
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }
    }
}
