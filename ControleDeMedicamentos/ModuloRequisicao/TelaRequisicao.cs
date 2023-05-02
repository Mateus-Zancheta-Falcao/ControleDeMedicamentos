using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloRequisicao
{
    internal class TelaRequisicao : TelaMae
    {
        public RepositorioMae<Requisicao> listaRequisicao = new RepositorioMae<Requisicao>();
        public RepositorioMae<Paciente> listaPacientes = new RepositorioMae<Paciente>();
        public RepositorioMae<Medicamento> listaMedicamentos = new RepositorioMae<Medicamento>();
        public RepositorioMae<Funcionario> listaFuncionarios = new RepositorioMae<Funcionario>();
        public int IdContador;

        //public void CadastraRequisicao()
        //{
        //    Requisicao requisicao = new Requisicao(1, new Paciente(), new Medicamento(), new Funcionario(), DateTime.Now, 23);
        //    listaRequisicao.Inserir(requisicao);
        //}

        public void MenuRequisicao(List<RepositorioMae<Paciente>> Pacientes, List<RepositorioMae<Medicamento>> Medicamentos, List<RepositorioMae<Funcionario>> Funcionarios)
        {
            Console.Clear();

            Console.WriteLine("========= Menu Requisição =========\n");
            Console.WriteLine("1- Cadastrar requisição \n2- Vizualizar requisições \n3- Editar requisição");
            Console.WriteLine("4- Remover requisição \n5- Voltar ao menu principal");

            Console.WriteLine("Informe a opção desejada: ");
            int opcaoRequisicao = Convert.ToInt32(Console.ReadLine());

            switch (opcaoRequisicao)
            {
                case 1:
                    CadastraRequisicao(Pacientes, Medicamentos, Funcionarios);
                    break;

                case 2:
                    VizualizaRequisicoes(Pacientes, Medicamentos, Funcionarios);
                    break;

                case 3:
                    EditaRequisicao(Pacientes, Medicamentos, Funcionarios);
                    break;

                case 4:
                    RemoveRequisicao(Pacientes, Medicamentos, Funcionarios);
                    break;

                case 5:
                    MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuRequisicao(Pacientes, Medicamentos, Funcionarios);
                    break;
            }
        }
        public void CadastraRequisicao(List<RepositorioMae<Paciente>> Pacientes, List<RepositorioMae<Medicamento>> Medicamentos, List<RepositorioMae<Funcionario>> Funcionarios)
        {
            Console.Clear();

            Console.WriteLine("========= Cadastro Requisição =========\n");

            Console.WriteLine("Informe o CPF do paciente: ");
            int EncontraIdPaciente = Convert.ToInt32(Console.ReadLine());

            listaPacientes.EncontraPorId(EncontraIdPaciente, Pacientes);

            Console.WriteLine("Informe o id do medicamento  : ");
            int EncontraIdMedicamento = Convert.ToInt32(Console.ReadLine());

            listaMedicamentos.EncontraPorId(EncontraIdMedicamento, Medicamentos);

            Console.WriteLine("Informe o CPF do funcionário: ");
            int EncontraIdFuncionario = Convert.ToInt32(Console.ReadLine());

            listaFuncionarios.EncontraPorId(EncontraIdFuncionario, Funcionarios);

            Console.WriteLine("Informe a quantidade de medicamentos: ");
            int QuantidadeDisponivel = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a data da requisição: ");
            DateTime DataPedido = Convert.ToDateTime(Console.ReadLine());

            IdContador++;
            Requisicao requisicao = new Requisicao(IdContador,listaPacientes,listaMedicamentos,listaFuncionarios, DataPedido, QuantidadeDisponivel);

            listaRequisicao.Inserir(requisicao);

            Console.WriteLine("\nRequisição cadastrado com sucesso!\n");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuRequisicao(Pacientes, Medicamentos, Funcionarios);
        }
        public void VizualizaRequisicoes(List<RepositorioMae<Paciente>> Pacientes, List<RepositorioMae<Medicamento>> Medicamentos, List<RepositorioMae<Funcionario>> Funcionarios)
        {
            Console.Clear();

            var listaRequisicoes = listaRequisicao.RetornaDados();

            if (listaRequisicoes.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma requisição cadastrada!");
            }
            else
            {
                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", "ID Requisição", "Data Requisição", "Quantidade Medicamentos", "Nome Paciente", "Nome Medicamento", "Nome Funcionário");
                foreach (var itemRequisicao in listaRequisicoes)
                {
                    foreach (var itemPaciente in listaPacientes.RetornaDados())
                    {
                        foreach (var itemMedicamento in listaMedicamentos.RetornaDados())
                        {
                            foreach (var itemFuncionario in listaFuncionarios.RetornaDados())
                            {
                                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", itemRequisicao.Id, itemRequisicao.DataPedido, itemRequisicao.QuantidadeDeMedicamentos, itemPaciente.Nome, itemMedicamento.Nome, itemFuncionario.Nome);
                            }
                        }
                    }
                }
            }

            Console.ReadKey();
            MenuRequisicao(Pacientes, Medicamentos, Funcionarios);
        }
        public void EditaRequisicao(List<RepositorioMae<Paciente>> Pacientes, List<RepositorioMae<Medicamento>> Medicamentos, List<RepositorioMae<Funcionario>> Funcionarios)
        {
            Console.Clear();
            var listaRequisicoes = listaRequisicao.RetornaDados();

            Console.WriteLine("Informe o id da requisição que deseja editar: ");
            int idEncontrar = Convert.ToInt32(Console.ReadLine());

            foreach (var itemRequisicao in listaRequisicoes)
            {
                foreach (var itemPaciente in listaPacientes.RetornaDados())
                {
                    foreach (var itemMedicamento in listaPacientes.RetornaDados())
                    {
                        foreach (var itemFuncionario in listaPacientes.RetornaDados())
                        {
                            if (idEncontrar == itemRequisicao.Id)
                            {
                                Console.WriteLine("========= Dados Requisição =========\n");
                                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", "ID Requisição", "Data Requisição", "Quantidade Medicamentos", "Nome Paciente", "Nome Medicamento", "Nome Funcionário");
                                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", itemRequisicao.Id, itemRequisicao.DataPedido, itemRequisicao.QuantidadeDeMedicamentos, itemPaciente.Nome, itemMedicamento.Nome, itemFuncionario.Nome);

                                Console.WriteLine("\n========= Edita Requisição =========\n");

                                Console.WriteLine("Informe a data da requisição: ");
                                itemRequisicao.DataPedido = Convert.ToDateTime(Console.ReadLine());

                                Console.WriteLine("Informe a quantidade de medicamentos: ");
                                itemRequisicao.QuantidadeDeMedicamentos = Convert.ToInt32(Console.ReadLine());

                                listaRequisicao.Edita(itemRequisicao);

                                Console.WriteLine("\nRequisição editada com sucesso!\n");
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

                                Console.ReadKey();
                                MenuRequisicao(Pacientes, Medicamentos, Funcionarios);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuRequisicao(Pacientes, Medicamentos, Funcionarios);
        }
        public void RemoveRequisicao(List<RepositorioMae<Paciente>> Pacientes, List<RepositorioMae<Medicamento>> Medicamentos, List<RepositorioMae<Funcionario>> Funcionarios)
        {
            Console.Clear();

            Console.WriteLine("========= Remove Requisição =========");
            Console.WriteLine("Informe o id da requisição que deseja remover: ");
            int idEncontrar = Convert.ToInt32(Console.ReadLine());

            foreach (var itemRequisicao in listaRequisicao.RetornaDados())
            {
                foreach (var itemPaciente in listaPacientes.RetornaDados())
                {
                    foreach (var itemMedicamento in listaMedicamentos.RetornaDados())
                    {
                        foreach (var itemFuncionario in listaFuncionarios.RetornaDados())
                        {
                            if (idEncontrar == itemRequisicao.Id)
                            {
                                Console.WriteLine("========= Dados Requisição =========\n");
                                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", "ID Requisição", "Data Requisição", "Quantidade Medicamentos", "Nome Paciente", "Nome Medicamento", "Nome Funcionário");
                                Console.WriteLine("{0,-12} | {1,-14} | {2,-16} | {3,-20} | {4,-20} | {5,-20} |", itemRequisicao.Id, itemRequisicao.DataPedido, itemRequisicao.QuantidadeDeMedicamentos, itemPaciente.Nome, itemMedicamento.Nome, itemFuncionario.Nome);

                                Console.WriteLine("\n========= Deseja realmente remover o requisição? (1) para SIM (2) para NÃO =========\n");
                                int escolha = Convert.ToInt32(Console.ReadLine());

                                if (escolha == 1)
                                {
                                    Remove(itemRequisicao, Pacientes, Medicamentos, Funcionarios);
                                }
                                else if (escolha == 2)
                                {
                                    NaoRemove(Pacientes, Medicamentos, Funcionarios);
                                }
                                else
                                {
                                    Console.WriteLine("\nOpção inválida!");
                                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

                                    Console.ReadKey();
                                    MenuRequisicao(Pacientes, Medicamentos, Funcionarios);
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuRequisicao(Pacientes, Medicamentos, Funcionarios);
        }
        public void NaoRemove(List<RepositorioMae<Paciente>> Pacientes, List<RepositorioMae<Medicamento>> Medicamentos, List<RepositorioMae<Funcionario>> Funcionarios)
        {
            Console.WriteLine("\nRequisição não removido!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuRequisicao(Pacientes,Medicamentos, Funcionarios);
        }
        public void Remove(Requisicao requisicao, List<RepositorioMae<Paciente>> Pacientes, List<RepositorioMae<Medicamento>> Medicamentos, List<RepositorioMae<Funcionario>> Funcionarios)
        {
            listaRequisicao.RetornaDados().Remove(requisicao);

            Console.WriteLine("\nRequisição removido com sucesso!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuRequisicao(Pacientes, Medicamentos, Funcionarios);
        }
    }
}
