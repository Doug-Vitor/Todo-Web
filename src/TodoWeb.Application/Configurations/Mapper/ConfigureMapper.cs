using Microsoft.Extensions.DependencyInjection;
using TodoWeb.Infrastructure.Repositories.Mapper;

namespace TodoWeb.Application.Configurations.Mapper
{
    public static class ConfigureMapper
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
