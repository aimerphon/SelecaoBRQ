using AutoMapper;
using SelecaoBRQ.Application.ViewModels;
using SelecaoBRQ.Domain.Core.ValueObjects;
using SelecaoBRQ.Domain.Domains;
using System;

namespace SelecaoBRQ.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cpf, string>()
               .ConvertUsing(x => x.ObterCpfComMascara());

            CreateMap<Email, string>()
                .ConvertUsing(x => x.Endereco);

            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(x => x.DataNascimento,
                  opt => opt.MapFrom(src => Convert.ToDateTime(src.DataNascimento).ToShortDateString()));
        }
}
}