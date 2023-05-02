using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos
{
    internal class Aquisicao : RepositorioMae<Aquisicao>
    {
        public int Id { get; set; }
        public RepositorioMae<Fornecedor> fornecedor { get; set; }
        public RepositorioMae<Medicamento> medicamento { get; set; }
        public RepositorioMae<Funcionario> funcionario { get; set; }
        public DateTime DataPedido { get; set; }
        public int QuantidadeDeMedicamentos { get; set; }

        public Aquisicao(int id, RepositorioMae<Fornecedor> fornecedor, RepositorioMae<Medicamento> medicamento, RepositorioMae<Funcionario> funcionario, DateTime dataPedido, int quantidadeDeMedicamentos)
        {
            Id = id;
            this.fornecedor = fornecedor;
            this.medicamento = medicamento;
            this.funcionario = funcionario;
            DataPedido = dataPedido;
            QuantidadeDeMedicamentos = quantidadeDeMedicamentos;
        }
    }
}
