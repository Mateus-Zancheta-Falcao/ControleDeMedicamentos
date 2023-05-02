using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloRequisicao
{
    internal class RepositorioRequisicao : RepositorioMae<Requisicao>
    {
        public override void Edita(RepositorioMae<Requisicao> requisicaoAtualizado)
        {
            Requisicao requisicao =  (Requisicao)requisicaoAtualizado;

            requisicao.DataPedido = requisicao.DataPedido;
            requisicao.QuantidadeDeMedicamentos = requisicao.QuantidadeDeMedicamentos;
        }
    }
}
