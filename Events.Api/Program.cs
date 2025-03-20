using Autofac;
using Autofac.Extensions.DependencyInjection;
using Events.Api.Extensions;
using Events.Application;
using Events.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.RegisterSettings(builder.Configuration);
builder.Services.RegisterIdentity();
builder.Services.RegisterAuthentication();
builder.Services.RegisterAuthorization();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(c =>
    {
        c.RegisterModule(new PersistanceIocModule(builder.Configuration));
        c.RegisterModule(new ApplicationIocModule());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
