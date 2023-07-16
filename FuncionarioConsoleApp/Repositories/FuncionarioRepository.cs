using Dapper;
using FuncionarioConsoleApp.Entities;
using Microsoft.Data.SqlClient;

namespace ConsoleApp.Repositories
{
    public class FuncionarioRepository
    {
        private readonly string _connectionString;

        public FuncionarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Inserir(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "EXEC SP_InserirFuncionario @Nome, @Matricula, @Cpf";
                var parameters = new
                {
                    Nome = funcionario.Nome,
                    Matricula = funcionario.Matricula,
                    Cpf = funcionario.Cpf
                };

                connection.Execute(query, parameters);
            }
        }

        public void Alterar(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "EXEC SP_AlterarFuncionario @Id, @Nome, @Matricula, @Cpf";
                var parameters = new
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    Matricula = funcionario.Matricula,
                    Cpf = funcionario.Cpf
                };

                connection.Execute(query, parameters);
            }
        }

        public void Excluir(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "EXEC SP_ExcluirFuncionario @Id";
                var parameters = new { Id = id };

                connection.Execute(query, parameters);
            }
        }

        public IEnumerable<Funcionario> ConsultarTodos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Funcionario";

                return connection.Query<Funcionario>(query);
            }
        }

        public IEnumerable<Funcionario> ConsultarPorNome(string nome)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Funcionario WHERE Nome LIKE '%' + @Nome + '%'";
                var parameters = new { Nome = nome };

                return connection.Query<Funcionario>(query, parameters);
            }
        }

        public Funcionario ConsultarPorId(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM FUNCIONARIO WHERE ID = @Id";
                var parameters = new { Id = id };

                var funcionario = connection.QueryFirstOrDefault<Funcionario>(query, parameters);

                return funcionario;
            }
        }
    }
}
