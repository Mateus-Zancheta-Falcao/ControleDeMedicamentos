using ControleDeMedicamentos.ModuloAquisicao;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using ControleDeMedicamentos.ModuloRequisicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Compartilhado
{
    internal class TelaMae
    {
        private static TelaFuncionario telaFuncionario = new TelaFuncionario();
        private static TelaMedicamento telaMedicamento = new TelaMedicamento();
        private static TelaFornecedor telaFornecedor = new TelaFornecedor();
        private static TelaPaciente telaPaciente = new TelaPaciente();
        private static TelaAquisicao telaAquisicao = new TelaAquisicao();
        private static TelaRequisicao telaRequisicao = new TelaRequisicao();

        private static List<RepositorioMae<Funcionario>> listaFuncionarios = new List<RepositorioMae<Funcionario>>();
        private static List<RepositorioMae<Paciente>> listaPacientes = new List<RepositorioMae<Paciente>>();
        private static List<RepositorioMae<Medicamento>> listaMedicamentos = new List<RepositorioMae<Medicamento>>();
        private static List<RepositorioMae<Fornecedor>> listaFornecedores = new List<RepositorioMae<Fornecedor>>();

        public void MenuPrincipal()
        {
            Console.Clear();

            var funcionario = listaFuncionarios;
            var paciente = listaPacientes;
            var medicamento = listaMedicamentos;
            var fornecedor = listaFornecedores;

            Console.WriteLine("========= Bem-vindo ao Posto de Saúde =========");
            Console.WriteLine("1- Menu Funcinário \n2- Menu Medicamento \n3- Menu Paciente \n4- Menu Fornecedor");
            Console.WriteLine("5- Menu Aquisição \n6- Menu Requisição \n7- Sair");
            Console.WriteLine("\nInforme a opção desejada: ");
            int OpcaoPrincipal = Convert.ToInt32(Console.ReadLine());

            switch (OpcaoPrincipal)
            {
                case 1:
                    telaFuncionario.MenuFuncionario();
                    break;

                case 2:
                    var ListaFornecedor = telaFornecedor.repositorio.RetornaDados();

                    telaMedicamento.MenuMedicamento(ListaFornecedor);
                    break;

                case 3:
                    telaPaciente.MenuPaciente();
                    break;

                case 4:
                    telaFornecedor.MenuFornecedor();
                    break;

                case 5:
                    telaAquisicao.MenuAquisicao(fornecedor, medicamento, funcionario);
                    break;

                case 6:
                    telaRequisicao.MenuRequisicao(paciente, medicamento, funcionario);
                    break;

                case 7:
                    Console.WriteLine("\nSaindo do sistema...");
                    Console.ReadKey();

                    Environment.Exit(7);
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");

                    Console.ReadKey();
                    break;
            }
        }

        
    }
}
