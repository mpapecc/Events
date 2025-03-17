using Autofac;
using Events.Application.Repositories;
using Events.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Events.Persistance
{
    public class PersistanceIocModule : Module
    {
        private readonly IConfiguration configuration;

        public PersistanceIocModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<EventsDbContext>();
                optionsBuilder.UseNpgsql(this.configuration.GetConnectionString("Default"));
                return new EventsDbContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(EventRepository)).As(typeof(IEventRepository)).InstancePerLifetimeScope();
        }
    }
}
