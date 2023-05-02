using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos
{
    internal class TelaFornecedor : TelaMae
    {
        public int IdContador;

        public RepositorioFornecedor repositorio = new RepositorioFornecedor();
        public void MenuFornecedor()
        {
            Console.Clear();

            Console.WriteLine("========= Menu Fornecedor =========\n");
            Console.WriteLine("1- Cadastrar fornecedor \n2- Vizualizar fornecedores \n3- Editar fornecedor");
            Console.WriteLine("4- Remover fornecedor \n5- Voltar ao menu principal");

            Console.WriteLine("Informe a opção desejada: ");
            int OpcaoFornecedor = Convert.ToInt32(Console.ReadLine());

            switch (OpcaoFornecedor)
            {
                case 1:
                    CadastraFornecedor();
                    break;

                case 2:
                    VizualizaFornecedores();
                    break;

                case 3:
                    EditaFornecedor();
                    break;

                case 4:
                    RemoveFornecedor();
                    break;

                case 5:
                    MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuFornecedor();
                    break;
            }
        }
        public void CadastraFornecedor()
        {
            Console.Clear();
            Fornecedor fornecedor = new Fornecedor();

            Console.WriteLine("========= Cadastro Fornecedor =========\n");

            Console.WriteLine("Informe o nome do fornecedor: ");
            fornecedor.Nome = Console.ReadLine();

            Console.WriteLine("Informe o CNPJ do fornecedor: ");
            fornecedor.CNPJ = Console.ReadLine();

            Console.WriteLine("Informe o telefone do fornecedor: ");
            fornecedor.Telefone = Console.ReadLine();

            Console.WriteLine("Informe o email do fornecedor: ");
            fornecedor.Email = Console.ReadLine();

            Console.WriteLine("Informe o endereço do fornecedor: ");
            fornecedor.Endereco = Console.ReadLine();

            IdContador++;

            fornecedor.Id = IdContador;

            repositorio.Inserir(fornecedor);

            Console.WriteLine("\nFornecedor cadastrado com sucesso!\n");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuFornecedor();
        }
        public void VizualizaFornecedores()
        {
            Console.Clear();

            if (repositorio.RetornaDados().Count == 0)
            {
                Console.WriteLine("Não existe nenhum fornecedor cadastrado!");
            }
            else
            {
                Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", "ID", "Nome", "CNPJ", "Telefone", "Email", "Endereço");
                foreach (var item in repositorio.RetornaDados())
                {
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", item.Id, item.Nome, item.CNPJ, item.Telefone, item.Email, item.Endereco);
                }
            }

            Console.ReadKey();
            MenuFornecedor();
        }
        public void EditaFornecedor()
        {
            Console.Clear();
            repositorio.RetornaDados();

            Console.WriteLine("Informe o CNPJ do fornecedor que deseja editar: ");
            string CnpjEncontrar = Console.ReadLine();

            foreach (var item in repositorio.RetornaDados())
            {
                if (CnpjEncontrar == item.CNPJ)
                {
                    Console.WriteLine("========= Dados Fornecedor =========\n");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", "ID", "Nome", "CNPJ", "Telefone", "Email", "Endereço");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", item.Id, item.Nome, item.CNPJ, item.Telefone, item.Email, item.Endereco);

                    Console.WriteLine("\n========= Edita Fornecedor =========\n");

                    Console.WriteLine("Informe o nome do fornecedor: ");
                    item.Nome = Console.ReadLine();

                    Console.WriteLine("Informe o CNPJ do fornecedor: ");
                    item.CNPJ = Console.ReadLine();

                    Console.WriteLine("Informe o telefone do fornecedor: ");
                    item.Telefone = Console.ReadLine();

                    Console.WriteLine("Informe o email do fornecedor: ");
                    item.Email = Console.ReadLine();

                    Console.WriteLine("Informe o endereço do fornecedor: ");
                    item.Endereco = Console.ReadLine();

                    repositorio.Edita(item);

                    Console.WriteLine("\nFornecedor editado com sucesso!\n");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

                    Console.ReadKey();
                    MenuFornecedor();
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuFornecedor();
        }
        public void RemoveFornecedor()
        {
            Console.Clear();
            repositorio.RetornaDados();

            Console.WriteLine("========= Remove Funcionário =========");
            Console.WriteLine("Informe o id do funcionário que deseja remover: ");
            int idEncontrar = Convert.ToInt32(Console.ReadLine());

            foreach (var item in repositorio.RetornaDados())
            {
                if (idEncontrar == item.Id)
                {
                    Console.WriteLine("========= Dados Fornecedor =========\n");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", "ID", "Nome", "CNPJ", "Telefone", "Email", "Endereço");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", item.Id, item.Nome, item.CNPJ, item.Telefone, item.Email, item.Endereco);

                    Console.WriteLine("\n========= Deseja realmente remover o fornecedor? (1) para SIM (2) para NÃO =========\n");
                    int escolha = Convert.ToInt32(Console.ReadLine());

                    if (escolha == 1)
                    {
                        Remove(item);
                    }
                    else if (escolha == 2)
                    {
                        NaoRemove();
                    }
                    else
                    {
                        Console.WriteLine("\nOpção inválida!");
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

                        Console.ReadKey();
                        MenuFornecedor();
                    }
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuFornecedor();
        }
        public void NaoRemove()
        {
            Console.WriteLine("\nFornecedor não removido!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuFornecedor();
        }
        public void Remove(Fornecedor fornecedor)
        {
            repositorio.RetornaDados().Remove(fornecedor);

            Console.WriteLine("\nFornecedor removido com sucesso!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuFornecedor();
        }
    }
}
