using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelecaoBRQ.Application.Interfaces;
using SelecaoBRQ.Application.ViewModels;
using System;
using System.Linq;

namespace SelecaoBRQ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //public abstract class SelecaoBRQControllerBase<TInterfaceAppService, TEntity> : ControllerBase where TInterfaceAppService : IUsuarioAppService<TEntity> 
    public abstract class UsuarioControllerBase : ControllerBase
    {
        private readonly IUsuarioAppService<UsuarioViewModel> _interfaceAppService;

        public UsuarioControllerBase(IUsuarioAppService<UsuarioViewModel> interfaceAppService)
        {
            _interfaceAppService = interfaceAppService;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult AdicionarUsuario([FromBody] UsuarioViewModel usuario)
        {
            try
            {
                _interfaceAppService.AdicionarUsuario(usuario);
                return Ok(new
                {
                    success = true,
                    errors = Array.Empty<string>(),
                    data = "Usuário cadastrado com Sucesso"
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao cadastrar um Usuário");
            }
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public ActionResult AlterarUsuario(int id, [FromBody] UsuarioViewModel usuario)
        {
            try
            {
                if (usuario.Id != id)
                {
                    return BadRequest($"Não foi possivel atualizar o usuário com id={id}");
                }

                _interfaceAppService.AlterarUsuario(usuario);
                return Ok(new
                {
                    success = true,
                    errors = Array.Empty<string>(),
                    data = $"Usuário com id={id} foi atualizada com sucesso"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar um Usuário");
            }
        }

        public void Dispose()
        {
            _interfaceAppService.Dispose();
            GC.SuppressFinalize(this);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public ActionResult ExcluirUsuario(int id)
        {
            try
            {
                _interfaceAppService.ExcluirUsuario(id);
                return Ok(new
                {
                    success = true,
                    errors = Array.Empty<string>(),
                    data = "Usuário excluído com Sucesso"
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar um Usuário");
            }
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult ObterTodos()
        {
            try
            {
                var usuarios = _interfaceAppService.ObterTodos().ToList();

                return Ok(new
                {
                    success = true,
                    errors = Array.Empty<string>(),
                    data = usuarios
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar lista de Usuários");
            }
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<UsuarioViewModel> ObterPorId(int id)
        {
            try
            {
                var usuario = _interfaceAppService.ObterUsuarioPorId(id);

                return Ok(new
                {
                    success = true,
                    errors = Array.Empty<string>(),
                    data = usuario
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar um Usuário");
            }
        }
    }
}
