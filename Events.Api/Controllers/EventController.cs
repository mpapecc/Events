using Events.Application.Services;
using Events.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Events.Api.Controllers
{
    public class EventController : BaseApiController
    {
        private readonly EventService eventService;

        public EventController(EventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet(nameof(GetEvents))]
        public IEnumerable<Event> GetEvents()
        {
            return this.eventService.GetEvents();
        }
    }
}
