using Events.Application.Repositories;
using Events.Domain.Entities;

namespace Events.Application.Services
{
    public class EventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetEvents()
        {
            return this.eventRepository.GetAllFutureEvents().ToList();
        }
    }
}
