using Microsoft.Extensions.Caching.Memory;
using SelecaoBRQ.Data.Interfaces;
using SelecaoBRQ.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelecaoBRQ.Data.Repository
{
    public class UsuarioCacheRepository : UsuarioRepository, IUsuarioCacheRepository
    {
        private readonly IMemoryCache _cache;
        private const string USUARIOS_KEY = "Usuarios";

        public UsuarioCacheRepository(IMemoryCache cache)
        {
            this._cache = cache;
        }

        private MemoryCacheEntryOptions ObterMemoryCacheEntryOptions()
        {
            return new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(120),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };
        }

        public override void Add(Usuario entity)
        {
            var usuariosCache = GetAll();

            var usuariosAttualizar = new List<Usuario>();
            usuariosAttualizar.AddRange(usuariosCache);
            usuariosAttualizar.Add(entity);

            _cache.Set(USUARIOS_KEY, usuariosAttualizar, ObterMemoryCacheEntryOptions());
        }

        public override IEnumerable<Usuario> GetAll()
        {
            if (_cache.TryGetValue(USUARIOS_KEY, out IEnumerable<Usuario> usuariosObject))
            {
                return usuariosObject;
            }
            else
            {
                return new List<Usuario>();
            }
        }

        public override Usuario GetById(params object[] ids)
        {
            var usuariosCache = GetAll();

            var usuariosAttualizar = new List<Usuario>();
            usuariosAttualizar.AddRange(usuariosCache);
            return usuariosAttualizar.FirstOrDefault(x => x.Id == Convert.ToInt32(ids[0]));
        }

        public override void Remove(int id)
        {
            var usuariosCache = GetAll();

            var usuariosAttualizar = new List<Usuario>();
            usuariosAttualizar.AddRange(usuariosCache);
            usuariosAttualizar = usuariosAttualizar.Where(x => x.Id != id).ToList();

            _cache.Set(USUARIOS_KEY, usuariosAttualizar, ObterMemoryCacheEntryOptions());
        }

        public override void Update(Usuario entity)
        {
            var usuariosCache = GetAll();

            var usuariosAttualizar = new List<Usuario>();
            usuariosAttualizar.AddRange(usuariosCache);
            var usuarioAtualizar = usuariosAttualizar.FirstOrDefault(x => x.Id == entity.Id);

            usuarioAtualizar.Nome = entity.Nome;
            usuarioAtualizar.Telefone = entity.Telefone;
            usuarioAtualizar.Sexo = entity.Sexo;
            usuarioAtualizar.CPF = entity.CPF;
            usuarioAtualizar.Email = entity.Email;
            usuarioAtualizar.DataNascimento = entity.DataNascimento;

            //_cache.Set(USUARIOS_KEY, usuariosAttualizar, ObterMemoryCacheEntryOptions());
        }
    }
}
