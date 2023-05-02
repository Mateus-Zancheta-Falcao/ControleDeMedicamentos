using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloPaciente
{
    internal class RepositorioPaciente : RepositorioMae<Paciente>
    {
        public override void Edita(RepositorioMae<Paciente> pacienteAtualizado)
        {
            Paciente paciente = (Paciente)pacienteAtualizado;

            paciente.Nome = paciente.Nome;
            paciente.CPF = paciente.CPF;
            paciente.CartaoSUS = paciente.CartaoSUS;
            paciente.Telefone = paciente.Telefone;
            paciente.Endereco = paciente.Endereco;
        }
    }
}
