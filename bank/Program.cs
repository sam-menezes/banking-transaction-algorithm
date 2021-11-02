using System;
using System.Collections.Generic;

namespace bank
{
    class Program
    {
         static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string user = menu();

            while( user.ToUpper() != "X")
            {
                switch(user)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Trasferir();
                        break;
                    case "4":
                       Sacar();
                        break;
                    case "5":
                       Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                  
                    default:
                        throw new ArgumentOutOfRangeException();
                
                }
                user = menu();
            }
            Console.WriteLine("Obrigado por utilizar!!");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int inidiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[inidiceConta].Depositar(valorDeposito);

        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Trasferir()
        {
           Console.Write("Digite o número da conta de origem: ");
           int indiceContaOrigem = int.Parse(Console.ReadLine());

           Console.Write("Digite o número da conta de destino: ");
           int indiceContaDestino = int.Parse(Console.ReadLine());

           Console.Write("Digite o valor a ser trasnferido: ");
           double valorTrasferencia = double.Parse(Console.ReadLine());

           listContas[indiceContaOrigem].Transferir(valorTrasferencia, listContas[indiceContaDestino]);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");


            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} . ", i);
                Console.WriteLine(conta);
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine("Iserir nova cocnta");

            Console.WriteLine("Digite o tipo de conta '1' ou '2': ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do CLiente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                        saldo: entradaSaldo,
                                                        credito: entradaCredito,
                                                        nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static string menu()
            {
                Console.WriteLine();
                Console.WriteLine("Test Bank!!!");
                Console.WriteLine("Informe a opção...");

                Console.WriteLine("1 - Listar Contas");
                Console.WriteLine("2 - Inserir Nova Conta");
                Console.WriteLine("3 - Trasferir");
                Console.WriteLine("4 - Sacar");
                Console.WriteLine("5 - Depositar");
                Console.WriteLine("C - Limpar tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string user = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return user;

            }
    }
}
