using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFornecedor;
using System;
using System.Collections.Generic;

namespace ControleDeMedicamentos.ModuloMedicamento
{
    internal class TelaMedicamento : TelaMae
    {
        public RepositorioMedicamento repositorio = new RepositorioMedicamento();
        public int IdContador;

        public void MenuMedicamento(List<Fornecedor> fornecedores)
        {
            Console.Clear();

            Console.WriteLine("========= Menu Medicamento =========\n");
            Console.WriteLine("1- Cadastrar medicamento \n2- Vizualizar medicamentos \n3- Editar medicamento");
            Console.WriteLine("4- Remover medicamento \n5- Voltar ao menu principal");

            Console.WriteLine("Informe a opção desejada: ");
            int OpcaoMedicamento = Convert.ToInt32(Console.ReadLine());

            switch (OpcaoMedicamento)
            {
                case 1:
                    CadastraMedicamento(fornecedores);
                    break;

                case 2:
                    VizualizaMedicamentos(fornecedores);
                    break;

                case 3:
                    EditaMedicamento(fornecedores);
                    break;

                case 4:
                    RemoveMedicamento(fornecedores);
                    break;

                case 5:
                    MenuPrincipal();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    break;
            }
        }
        public void CadastraMedicamento(List<Fornecedor> fornecedores)
        {
            Console.Clear();
            Medicamento medicamento = new Medicamento();

            Console.WriteLine("========= Cadastro Medicamento =========\n");

            Console.WriteLine("Informe o CNPJ do fornecedor do medicamento: ");
            string CnpjEncontrar = Console.ReadLine();

            foreach (var item in fornecedores)
            {
                if (CnpjEncontrar == item.CNPJ)
                {
                    Console.WriteLine("Informe o nome do medicamento: ");
                    medicamento.Nome = Console.ReadLine();

                    Console.WriteLine("Informe a descrição do medicamento: ");
                    medicamento.Descricao = Console.ReadLine();

                    Console.WriteLine("Informe a quantidade disponivel do medicamento: ");
                    medicamento.QuantidadeDisponivel = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Informe a quantidade limite do medicamento: ");
                    medicamento.QuantidadeLimite = Convert.ToInt32(Console.ReadLine());

                    medicamento.fornecedor.CNPJ = item.CNPJ;
                    medicamento.fornecedor.Nome = item.Nome;
                    medicamento.fornecedor.Email = item.Email;
                    medicamento.fornecedor.Endereco = item.Endereco;
                    medicamento.fornecedor.Telefone = item.Telefone;

                    IdContador++;
                    medicamento.Id = IdContador;

                    repositorio.Inserir(medicamento);

                    Console.WriteLine("\nMedicamento cadastrado com sucesso!\n");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

                    Console.ReadKey();
                    MenuMedicamento(fornecedores);
                }
            }

            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();

            //CadastraMedicamento();
        }
        public void VizualizaMedicamentos(List<Fornecedor> fornecedores)
        {
            Console.Clear();
            var listaMedicamento = repositorio.RetornaDados();

            if (listaMedicamento.Count == 0)
            {
                Console.WriteLine("Não existe nenhum medicamento cadastrado!");
            }
            else
            {
                Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-25} | {4,-20} | {5,-15} | {6,-20} | {7,-20} | {8,-10}", "ID", "Nome", "Descrição", "Quantidade Disponivel", "Quantidade Limite","Fornecedor","CNPJ","Telefone","Endereço");
                foreach (var item in listaMedicamento)
                {
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-25} | {4,-20} | {5,-15} | {6,-20} | {7,-20} | {8,-10}",
                        item.Id, 
                        item.Nome, 
                        item.Descricao, 
                        item.QuantidadeDisponivel, 
                        item.QuantidadeLimite, 
                        item.fornecedor.Nome,
                        item.fornecedor.CNPJ,
                        item.fornecedor.Telefone,
                        item.fornecedor.Endereco);
                }
            }

            Console.ReadKey();
            MenuMedicamento(fornecedores);
        }
        public void EditaMedicamento(List<Fornecedor> fornecedores)
        {
            Console.Clear();
            repositorio.RetornaDados();

            Console.WriteLine("Informe o id do medicamento que deseja editar: ");
            int idEncontrar = Convert.ToInt32(Console.ReadLine());

            foreach (var item in repositorio.RetornaDados())
            {
                if (idEncontrar == item.Id)
                {
                    Console.WriteLine("========= Dados Medicamento =========\n");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-10} | {4,-10}", "ID", "Nome", "Descrição", "Quantidade Disponivel", "Quantidade Limite");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-10} | {4,-10}", item.Id, item.Nome, item.Descricao, item.QuantidadeDisponivel, item.QuantidadeLimite);

                    Console.WriteLine("\n========= Edita Medicamento =========\n");

                    Console.WriteLine("Informe o nome do medicamento: ");
                    item.Nome = Console.ReadLine();

                    Console.WriteLine("Informe a descrição do medicamento: ");
                    item.Descricao = Console.ReadLine();

                    Console.WriteLine("Informe a quantidade disponivel do medicamento: ");
                    item.QuantidadeDisponivel = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Informe o Login do medicamento: ");
                    item.QuantidadeLimite = Convert.ToInt32(Console.ReadLine());

                    repositorio.Edita(item);

                    Console.WriteLine("\nMedicamento editado com sucesso!\n");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

                    Console.ReadKey();
                    MenuMedicamento(fornecedores);
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuMedicamento(fornecedores);
        }
        public void RemoveMedicamento(List<Fornecedor> fornecedores)
        {
            Console.Clear();
            repositorio.RetornaDados();

            Console.WriteLine("========= Remove Medicamento =========");
            Console.WriteLine("Informe o id do medicamento que deseja remover: ");
            int idEncontrar = Convert.ToInt32(Console.ReadLine());

            foreach (var item in repositorio.RetornaDados())
            {
                if (idEncontrar == item.Id)
                {
                    Console.WriteLine("========= Dados Medicamento =========\n");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-10} | {4,-10}", "ID", "Nome", "Descrição", "Quantidade Disponivel", "Quantidade Limite");
                    Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3,-10} | {4,-10}", item.Id, item.Nome, item.Descricao, item.QuantidadeDisponivel, item.QuantidadeLimite);

                    Console.WriteLine("\n========= Deseja realmente remover o medicamento? (1) para SIM (2) para NÃO =========\n");
                    int escolha = Convert.ToInt32(Console.ReadLine());

                    if (escolha == 1)
                    {
                        Remove(item, fornecedores);
                    }
                    else if (escolha == 2)
                    {
                        NaoRemove(fornecedores);
                    }
                    else
                    {
                        Console.WriteLine("\nOpção inválida!");
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

                        Console.ReadKey();
                        MenuMedicamento(fornecedores);
                    }
                }
            }
            Console.WriteLine("\nId não encontrado! ");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuMedicamento(fornecedores);
        }
        public void NaoRemove(List<Fornecedor> fornecedores)
        {
            Console.WriteLine("\nFuncionário não removido!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuMedicamento(fornecedores);
        }
        public void Remove(Medicamento medicamento, List<Fornecedor> fornecedores)
        {
            repositorio.RetornaDados().Remove(medicamento);

            Console.WriteLine("\nFuncionário removido com sucesso!");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");

            Console.ReadKey();
            MenuMedicamento(fornecedores);
        }
    }
}
