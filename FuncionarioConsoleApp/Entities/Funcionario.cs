using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionarioConsoleApp.Entities
{
    public class Funcionario
    {
        private string _nome;
        private string _matricula;
        private string _cpf;

        public Guid Id { get; set; }

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 10 || value.Length > 150)
                    throw new ArgumentException("O nome do funcionário deve ter entre 10 e 150 caracteres.");

                _nome = value;
            }
        }

        public string Matricula
        {
            get { return _matricula; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 6 || !value.All(char.IsDigit))
                    throw new ArgumentException("A matrícula do funcionário deve conter exatamente 6 dígitos numéricos.");

                _matricula = value;
            }
        }

        public string Cpf
        {
            get { return _cpf; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 11 || !value.All(char.IsDigit))
                    throw new ArgumentException("O CPF do funcionário deve conter exatamente 11 dígitos numéricos.");

                _cpf = value;
            }
        }
    }

}
