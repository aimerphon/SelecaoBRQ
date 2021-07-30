using Microsoft.AspNetCore.Mvc;
using SelecaoBRQ.Application.Interfaces;

namespace SelecaoBRQ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioBancoController : UsuarioControllerBase
    {
        public UsuarioBancoController(IUsuarioBancoAppService usuarioAppService) : base(usuarioAppService)
        {
        }
    }
}