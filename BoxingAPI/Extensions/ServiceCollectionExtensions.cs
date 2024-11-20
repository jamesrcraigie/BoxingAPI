using BoxingAPI.Repositories;

namespace BoxingAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependancies(this IServiceCollection services)
        {
            services.AddScoped<IBoxerRepository, BoxerRepository>();
            services.AddScoped<IGymRepository, GymRepository>();
            services.AddScoped<IFightRepository, FightRepository>();
        }
    }
}
