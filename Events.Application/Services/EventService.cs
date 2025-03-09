using Events.Application.Repositories;
using Events.Domain.Entities;

namespace Events.Application.Services
{
    public class EventService
    {
        private readonly IRepository<Event> eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetEvents()
        {
            return this.eventRepository.Query().ToList();
        }
    }
}
