using CalendarSchedule.Domain.Interfaces;
using CalendarSchedule.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CalendarSchedule.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICalendarScheduleRepository, CalendarScheduleRepository>();
            return services;
        }
    }
}