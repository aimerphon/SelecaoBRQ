using AutoMapper;
using SelecaoBRQ.Application.Interfaces;
using SelecaoBRQ.Application.ViewModels;
using SelecaoBRQ.Domain.Domains;
using SelecaoBRQ.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace SelecaoBRQ.Application.AppServices
{
    public abstract class UsuarioAppService : IUsuarioAppService<UsuarioViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IMapper mapper, IUsuarioService usuarioService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        public void AdicionarUsuario(UsuarioViewModel usuario)
        {
            _usuarioService.AdicionarUsuario(_mapper.Map<Usuario>(usuario));
        }

        public void AlterarUsuario(UsuarioViewModel usuario)
        {
            _usuarioService.AlterarUsuario(_mapper.Map<Usuario>(usuario));
        }

        public void Dispose()
        {
            _usuarioService.Dispose();
            GC.SuppressFinalize(this);
        }

        public void ExcluirUsuario(int id)
        {
            _usuarioService.ExcluirUsuario(id);
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioService.ObterTodos());
        }

        public UsuarioViewModel ObterUsuarioPorId(int id)
        {
            return _mapper.Map<UsuarioViewModel>(_usuarioService.ObterUsuarioPorId(id));
        }
    }
}
