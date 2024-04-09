using SGP_SERVICIOS.Repositorios;

namespace SGP_BACKEND.Services
{
    public static class RepositorioServices
    {
        public static IServiceCollection AddRepositorios(this IServiceCollection services)
        {
            return services.AddScoped<TipoPermisoRepositorio>() 
                .AddScoped<PermisosRepositorio>();
        }
    }
}
