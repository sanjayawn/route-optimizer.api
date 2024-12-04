using route_optimizer.api.Services;

namespace route_optimizer.api.Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShortestPathService, ShortestPathService>();
            return services;
        }
    }
}
