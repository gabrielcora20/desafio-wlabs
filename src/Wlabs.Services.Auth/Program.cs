using MediatR;
using System.Reflection;
using Wlabs.Services.Core.Configurations;
using Wlabs.Services.Core.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.AddSerilog(builder.Configuration, "Wlabs Api - Auth");

// AutoMapper Settings
builder.Services.AddAutoMapperConfiguration();

// Swagger Config
builder.Services.AddSwaggerConfiguration();

// Adding MediatR for Domain Events and Notifications
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

// Adding MongoDB Database configuration
builder.Services.AddMongoDbConfiguration();

// Adding Redis configuration
builder.Services.AddRedis(builder.Configuration);

builder.Services.AddAuthentication()
                .AddJwtBearer();

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.UseSwaggerSetup();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();