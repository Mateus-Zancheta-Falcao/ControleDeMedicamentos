using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos
{
    internal class TelaFuncionario : TelaMae
    {
        public int IdContador;
        RepositorioFuncionario repositorio = new RepositorioFuncionario();

        public void MenuFuncionario()
        {
            Console.Clear();

            Console.WriteLine("========= Menu Funcionário =========\n");
            Console.WriteLine("1- Cadastrar funcionário \n2- Vizualizar funcionários \n3- Editar funcionário");
            Console.WriteLine("4- Remover funcionário \n5- Voltar ao menu principal");

            Console.WriteLine("Informe a opção desejada: ");
            int OpcaoFuncionario = Convert.ToInt32(Console.ReadLine());

            switch (OpcaoFuncionario)
            {
                case 1:
                    CadastraFuncionario();
                    break;

                case 2:
                    VizualizaFuncionarios();
                    break;

                case 3:
                    EditaFuncionario();
                    break;

                case 4:
                    RemoveFuncionario();
                    break;

                case 5:
                    MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Console.ReadKey();

                    MenuFuncionario();
                    break;
            }
        }
        public void CadastraFuncionario()
        {
            Console.Clear();
            Funcionario funcionario = new Funcionario();

            Console.WriteLine("========= Cadastro Funcionário =========\n");

            Console.WriteLine("Informe o nome do funcionário: ");
            funcionario.Nome = Console.ReadLine();

            Console.WriteLine("Informe o CPF do funcionário: ");
            funcionario.CPF = Console.ReadLine();

            Console.WriteLine("Informe o Telefone do funcionário: ");
            funcionario.Telefone = Console.ReadLine();

            Console.WriteLine("Informe o Login do funcionário: ");
            funcionario.Login = Console.ReadLine();

            Console.WriteLine("Informe a Senha do funcionário: ");
            funcionario.Senha = Console.ReadLine();

            Console.WriteLine("Informe o endereço do funcionário: ");
            funcionario.Endereco = Console.ReadLine();

            IdContador++;

            funcionario.Id = IdContador;
            
            repositorio.Inserir(funcionario);

            Console.WriteLine("\nFuncionário cadastrado com sucesso!\n");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuFuncionario();
        }
        public void VizualizaFuncionarios()
        {
            Console.Clear();

            var listaFuncionarios = repositorio.RetornaDados();

            if (listaFuncionarios.Count == 0)
            {
                Console.WriteLine("Não existe nenhum funcionário cadastrado!");
            }
            else
            {
                Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16} | {6,-18}", "ID", "Nome", "CPF", "Telefone", "Login", "Senha", "Endereço");
                foreach (var item in listaFuncionarios)
                {
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16} | {6,-18}", item.Id, item.Nome, item.CPF, item.Telefone, item.Login, item.Senha, item.Endereco);
                }
            }

            Console.ReadKey();
            MenuFuncionario();
        }
        public void EditaFuncionario()
        {
            Console.Clear();
            var listaFuncionarios = repositorio.RetornaDados();

            Console.WriteLine("Informe o id do funcionário que deseja editar: ");
            int idEncontrar = Convert.ToInt32(Console.ReadLine());

            foreach (var item in listaFuncionarios)
            {
                if (idEncontrar == item.Id)
                {
                    Console.WriteLine("========= Dados Funcionário =========\n");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16} | {6,-18}", "ID", "Nome", "CPF", "Telefone", "Login", "Senha", "Endereço");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16} | {6,-18}", item.Id, item.Nome, item.CPF, item.Telefone, item.Login, item.Senha, item.Endereco);

                    Console.WriteLine("\n========= Edita Funcionário =========\n");

                    Console.WriteLine("Informe o nome do funcionário: ");
                    item.Nome = Console.ReadLine();

                    Console.WriteLine("Informe o CPF do funcionário: ");
                    item.CPF = Console.ReadLine();

                    Console.WriteLine("Informe o Telefone do funcionário: ");
                    item.Telefone = Console.ReadLine();

                    Console.WriteLine("Informe o Login do funcionário: ");
                    item.Login = Console.ReadLine();

                    Console.WriteLine("Informe a Senha do funcionário: ");
                    item.Senha = Console.ReadLine();

                    Console.WriteLine("Informe o endereço do funcionário: ");
                    item.Endereco = Console.ReadLine();

                    repositorio.Edita(item);

                    Console.WriteLine("\nFuncionário editado com sucesso!\n");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

                    Console.ReadKey();
                    MenuFuncionario();
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuFuncionario();
        }
        public void RemoveFuncionario()
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
                    Console.WriteLine("========= Dados Funcionário =========\n");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16} | {6,-18}", "ID", "Nome", "CPF", "Telefone", "Login", "Senha", "Endereço");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-12} | {3,-12} | {4,-15} | {5,-16} | {6,-18}", item.Id, item.Nome, item.CPF, item.Telefone, item.Login, item.Senha, item.Endereco);

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
                        MenuFuncionario();
                    }
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuFuncionario();
        }
        public void NaoRemove()
        {
            Console.WriteLine("\nFuncionário não removido!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuFuncionario();
        }
        public void Remove(Funcionario funcionario)
        {
            repositorio.RetornaDados().Remove(funcionario);

            Console.WriteLine("\nFuncionário removido com sucesso!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuFuncionario();
        }
    }
}
