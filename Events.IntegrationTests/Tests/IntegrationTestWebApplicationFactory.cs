using System.Data.Common;
using Events.Persistance;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Events.Application;
using Events.Application.Repositories;
using Microsoft.AspNetCore.TestHost;
using Xunit.Abstractions;

namespace IntegrationTests.Tests;

public class IntegrationTestWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    
    private ITestOutputHelper? _outputHelper;

    public IntegrationTestWebApplicationFactory<TProgram> WithOutput(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        return this;
    }
    
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        
        builder.UseEnvironment("Development")
            .ConfigureTestContainer<ContainerBuilder>(container =>
        {
            var existingReg = container.ComponentRegistryBuilder.
                .Registrations
                .FirstOrDefault(r => r.Activator.LimitType == typeof(EventsDbContext));
            if (existingReg != null)
            {
                container.ComponentRegistryBuilder.RemoveRegistration(existingReg);
            }
            
            container.RegisterModule(new SqliteModule());
        });
        
        // builder.ConfigureTestContainer()
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(EventsDbContext));
            services.Remove(dbContextDescriptor);

            var dbOptionsDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<EventsDbContext>));
            services.Remove(dbOptionsDescriptor);

            services.AddSingleton<DbConnection>(container =>
            {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();
                return connection;
            });

            services.AddDbContext<EventsDbContext>((container, options) =>
            {
                var connection = container.GetRequiredService<DbConnection>();
                options.UseSqlite(connection);
            });
        });

        // builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        //     .ConfigureContainer<ContainerBuilder>(containerBuilder =>
        //     {
        //         // Only register SQLite and Application modules
        //         containerBuilder.RegisterModule(new SqliteModule());
        //         containerBuilder.RegisterModule(new ApplicationIocModule());
        //     });

        builder.UseEnvironment("Development");
    }
}
