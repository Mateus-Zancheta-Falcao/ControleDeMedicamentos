using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloPaciente
{
    internal class TelaPaciente : TelaMae
    {
        public int IdContador;

        public RepositorioPaciente repositorio = new RepositorioPaciente();

        public void MenuPaciente()
        {
            Console.Clear();

            Console.WriteLine("========= Menu Paciente =========\n");
            Console.WriteLine("1- Cadastrar paciente \n2- Vizualizar pacientes \n3- Editar paciente");
            Console.WriteLine("4- Remover paciente \n5- Voltar ao menu principal");

            Console.WriteLine("Informe a opção desejada: ");
            int OpcaoPaciente = Convert.ToInt32(Console.ReadLine());

            switch (OpcaoPaciente)
            {
                case 1:
                    CadastraPaciente();
                    break;

                case 2:
                    VizualizaPacientes();
                    break;

                case 3:
                    EditaPaciente();
                    break;

                case 4:
                    RemovePaciente();
                    break;

                case 5:
                    MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuPaciente();
                    break;
            }
        }
        public void CadastraPaciente()
        {
            Console.Clear();
            Paciente paciente = new Paciente();

            Console.WriteLine("========= Cadastro Paciente =========\n");

            Console.WriteLine("Informe o nome do Paciente: ");
            paciente.Nome = Console.ReadLine();

            Console.WriteLine("Informe o CPF do Paciente: ");
            paciente.CPF = Console.ReadLine();

            Console.WriteLine("Informe o cartão do SUS do Paciente: ");
            paciente.CartaoSUS = Console.ReadLine();

            Console.WriteLine("Informe o telefone do Paciente: ");
            paciente.Telefone = Console.ReadLine();

            Console.WriteLine("Informe o endereço do Paciente: ");
            paciente.Endereco = Console.ReadLine();

            IdContador++;
            paciente.Id = IdContador;

            repositorio.Inserir(paciente);

            Console.WriteLine("\nPaciente cadastrado com sucesso!\n");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuPaciente();
        }
        public void VizualizaPacientes()
        {
            Console.Clear();

            if (repositorio.RetornaDados().Count == 0)
            {
                Console.WriteLine("Não existe nenhum paciente cadastrado!");
            }
            else
            {
                Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", "ID", "Nome", "CPF", "Cartão SUS", "Telefone","Endereço");
                foreach (var item in repositorio.RetornaDados())
                {
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", item.Id, item.Nome, item.CPF, item.CartaoSUS, item.Telefone, item.Endereco);
                }
            }

            Console.ReadKey();
            MenuPaciente();
        }
        public void EditaPaciente()
        {
            Console.Clear();
            repositorio.RetornaDados();

            Console.WriteLine("Informe o CPF do paciente que deseja editar: ");
            string CpfEncontrar = Console.ReadLine();

            foreach (var item in repositorio.RetornaDados())
            {
                if (CpfEncontrar == item.CPF)
                {
                    Console.WriteLine("========= Dados Paciente =========\n");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", "ID", "Nome", "CPF", "Cartão SUS", "Telefone","Endereço");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", item.Id, item.Nome, item.CPF, item.CartaoSUS, item.Telefone, item.Endereco);

                    Console.WriteLine("\n========= Edita Paciente =========\n");

                    Console.WriteLine("Informe o nome do Paciente: ");
                    item.Nome = Console.ReadLine();

                    Console.WriteLine("Informe o CPF do Paciente: ");
                    item.CPF = Console.ReadLine();

                    Console.WriteLine("Informe o cartão do SUS do Paciente: ");
                    item.CartaoSUS = Console.ReadLine();

                    Console.WriteLine("Informe o telefone do Paciente: ");
                    item.Telefone = Console.ReadLine();

                    Console.WriteLine("Informe o endereço do Paciente: ");
                    item.Endereco = Console.ReadLine();

                    repositorio.Edita(item);

                    Console.WriteLine("\nFuncionário editado com sucesso!\n");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

                    Console.ReadKey();
                    MenuPaciente();
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuPaciente();
        }
        public void RemovePaciente()
        {
            Console.Clear();
            repositorio.RetornaDados();

            Console.WriteLine("========= Remove Paciente =========");
            Console.WriteLine("Informe o id do funcionário que deseja remover: ");
            string CpfEncontrar = Console.ReadLine();

            foreach (var item in repositorio.RetornaDados())
            {
                if (CpfEncontrar == item.CPF)
                {
                    Console.WriteLine("========= Dados Paciente =========\n");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", "ID", "Nome", "CPF", "Cartão SUS", "Telefone", "Endereço");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16}", item.Id, item.Nome, item.CPF, item.CartaoSUS, item.Telefone, item.Endereco);

                    Console.WriteLine("\n========= Deseja realmente remover o funcionário? (1) para SIM (2) para NÃO =========\n");
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
                        MenuPaciente();
                    }
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuPaciente();
        }
        public void NaoRemove()
        {
            Console.WriteLine("\nPaciente não removido!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuPaciente();
        }
        public void Remove(Paciente paciente)
        {
            repositorio.RetornaDados().Remove(paciente);

            Console.WriteLine("\nPaciente removido com sucesso!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuPaciente();
        }
    }
}
