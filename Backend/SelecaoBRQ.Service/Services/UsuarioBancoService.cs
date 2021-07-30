using SelecaoBRQ.Data.Interfaces;
using SelecaoBRQ.Service.Interfaces;

namespace SelecaoBRQ.Service.Services
{
    public class UsuarioBancoService : UsuarioService, IUsuarioBancoService
    {
        public UsuarioBancoService(IUsuarioBancoRepository usuarioRepository) : base(usuarioRepository)
        {
        }
    }
}
