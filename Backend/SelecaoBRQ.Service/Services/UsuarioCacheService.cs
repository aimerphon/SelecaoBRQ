using SelecaoBRQ.Data.Interfaces;
using SelecaoBRQ.Service.Interfaces;

namespace SelecaoBRQ.Service.Services
{
    public class UsuarioCacheService : UsuarioService, IUsuarioCacheService
    {
        public UsuarioCacheService(IUsuarioCacheRepository usuarioRepository) : base(usuarioRepository)
        {
        }
    }
}
