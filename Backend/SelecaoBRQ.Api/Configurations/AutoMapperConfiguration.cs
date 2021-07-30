using AutoMapper;
using SelecaoBRQ.Application.AutoMapper;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var mappingConfig = AutoMapperConfig.RegisterMappings();

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
