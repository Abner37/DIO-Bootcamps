using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();


        static void Main(string[] args)
        {
            string opcao = ObterOpcaoMenuUsuario();
            while (opcao != "X")
            {
                Console.Clear();

                try
                {
                    switch (opcao)
                    {
                        case "1":
                            ListarContas();
                            break;
                        case "2":
                            InserirConta();
                            break;
                        case "3":
                            Sacar();
                            break;
                        case "4":
                            Depositar();
                            break;
                        case "5":
                            Transferir();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Falha no sistema.");
                    Console.WriteLine("Descrição: " + ex.Message);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Pressione Enter para retornar ao menu principal...");
                    Console.ReadLine();
                }

                Console.Clear();

                opcao = ObterOpcaoMenuUsuario();
            }

            Console.WriteLine();
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.Write("Pressione Enter para finalizar a aplicação...");
            Console.ReadLine();
        }


        private static string ObterOpcaoMenuUsuario()
        {
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Sacar");
            Console.WriteLine("4- Depositar");
            Console.WriteLine("5- Transferir");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            return Console.ReadLine().ToUpper();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            Console.WriteLine();

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Console.WriteLine($"#{i} - {listContas[i]}");
            }

            Console.WriteLine();
            Console.Write("Pressione Enter para retornar...");
            Console.ReadLine();
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine();

            Console.Write("Digite 1 para conta Física ou 2 para Jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double credito = double.Parse(Console.ReadLine());

            Conta conta = new Conta((TipoConta)tipoConta, nome, saldo, credito);
            listContas.Add(conta);

            Console.WriteLine();
            Console.WriteLine("Cadastrado com sucesso!");
            Console.Write("Pressione Enter para retornar...");
            Console.ReadLine();
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valor = double.Parse(Console.ReadLine());

            Console.WriteLine();
            listContas[indice].Sacar(valor);

            Console.WriteLine();
            Console.Write("Pressione Enter para retornar...");
            Console.ReadLine();
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());

            Console.WriteLine();
            listContas[indice].Depositar(valor);

            Console.WriteLine();
            Console.Write("Pressione Enter para retornar...");
            Console.ReadLine();
        }
        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int origem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int destino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valor = double.Parse(Console.ReadLine());

            Console.WriteLine();
            listContas[origem].Transferir(valor, listContas[destino]);

            Console.WriteLine();
            Console.Write("Pressione Enter para retornar...");
            Console.ReadLine();
        }
    }
}
