using Microsoft.AspNetCore.Mvc;
using SelecaoBRQ.Application.Interfaces;

namespace SelecaoBRQ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioCacheController : UsuarioControllerBase
    {
        public UsuarioCacheController(IUsuarioCacheAppService usuarioAppService) : base(usuarioAppService)
        {
        }
    }
}
