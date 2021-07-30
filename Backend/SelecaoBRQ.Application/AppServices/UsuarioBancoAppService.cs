using AutoMapper;
using SelecaoBRQ.Application.Interfaces;
using SelecaoBRQ.Service.Interfaces;

namespace SelecaoBRQ.Application.AppServices
{
    public class UsuarioBancoAppService : UsuarioAppService, IUsuarioBancoAppService
    {

        public UsuarioBancoAppService(IMapper mapper, IUsuarioBancoService usuarioService) : base(mapper, usuarioService)
        {
        }
    }
}
