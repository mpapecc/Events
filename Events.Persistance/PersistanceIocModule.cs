using Autofac;
using Events.Application.Repositories;
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
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.Register(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<EventsDbContext>();
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("Default"));
                return new EventsDbContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();
        }
    }
}
