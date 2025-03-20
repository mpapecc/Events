using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace IntegrationTests.Tests;

public class AutofacWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
    {
        webHostBuilder.ConfigureTestContainer<Autofac.ContainerBuilder>(builder =>
        {
            // called after Startup.ConfigureContainer
        });
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseServiceProviderFactory(new CustomServiceProviderFactory());
        return base.CreateHost(builder);
    }
}

public class CustomServiceProviderFactory : IServiceProviderFactory<CustomContainerBuilder>
{
    public CustomContainerBuilder CreateBuilder(IServiceCollection services) => new CustomContainerBuilder(services);

    public IServiceProvider CreateServiceProvider(CustomContainerBuilder containerBuilder) =>
        new AutofacServiceProvider(containerBuilder.CustomBuild());
}

public class CustomContainerBuilder : Autofac.ContainerBuilder
{
    private readonly IServiceCollection services;

    public CustomContainerBuilder(IServiceCollection services)
    {
        this.services = services;
        this.Populate(services);
    }

    public Autofac.IContainer CustomBuild()
    {
        var sp = this.services.BuildServiceProvider();
#pragma warning disable CS0612 // Type or member is obsolete
        var filters = sp.GetRequiredService<IEnumerable<IStartupConfigureContainerFilter<Autofac.ContainerBuilder>>>();
#pragma warning restore CS0612 // Type or member is obsolete

        foreach (var filter in filters)
        {
            filter.ConfigureContainer(b => { })(this);
        }

        return this.Build();
    }
}