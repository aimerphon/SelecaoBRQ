using SelecaoBRQ.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SelecaoBRQ.Application.Interfaces
{
    public interface IUsuarioAppService<TEntity> : IDisposable
    {
        IEnumerable<TEntity> ObterTodos();

        void AdicionarUsuario(TEntity usuario);

        void ExcluirUsuario(int id);

        void AlterarUsuario(TEntity usuario);

        TEntity ObterUsuarioPorId(int id);
    }
}
