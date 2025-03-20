using Events.Application.Repositories;
using Events.Domain.Entities.BaseEntites;

namespace Events.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EventsDbContext context;

        public Repository(EventsDbContext context)
        {
            this.context = context;
        }

        public virtual T? GetById(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public virtual IQueryable<T> Query()
        {
            return this.context.Set<T>();
        }
    }
}
