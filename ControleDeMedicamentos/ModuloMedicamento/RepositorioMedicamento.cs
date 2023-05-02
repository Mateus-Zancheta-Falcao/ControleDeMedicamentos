using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloMedicamento
{
    internal class RepositorioMedicamento : RepositorioMae<Medicamento>
    {
        public override void Edita(RepositorioMae<Medicamento> medicamentoAtualizado)
        {
            Medicamento medicamento = (Medicamento)medicamentoAtualizado;

            medicamento.Nome = medicamento.Nome;
            medicamento.Descricao = medicamento.Descricao;
            medicamento.QuantidadeDisponivel = medicamento.QuantidadeDisponivel;
            medicamento.QuantidadeLimite = medicamento.QuantidadeLimite;
        }
    }
}
