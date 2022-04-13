using FRCScouting_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FRCScouting_API.Controllers
{
    public class EventController : Controller
    {

        private readonly IAppDataRepository _repository;

        public EventController(IAppDataRepository repository)
        {
            _repository = repository;
        }
        

    }
}
