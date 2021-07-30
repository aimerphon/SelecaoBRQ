using Dapper;
using Microsoft.Extensions.Configuration;
using SelecaoBRQ.Data.Interfaces;
using SelecaoBRQ.Domain.Domains;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SelecaoBRQ.Data.Repository
{
    public class UsuarioBancoRepository : UsuarioRepository, IUsuarioBancoRepository
    {
        private readonly IConfiguration _configuration;

        public UsuarioBancoRepository(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        protected string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").
                GetSection("SelecaoBRQConnection").Value;
            return connection;
        }

        public override void Add(Usuario entity)
        {
            var connectionString = GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var query = @"INSERT INTO Usuario(Nome, CPF, Email, Telefone, Sexo, DataNascimento) VALUES(@Nome, @CPF, @Email, @Telefone, @Sexo, @DataNascimento); 
SELECT CAST(SCOPE_IDENTITY() as INT); ";
                count = con.Execute(query,
                    new
                    {
                        entity.Nome,
                        CPF = entity.CPF,
                        Email = entity.Email,
                        entity.Telefone,
                        entity.Sexo,
                        entity.DataNascimento
                    });
            }
        }

        public override IEnumerable<Usuario> GetAll()
        {
            using (SqlConnection conexao = new(GetConnection()))
            {
                var dados = conexao.Query<Usuario>(
                    "SELECT Id, Nome, CPF, Email, Telefone, Sexo, DataNascimento FROM dbo.Usuario");
                return dados;
            }
        }

        public override Usuario GetById(params object[] ids)
        {
            Usuario resultado = null;

            using (SqlConnection conexao = new(GetConnection()))
            {
                resultado = conexao.QueryFirstOrDefault<Usuario>(
                    "SELECT Id, Nome, CPF, Email, Telefone, Sexo, DataNascimento FROM dbo.Usuario " +
                    "WHERE Id = @id",
                    new { id = ids[0] });
            }

            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                return null;
            }
        }

        public override void Remove(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var query = "DELETE FROM Usuario WHERE Id = @IdUsuario";
                count = con.Execute(query, new { IdUsuario = id });
            }
        }

        public override void Update(Usuario entity)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var query = @"UPDATE Usuario SET Nome = @Nome, CPF = @CPF, Email = @Email, Telefone=@Telefone, Sexo=@Sexo, DataNascimento=@DataNascimento,  
WHERE Id = " + entity.Id;
                count = con.Execute(query, entity);
            }
        }
    }
}
