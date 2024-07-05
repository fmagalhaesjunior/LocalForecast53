using FluentValidation;
using LocalForecast53.Application.Interfaces;
using LocalForecast53.Application.Services;
using LocalForecast53.Core.Entities;
using LocalForecast53.Core.Interfaces;
using LocalForecast53.Core.Services;
using LocalForecast53.Core.Validators;
using LocalForecast53.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LocalForecast53.Application
{
    public static class ServicesExtension
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IForecastServiceApp, ForecastServiceApp>();
            services.AddScoped<IService<CallHistory>, DomainService<CallHistory>>();
            services.AddTransient<IValidator<CallHistory>, CallHistoryValidator>();
            services.AddScoped<IRepository<CallHistory>, Repository<CallHistory>>();
        }
    }
}
