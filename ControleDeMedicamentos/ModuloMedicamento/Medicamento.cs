using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos
{
    internal class Medicamento : RepositorioMae<Medicamento>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int QuantidadeLimite { get; set; }
        public Requisicao HistoricoDeRequisicao { get; set; }
        public Fornecedor fornecedor { get; set; } = new Fornecedor();
    }
}
