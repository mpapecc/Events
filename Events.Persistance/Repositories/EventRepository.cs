using Events.Application.Repositories;
using Events.Domain.Entities;

namespace Events.Persistance.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(EventsDbContext context) : base(context)
        {
        }

        public IQueryable<Event> GetAllFutureEvents()
        {
            return Query().Where(x => x.StartDateTime > DateTime.UtcNow);
        }
    }
}
