using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoWeb.Domain.Configurations;
using TodoWeb.Domain.Repositories;
using TodoWeb.Domain.Services;
using TodoWeb.Infrastructure.Repositories;
using TodoWeb.Infrastructure.Services;

namespace TodoWeb.Application.Configurations
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<ITodoServices, TodoServices>();

            services.Configure<ApiRoutingConfiguration>(configuration.GetSection(nameof(ApiRoutingConfiguration)));

            return services;
        }

    }
}
