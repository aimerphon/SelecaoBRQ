using Microsoft.Extensions.DependencyInjection;
using SelecaoBRQ.Application.AppServices;
using SelecaoBRQ.Application.Interfaces;
using SelecaoBRQ.Data.Interfaces;
using SelecaoBRQ.Data.Repository;
using SelecaoBRQ.Service.Interfaces;
using SelecaoBRQ.Service.Services;

namespace SelecaoBRQ.Infra.Crosscutting.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IUsuarioBancoAppService, UsuarioBancoAppService>();
            services.AddScoped<IUsuarioCacheAppService, UsuarioCacheAppService>();

            // Domain
            services.AddScoped<IUsuarioBancoService, UsuarioBancoService>();
            services.AddScoped<IUsuarioCacheService, UsuarioCacheService>();

            // Data
            services.AddScoped<IUsuarioBancoRepository, UsuarioBancoRepository>();
            services.AddScoped<IUsuarioCacheRepository, UsuarioCacheRepository>();
        }
    }
}
