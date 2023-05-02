using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloFuncionario
{
    internal class RepositorioFuncionario : RepositorioMae<Funcionario>
    {
        public override void Edita(RepositorioMae<Funcionario> funcionarioAtualizado)
        {
            Funcionario funcionario = (Funcionario)funcionarioAtualizado;

            funcionario.Nome = funcionario.Nome;
            funcionario.CPF = funcionario.CPF;
            funcionario.Telefone = funcionario.Telefone;
            funcionario.Login = funcionario.Login;
            funcionario.Senha = funcionario.Senha;
            funcionario.Endereco = funcionario.Endereco;
        }
    }
}
