using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloFornecedor
{
    internal class RepositorioFornecedor : RepositorioMae<Fornecedor>
    {
        public override void Edita(RepositorioMae<Fornecedor> fornecedorAtualizado)
        {
            Fornecedor fornecedor = (Fornecedor)fornecedorAtualizado;

            fornecedor.Nome = fornecedor.Nome;
            fornecedor.CNPJ = fornecedor.CNPJ;
            fornecedor.Telefone = fornecedor.Telefone;
            fornecedor.Email = fornecedor.Email;
            fornecedor.Endereco = fornecedor.Endereco;
        }
    }
}
