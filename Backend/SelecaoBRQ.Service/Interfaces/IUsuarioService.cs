using SelecaoBRQ.Domain.Domains;
using System;
using System.Collections.Generic;

namespace SelecaoBRQ.Service.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        IEnumerable<Usuario> ObterTodos();

        void AdicionarUsuario(Usuario usuario);

        void ExcluirUsuario(int id);

        void AlterarUsuario(Usuario usuario);

        Usuario ObterUsuarioPorId(int id);
    }
}
