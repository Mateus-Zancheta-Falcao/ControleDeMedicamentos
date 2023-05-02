using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloAquisicao
{
    internal class RepositorioAquisicao : RepositorioMae<Aquisicao>
    {
        public override void Edita(RepositorioMae<Aquisicao> aquisicaoAtualizado)
        {
            Aquisicao aquisicao = (Aquisicao)aquisicaoAtualizado;

            aquisicao.DataPedido = aquisicao.DataPedido;
            aquisicao.QuantidadeDeMedicamentos = aquisicao.QuantidadeDeMedicamentos;
        }
    }
}
