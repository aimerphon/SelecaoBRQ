using SelecaoBRQ.Infra.Crosscutting.IoC;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            Bootstrapper.RegisterServices(services);
        }
    }
}
