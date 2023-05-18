using DevIoBusiness.Intefaces;
using DevIoBusiness.Services;
using DevIoData.Context;
using DevIoData.Repository;

namespace DevIOApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();

            services.AddScoped<IMarcaService, MarcaService>();

            return services;
        }
    }
}
