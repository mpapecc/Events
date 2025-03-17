using Autofac;
using Events.Application.Repositories;
using Events.Persistance.Repositories;

namespace Events.Persistance
{
    public class PersistanceIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(EventRepository)).As(typeof(IEventRepository)).InstancePerLifetimeScope();
        }
    }
}
