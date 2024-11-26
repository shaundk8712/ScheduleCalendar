using CalendarSchedule.Application.Interfaces;
using CalendarSchedule.Application.Services;
using CalendarSchedule.Infrastructure.Interfaces;
using CalendarSchedule.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CalendarSchedule.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICalendarScheduleRepository, CalendarScheduleRepository>();
            return services;
        }
    }
}