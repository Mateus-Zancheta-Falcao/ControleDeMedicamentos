using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos
{
    internal class Requisicao : RepositorioMae<Requisicao>
    {
        public int Id { get; set; }
        public RepositorioMae<Paciente> paciente { get; set; }
        public RepositorioMae<Medicamento> medicamento { get; set; }
        public RepositorioMae<Funcionario> funcionario { get; set; }
        public DateTime DataPedido { get; set; }
        public int QuantidadeDeMedicamentos { get; set; }

        public Requisicao(int id, RepositorioMae<Paciente> paciente, RepositorioMae<Medicamento> medicamento, RepositorioMae<Funcionario> funcionario, DateTime dataPedido, int quantidadeDeMedicamentos)
        {
            Id = id;
            this.paciente = paciente;
            this.medicamento = medicamento;
            this.funcionario = funcionario;
            DataPedido = dataPedido;
            QuantidadeDeMedicamentos = quantidadeDeMedicamentos;
        }
    }
}
