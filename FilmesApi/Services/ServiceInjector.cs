using Microsoft.Extensions.DependencyInjection;

namespace FilmesApi.Services
{   /// <summary>
    /// Repositório para injeção de dependencia
    /// </summary>
    public static class ServiceInjector
    {   /// <summary>
        /// Container para cadastro de serviços
        /// </summary>
        /// <param name="services"></param>
        public static void ContainerServices(IServiceCollection services)
        {
            services.AddScoped<FilmeService, FilmeService>();
            services.AddScoped<CinemaService, CinemaService>();
            services.AddScoped<GerenteService, GerenteService>();
            services.AddScoped<EnderecoService, EnderecoService>();
            services.AddScoped<SessaoService, SessaoService>();

        }
    }
}
