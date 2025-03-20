using Events.Domain.Entities;

namespace Events.Application.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        IQueryable<Event> GetAllFutureEvents();
    }
}
