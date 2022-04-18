using AutenticaçãoApi.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutenticaçãoApi.Services
{   /// <summary>
    /// Repositório para injeção de dependencia
    /// </summary>
    public static class ServiceInjector
    {   /// <summary>
        /// Container para cadastro de serviços
        /// </summary>
        /// <param name="services"></param>
        public static void ContainerService(IServiceCollection services)
        {
            services.AddScoped<CadastroService, CadastroService>();
            services.AddScoped<LoginService, LoginService>();
            //services.AddScoped<TokenService, TokenService>();
            //services.AddScoped<LogoutService, LogoutService>();
        }
    }
}
