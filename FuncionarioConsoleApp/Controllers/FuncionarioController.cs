using ConsoleApp.Repositories;
using ConsoleApp.Settings;
using FuncionarioConsoleApp.Entities;

namespace ConsoleApp.Controllers
{
    public class FuncionarioController
    {

        public static void ExecutarSistema()
        {
            try
            {
                var settings = SqlServerSettings.ConnectionString();
                var repository = new FuncionarioRepository(settings);
                var controller = new FuncionarioController(repository);

                bool continuar = true;

                while (continuar)
                {

                    Console.WriteLine("Opções:");
                    Console.WriteLine("1 - Cadastrar Funcionário");
                    Console.WriteLine("2 - Consultar Todos os Funcionários");
                    Console.WriteLine("3 - Consultar Funcionários por Nome");
                    Console.WriteLine("4 - Alterar Funcionário");
                    Console.WriteLine("5 - Excluir Funcionário");
                    Console.WriteLine("0 - Sair");
                    Console.WriteLine();

                    Console.Write("Digite a opção desejada: ");
                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.Clear();
                            controller.CadastrarFuncionario();
                            break;
                        case "2":
                            Console.Clear();
                            controller.ConsultarTodosFuncionarios();
                            break;
                        case "3":
                            Console.Clear();
                            controller.ConsultarFuncionariosPorNome();
                            break;
                        case "4":
                            Console.Clear();
                            controller.AlterarFuncionario();
                            break;
                        case "5":
                            Console.Clear();
                            controller.ExcluirFuncionario();
                            break;
                        case "0":
                            continuar = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            Console.WriteLine();
                            break;
                    }
                }

                Console.WriteLine("\nAplicação encerrada.");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                FuncionarioController.ExecutarSistema();
            }
        }

        private readonly FuncionarioRepository _repository;

        public FuncionarioController(FuncionarioRepository repository)
        {
            _repository = repository;
        }

        public void CadastrarFuncionario()
        {
            try
            {
                Console.WriteLine("Cadastro de Funcionário");
                Console.WriteLine();

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Matrícula: ");
                string matricula = Console.ReadLine();

                Console.Write("CPF: ");
                string cpf = Console.ReadLine();

                var funcionario = new Funcionario
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    Matricula = matricula,
                    Cpf = cpf
                };

                _repository.Inserir(funcionario);

                Console.WriteLine("Funcionário cadastrado com sucesso.");
                Console.WriteLine();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                FuncionarioController.ExecutarSistema();
            }
        }

        public void ConsultarTodosFuncionarios()
        {
            try
            {
                Console.WriteLine("Consulta de Todos os Funcionários");
                Console.WriteLine();

                var funcionarios = _repository.ConsultarTodos();

                foreach (var funcionario in funcionarios)
                {
                    Console.WriteLine($"ID: {funcionario.Id}");
                    Console.WriteLine($"Nome: {funcionario.Nome}");
                    Console.WriteLine($"Matrícula: {funcionario.Matricula}");
                    Console.WriteLine($"CPF: {funcionario.Cpf}");
                    Console.WriteLine();
                }

                Console.WriteLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                FuncionarioController.ExecutarSistema();
            }
        }

        public void ConsultarFuncionariosPorNome()
        {
            try
            {
                Console.WriteLine("Consulta de Funcionários por Nome");
                Console.WriteLine();

                Console.Write("Digite o nome a ser pesquisado: ");
                string nome = Console.ReadLine();

                var funcionarios = _repository.ConsultarPorNome(nome);

                foreach (var funcionario in funcionarios)
                {
                    Console.WriteLine($"ID: {funcionario.Id}");
                    Console.WriteLine($"Nome: {funcionario.Nome}");
                    Console.WriteLine($"Matrícula: {funcionario.Matricula}");
                    Console.WriteLine($"CPF: {funcionario.Cpf}");
                    Console.WriteLine();
                }

                Console.WriteLine();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                FuncionarioController.ExecutarSistema();
            }
        }

        public void AlterarFuncionario()
        {
            try
            {
                Console.WriteLine("Alteração de Funcionário");
                Console.WriteLine();

                Console.Write("Digite o ID do funcionário a ser alterado: ");
                Guid id = Guid.Parse(Console.ReadLine());

                var funcionario = _repository.ConsultarPorId(id);

                if (funcionario == null)
                {
                    Console.WriteLine("Funcionário não encontrado.");
                    Console.WriteLine();
                    return;
                }

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Matrícula: ");
                string matricula = Console.ReadLine();

                Console.Write("CPF: ");
                string cpf = Console.ReadLine();

                funcionario.Nome = nome;
                funcionario.Matricula = matricula;
                funcionario.Cpf = cpf;

                _repository.Alterar(funcionario);

                Console.WriteLine("Funcionário alterado com sucesso.");
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                FuncionarioController.ExecutarSistema();
            }
        }

        public void ExcluirFuncionario()
        {
            try
            {
                Console.WriteLine("Exclusão de Funcionário");
                Console.WriteLine();

                Console.Write("Digite o ID do funcionário a ser excluído: ");
                Guid id = Guid.Parse(Console.ReadLine());

                var funcionario = _repository.ConsultarPorId(id);

                if (funcionario == null)
                {
                    Console.WriteLine("Funcionário não encontrado.");
                    Console.WriteLine();
                    return;
                }

                _repository.Excluir(id);

                Console.WriteLine("Funcionário excluído com sucesso.");
                Console.WriteLine();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                FuncionarioController.ExecutarSistema();
            }
        }
    }
}
