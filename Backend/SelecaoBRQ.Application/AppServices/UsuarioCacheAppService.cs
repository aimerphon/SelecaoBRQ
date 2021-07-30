using AutoMapper;
using SelecaoBRQ.Application.Interfaces;
using SelecaoBRQ.Service.Interfaces;

namespace SelecaoBRQ.Application.AppServices
{
    public class UsuarioCacheAppService : UsuarioAppService, IUsuarioCacheAppService
    {
        public UsuarioCacheAppService(IMapper mapper, IUsuarioCacheService usuarioService) : base(mapper, usuarioService)
        {
        }
    }
}
