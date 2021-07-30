using AutoMapper;
using SelecaoBRQ.Application.ViewModels;
using SelecaoBRQ.Domain.Core.ValueObjects;
using SelecaoBRQ.Domain.Domains;

namespace SelecaoBRQ.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<string, Cpf>()
               .ConvertUsing(x => new Cpf(x));

            CreateMap<string, Email>()
                .ConvertUsing(x => new Email(x));

            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}