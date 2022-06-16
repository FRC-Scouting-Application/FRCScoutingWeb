using FRCScouting_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Reports;

namespace FRCScouting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportService;

        public ReportsController(IReportsService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("Data")]
        [Produces("application/json")]
        public ActionResult<DataReport> GenerateDataReport()
        {
            return _reportService.GenerateDataReport();
        }

    }
}
