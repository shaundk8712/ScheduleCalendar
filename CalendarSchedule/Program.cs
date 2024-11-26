using CalendarSchedule.Application.Extensions;
using CalendarSchedule.Infrastructure.Repository;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationServices();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers().AddFluentValidation(v =>
{
    v.ImplicitlyValidateChildProperties = true;
    v.ImplicitlyValidateRootCollectionElements = true;
    v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddOpenApiDocument(document => {
    document.Title = "Calendar Schedule API";
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");
    var entryAssembly = typeof(Program)
               .GetTypeInfo()
               .Assembly;
    string projectVersion = entryAssembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion ?? "1.0.0";
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = entryAssembly.GetName().Name,
            Extensions = new Dictionary<string, IOpenApiExtension>
            {
                { "apiVersion", new OpenApiString(projectVersion) }
            }
        }
    );
});

builder.Services.AddDbContext<CalendarScheduleDbContext>(options =>
options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("CalendarScehduleDb"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
