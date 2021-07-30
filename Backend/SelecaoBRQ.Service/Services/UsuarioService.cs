using SelecaoBRQ.Data.Interfaces;
using SelecaoBRQ.Domain.Domains;
using SelecaoBRQ.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace SelecaoBRQ.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
        }

        public void AlterarUsuario(Usuario usuario)
        {
            _usuarioRepository.Update(usuario);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void ExcluirUsuario(int id)
        {
            _usuarioRepository.Remove(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            return _usuarioRepository.GetById(id);
        }
    }
}
