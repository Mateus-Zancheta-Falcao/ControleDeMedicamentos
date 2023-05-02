using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloRequisicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloAquisicao
{
    internal class TelaAquisicao : TelaMae
    {
        public int IdContador;
        public RepositorioMae<Aquisicao> listaAquisicao = new RepositorioMae<Aquisicao>();
        public RepositorioMae<Fornecedor> listaFornecedores = new RepositorioMae<Fornecedor>();
        public RepositorioMae<Medicamento> listaMedicamentos = new RepositorioMae<Medicamento>();
        public RepositorioMae<Funcionario> listaFuncionarios = new RepositorioMae<Funcionario>();

        public void MenuAquisicao(List<RepositorioMae<Fornecedor>> fornecedores, List<RepositorioMae<Medicamento>> medicamentos, List<RepositorioMae<Funcionario>> funcionarios)
        {
            Console.Clear();

            Console.WriteLine("========= Menu Aquisição =========\n");
            Console.WriteLine("1- Cadastrar aquisição \n2- Vizualizar aquisições \n3- Editar aquisição");
            Console.WriteLine("4- Remover aquisição \n5- Voltar ao menu principal");

            Console.WriteLine("Informe a opção desejada: ");
            int opcaoAquisicao = Convert.ToInt32(Console.ReadLine());

            switch (opcaoAquisicao)
            {
                case 1:
                    CadastraAquisicao(fornecedores, medicamentos, funcionarios);
                    break;

                case 2:
                    VizualizaAquisicoes(fornecedores, medicamentos, funcionarios);
                    break;

                case 3:
                    EditaAquisicao(fornecedores, medicamentos, funcionarios);
                    break;

                case 4:
                    RemoveAquisicao(fornecedores, medicamentos, funcionarios);
                    break;

                case 5:
                    MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuAquisicao(fornecedores, medicamentos, funcionarios);
                    break;
            }
        }
        public void CadastraAquisicao(List<RepositorioMae<Fornecedor>> fornecedores, List<RepositorioMae<Medicamento>> medicamentos, List<RepositorioMae<Funcionario>> funcionarios)
        {
            Console.Clear();

            Console.WriteLine("========= Cadastro Aquisição =========\n");

            Console.WriteLine("Informe o Id do fornecedor: ");
            int EncontraIdFornecedor = Convert.ToInt32(Console.ReadLine());

            listaFornecedores.EncontraPorId(EncontraIdFornecedor, fornecedores);

            Console.WriteLine("Informe o id do medicamento  : ");
            int EncontraIdMedicamento = Convert.ToInt32(Console.ReadLine());

            listaMedicamentos.EncontraPorId(EncontraIdMedicamento, medicamentos);

            Console.WriteLine("Informe a quantidade de medicamentos: ");
            int QuantidadeDisponivel = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o Id do funcionário: ");
            int EncontraIdFuncionario = Convert.ToInt32(Console.ReadLine());

            listaFuncionarios.EncontraPorId(EncontraIdFuncionario, funcionarios);

            Console.WriteLine("Informe a data da requisição: ");
            DateTime DataPedido = Convert.ToDateTime(Console.ReadLine());

            IdContador++;

            Aquisicao aquisicao = new Aquisicao(IdContador,listaFornecedores,listaMedicamentos,listaFuncionarios,DataPedido,QuantidadeDisponivel);

            listaAquisicao.Inserir(aquisicao);

            Console.WriteLine("\nAquisição cadastrado com sucesso!\n");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuAquisicao(fornecedores, medicamentos, funcionarios);
        }
        public void VizualizaAquisicoes(List<RepositorioMae<Fornecedor>> fornecedores, List<RepositorioMae<Medicamento>> medicamentos, List<RepositorioMae<Funcionario>> funcionarios)
        {
            Console.Clear();

            var listaAquisicoes = listaAquisicao.RetornaDados();

            if (listaAquisicoes.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma requisição cadastrada!");
            }
            else
            {
                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", "ID Aquisição", "Data Aquisição", "Quantidade Medicamentos", "Nome Fornecedor", "Nome Medicamento", "Nome Funcionário");
                foreach (var itemAquisicao in listaAquisicoes)
                {
                    foreach (var itemFornecedor in listaFornecedores.RetornaDados())
                    {
                        foreach (var itemMedicamento in listaMedicamentos.RetornaDados())
                        {
                            foreach (var itemFuncionario in listaFuncionarios.RetornaDados())
                            {
                                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", itemAquisicao.Id, itemAquisicao.DataPedido, itemAquisicao.QuantidadeDeMedicamentos, itemFornecedor.Nome, itemMedicamento.Nome, itemFuncionario.Nome);
                            }
                        }
                    }
                }
            }

            Console.ReadKey();
            MenuAquisicao(fornecedores, medicamentos, funcionarios);
        }
        public void EditaAquisicao(List<RepositorioMae<Fornecedor>> fornecedores, List<RepositorioMae<Medicamento>> medicamentos, List<RepositorioMae<Funcionario>> funcionarios)
        {
            Console.Clear();
            var listaAquisicoes = listaAquisicao.RetornaDados();

            Console.WriteLine("Informe o id da requisição que deseja editar: ");
            int idEncontrar = Convert.ToInt32(Console.ReadLine());

            foreach (var itemAquisicao in listaAquisicoes)
            {
                foreach (var itemFornecedor in listaFornecedores.RetornaDados())
                {
                    foreach (var itemMedicamento in listaMedicamentos.RetornaDados())
                    {
                        foreach (var itemFuncionario in listaFuncionarios.RetornaDados())
                        {
                            if (idEncontrar == itemAquisicao.Id)
                            {
                                Console.WriteLine("========= Dados Aquisição =========\n");
                                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", "ID Requisição", "Data Requisição", "Quantidade Medicamentos", "Nome Fornecedor", "Nome Medicamento", "Nome Funcionário");
                                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", itemAquisicao.Id, itemAquisicao.DataPedido, itemAquisicao.QuantidadeDeMedicamentos, itemFornecedor.Nome, itemMedicamento.Nome, itemFuncionario.Nome);

                                Console.WriteLine("\n========= Edita Aquisição =========\n");

                                Console.WriteLine("Informe a data da requisição: ");
                                itemAquisicao.DataPedido = Convert.ToDateTime(Console.ReadLine());

                                Console.WriteLine("Informe a quantidade de medicamentos: ");
                                itemAquisicao.QuantidadeDeMedicamentos = Convert.ToInt32(Console.ReadLine());

                                listaAquisicao.Edita(itemAquisicao);

                                Console.WriteLine("\nRequisição editada com sucesso!\n");
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

                                Console.ReadKey();
                                MenuAquisicao(fornecedores, medicamentos, funcionarios);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuAquisicao(fornecedores, medicamentos, funcionarios);
        }
        public void RemoveAquisicao(List<RepositorioMae<Fornecedor>> fornecedores, List<RepositorioMae<Medicamento>> medicamentos, List<RepositorioMae<Funcionario>> funcionarios)
        {
            Console.Clear();

            Console.WriteLine("========= Remove Aquisição =========");
            Console.WriteLine("Informe o id da aquisição que deseja remover: ");
            int idEncontrar = Convert.ToInt32(Console.ReadLine());

            foreach (var itemAquisicao in listaAquisicao.RetornaDados())
            {
                foreach (var itemFornecedor in listaFornecedores.RetornaDados())
                {
                    foreach (var itemMedicamento in listaMedicamentos.RetornaDados())
                    {
                        foreach (var itemFuncionario in listaFuncionarios.RetornaDados())
                        {
                            if (idEncontrar == itemAquisicao.Id)
                            {
                                Console.WriteLine("========= Dados Aquisição =========\n");
                                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", "ID Requisição", "Data Requisição", "Quantidade Medicamentos", "Nome Paciente", "Nome Medicamento", "Nome Funcionário");
                                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", itemAquisicao.Id, itemAquisicao.DataPedido, itemAquisicao.QuantidadeDeMedicamentos, itemFornecedor.Nome, itemMedicamento.Nome, itemFuncionario.Nome);

                                Console.WriteLine("\n========= Deseja realmente remover o Aquisição? (1) para SIM (2) para NÃO =========\n");
                                int escolha = Convert.ToInt32(Console.ReadLine());

                                if (escolha == 1)
                                {
                                    Remove(itemAquisicao, fornecedores, medicamentos, funcionarios);
                                }
                                else if (escolha == 2)
                                {
                                    NaoRemove(fornecedores, medicamentos, funcionarios);
                                }
                                else
                                {
                                    Console.WriteLine("\nOpção inválida!");
                                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

                                    Console.ReadKey();
                                    MenuAquisicao(fornecedores, medicamentos, funcionarios);
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuAquisicao(fornecedores, medicamentos, funcionarios);
        }
        public void NaoRemove(List<RepositorioMae<Fornecedor>> fornecedores, List<RepositorioMae<Medicamento>> medicamentos, List<RepositorioMae<Funcionario>> funcionarios)
        {
            Console.WriteLine("\nRequisição não removido!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuAquisicao(fornecedores, medicamentos, funcionarios);
        }
        public void Remove(Aquisicao aquisicao, List<RepositorioMae<Fornecedor>> fornecedores, List<RepositorioMae<Medicamento>> medicamentos, List<RepositorioMae<Funcionario>> funcionarios)
        {
            listaAquisicao.RetornaDados().Remove(aquisicao);

            Console.WriteLine("\nAquisição removido com sucesso!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuAquisicao(fornecedores, medicamentos, funcionarios);
        }
    }
}
