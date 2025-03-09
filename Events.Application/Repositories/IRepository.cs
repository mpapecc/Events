using Events.Domain.Entities.BaseEntites;

namespace Events.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T? GetById(int id);
        IQueryable<T> Query();
    }
}
