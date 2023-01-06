using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco
{
    internal class Program
    {
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("------------BYTEBANK---------------------");
            Console.WriteLine();
            Console.WriteLine("[1] - Inserir novo cliente");
            Console.WriteLine("[2] - Deletar um cliente");
            Console.WriteLine("[3] - Listar todas as contas registradas");
            Console.WriteLine("[4] - Detalhes de um cliente");
            Console.WriteLine("[5] - Total armazenado no banco");
            Console.WriteLine("[6] - Manipular a conta");
            Console.WriteLine("[0] - Sair do programa");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Por favor, selecione opção desejada: ");
        }

        static void InserirUsuario(List<string> Usuarios, List<int> CPF, List<int> Senhas, List<double> Saldo)
        {
            int DadoCPF;
            Console.Clear();
            Console.Write("Nome: ");
            Usuarios.Add(Console.ReadLine());

            Console.Write("CPF: ");
            DadoCPF = int.Parse(Console.ReadLine());
            while (CPF.Contains(DadoCPF))
            {
                Console.Write("Cpf já cadastrado. Por favor digite outro: "); 
                DadoCPF = int.Parse(Console.ReadLine());
            }
            CPF.Add(DadoCPF);

            Console.Write("Senha: ");
            Senhas.Add(int.Parse(Console.ReadLine()));

            Saldo.Add(0); // colocando saldo 0
        }

        static void DeletarUsuario(List<string> Usuarios, List<int> CPF, List<int> Senhas, List<double> Saldo)
        {
            Console.Clear();
            Console.Write("Digite CPF do cliente: ");
            int DadoCPF = int.Parse(Console.ReadLine());
            int auxiliar;
            if (CPF.Contains(DadoCPF)) //verifica se o CPF existe na lista
            {
                int DadoNumUsuario = CPF.IndexOf(DadoCPF); //Pesquisa em que posição está o CPF selecionado e armazena
                do
                {

                    Console.WriteLine($"Deseja deletar cliente {Usuarios[DadoNumUsuario]}?");
                    Console.WriteLine("1- SIM   |   2 - NÃO");
                    auxiliar = int.Parse(Console.ReadLine());
                    if (auxiliar == 1)
                    {
                        Usuarios.RemoveAt(DadoNumUsuario);
                        Senhas.RemoveAt(DadoNumUsuario);
                        CPF.RemoveAt(DadoNumUsuario);
                        Saldo.RemoveAt(DadoNumUsuario);
                        Console.WriteLine("Cliente deletado.");
                        Console.WriteLine();
                        Console.WriteLine("Voltando ao menu principal");
                    }
                    else if (auxiliar == 2)
                        Console.WriteLine("Voltando ao menu principal");

                } while (auxiliar != 1 && auxiliar != 2); //enquanto a resposta for diferente de sim e não, ele vai ficar voltando
                Console.ReadKey();


            }
            else
            {
                Console.WriteLine("CPF não encontrado");
                Console.WriteLine("Voltando ao menu principal");
                Console.ReadKey();


            }

        }

        static void DetalhesUsuario(List<string> Usuarios, List<int> CPF, List<int> Senhas, List<double> Saldos)
        {
            Console.Clear();
            Console.Write("Digite a conta do cliente: ");
            int conta = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------------");
            if((conta-1) >=0 && (conta-1) < Usuarios.Count)
            {
                Console.WriteLine($"Nome: {Usuarios[conta-1]}");
                Console.WriteLine($"CPF: {CPF[conta-1]}");
                Console.WriteLine($"Senha: {Senhas[conta-1]}");
                Console.WriteLine($"Saldo: R${Saldos[conta-1]:F2}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Voltando ao menu principal");
                Console.WriteLine();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Conta não encontrada.");
                Console.WriteLine("Voltando ao menu principal");
                Console.WriteLine();
                Console.ReadKey();
            }
        }


        static void ManipularConta(List<string> Usuarios, List<int> CPF, List<int> Senhas, List<double> Saldos)
        {
            Console.Clear();
            Console.Write("Digite CPF: (Para voltar ao menu principal, digite 0): ");
            int DadoCPF, password, cont=0, opcao, conta;//cont criado para ver quantas vezes vai digitar a senha errada
            double quantia; // quantia que vai ser sacada, depositada ou transferida
            DadoCPF = int.Parse(Console.ReadLine());
            bool cpfexiste = CPF.Contains(DadoCPF); // Recebe True se o CPF existir

            while (cpfexiste == false) // verificando se cpf existe (Se a pessoa digitar 0, também vai entrar no while)
            {
                if (DadoCPF == 0)
                {
                    cpfexiste = true;
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal(Fazendo logout)");
                    Console.WriteLine();

                }
                else // Se não for 0, vai verificar se o CPF existe
                {
                    Console.Clear();
                    Console.WriteLine("CPF não encontrado");
                    Console.Write("Digite CPF: (Para voltar ao menu principal, digite 0): ");
                    DadoCPF = int.Parse(Console.ReadLine());
                    cpfexiste = CPF.Contains(DadoCPF); // Se o novo CPF digitado existir, vai sair do While, pq vai receber True

                }
            }

            if(CPF.Contains(DadoCPF)) // Verificando só por formalidade
            {
                int DadoNumUsuario = CPF.IndexOf(DadoCPF); //Pesquisa em que posição está o CPF selecionado e armazena
                Console.Write("Senha: ");
                password = int.Parse(Console.ReadLine());
                while (password != Senhas[DadoNumUsuario] && cont<2) // verifica se a senha está incorreta e quantas vezes ela já tentou
                {
                    cont++;
                    Console.WriteLine();
                    Console.WriteLine($"Senha incorreta. Você possui mais {3-cont} tentativas");
                    Console.Write("Senha: ");
                    password = int.Parse(Console.ReadLine());
                }
                if (password == Senhas[DadoNumUsuario]) cont = 0;
                if(cont==2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Tentativas encerradas. Voltando ao menu principal(Fazendo logout)");
                }
                else // Aqui que de fato vai começar as operações na conta, porque já foi verificado o CPF e senha
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Cliente: {Usuarios[DadoNumUsuario]}");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Conta: {DadoNumUsuario + 1}");
                        Console.WriteLine($"CPF: {CPF[DadoNumUsuario]}");
                        Console.WriteLine($"Saldo: R${Saldos[DadoNumUsuario]:F2}");
                        Console.WriteLine();
                        Console.WriteLine("[1] - Deposito");
                        Console.WriteLine("[2] - Saque");
                        Console.WriteLine("[3] - Transferencia");
                        Console.WriteLine("[0] - Voltar ao menu principal(Fazer logout)");
                        Console.WriteLine();
                        Console.Write("Selecione opção desejada: ");
                        opcao = int.Parse(Console.ReadLine());

                        if(opcao==0)
                        {
                            Console.WriteLine("Logout feito. Voltando ao menu principal");
                            Console.ReadKey();
                        }

                        if (opcao == 1)
                        {
                            Console.WriteLine();
                            Console.Write("Quantia a ser depositada: R$ ");
                            quantia = double.Parse(Console.ReadLine());
                            while (quantia < 0)
                            {

                                Console.WriteLine();
                                Console.WriteLine("Quantia inválida.");
                                Console.Write("Quantia a ser depositada: R$ ");
                                quantia = double.Parse(Console.ReadLine());

                            }
                            if(quantia == 0)
                            {
                                Console.WriteLine("Voltando ao menu de manipulação da conta...");
                                opcao = 4;
                                Console.ReadKey();
                            }
                            else
                            {
                                Saldos[DadoNumUsuario] += quantia;
                                Console.WriteLine();
                                Console.WriteLine("Depósito realizado.");
                                Console.WriteLine($"Novo saldo: R$ {Saldos[DadoNumUsuario]}");
                                opcao = 4;
                                Console.ReadKey(); // faz uma pausa na tela e espera o usuário digitar qualquer coisa pra continuar

                            }
                        }
                        else if(opcao == 2)
                        {
                            Console.WriteLine();
                            Console.Write("Quantia a ser retirada: R$ ");
                            quantia = double.Parse(Console.ReadLine());
                            while(quantia > Saldos[DadoNumUsuario] || quantia < 0)
                            {

                                Console.WriteLine();
                                Console.WriteLine("Quantia inválida.");
                                Console.Write("Quantia a ser retirada: R$ ");
                                quantia = double.Parse(Console.ReadLine());

                            }
                            if (quantia == 0)
                            {
                                Console.WriteLine("Voltando ao menu de manipulação da conta...");
                                opcao = 4;
                                Console.ReadKey();
                            }
                            else
                            {
                                Saldos[DadoNumUsuario] -= quantia;
                                Console.WriteLine();
                                Console.WriteLine("Saque realizado.");
                                Console.WriteLine($"Novo saldo: R$ {Saldos[DadoNumUsuario]}");
                                opcao = 4;
                                Console.ReadKey(); // faz uma pausa na tela e espera o usuário digitar qualquer coisa pra continuar

                            }

                        }
                        else if(opcao==3)
                        {
                            if (Saldos[DadoNumUsuario]==0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Conta sem saldo. Não será possível a transferencia.");
                                opcao = 4;
                                Console.ReadKey();

                            }
                            else
                            {
                                Console.WriteLine();
                                Console.Write("Para qual conta quer transferir? (Digite 0 para voltar ao menu anterior) ");
                                conta = int.Parse(Console.ReadLine());
                                while(conta > Usuarios.Count || (conta-1) == DadoNumUsuario) // verificando se a conta destinatária existe
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Conta inválida (Não existente ou sua própria).");
                                    Console.Write("Para qual conta quer transferir? (Digite 0 para voltar ao menu anterior) ");
                                    conta = int.Parse(Console.ReadLine());
                                }
                                if(conta!=0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"Destinatário: {Usuarios[conta-1]}");
                                    Console.Write("Quantia a transferir: R$ ");
                                    quantia = double.Parse(Console.ReadLine());
                                    while (quantia > Saldos[DadoNumUsuario] || quantia < 0)// Vendo se quantia é maior que o saldo
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Quantia inválida.");
                                        Console.Write("Quantia a transferir: R$ ");
                                        quantia = double.Parse(Console.ReadLine());

                                    }
                                    Saldos[conta-1] += quantia;// quantia na conta do destinatario
                                    Saldos[DadoNumUsuario] -= quantia; // quantia na conta do remetente
                                    Console.WriteLine();
                                    Console.WriteLine("Transferência realizada.");
                                    Console.WriteLine($"Saldo atual: R$ {Saldos[DadoNumUsuario]}");
                                    Console.ReadKey();

                                }
                                else // se a pessoa digitou zero
                                {
                                    Console.WriteLine("Voltando ao menu de manipulação da conta...");
                                    opcao = 4;
                                    Console.ReadKey();

                                }

                            }
                        }


                    } while (opcao < 0 || opcao > 3); // Vai ficar voltando enquanto a opção for inválida

                }
            }

        }


        static void Main(string[] args)
        {
            List<string> Usuarios = new List<string>();
            List<int> CPF = new List<int>();
            List<int> Senhas = new List<int>();
            List<double> Saldo = new List<double>();


            int opcao = 0;

            Console.BackgroundColor = ConsoleColor.Cyan; // colocando fundo ciano no terminal
            Console.ForegroundColor = ConsoleColor.Black; // deixando as letras pretas
            Console.Clear();


            do
            {
                ShowMenu();
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        Console.WriteLine();
                        break;

                    case 1:
                        InserirUsuario(Usuarios, CPF, Senhas, Saldo);
                        break;

                    case 2:
                        DeletarUsuario(Usuarios, CPF, Senhas, Saldo);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Listando contas registradas:");
                        Console.WriteLine();
                        for(int i=0; i < Usuarios.Count; i++)
                        {
                            Console.WriteLine($"{i+1} - Nome: {Usuarios[i]}   |   Cpf: {CPF[i]}     | Saldo:R$ {Saldo[i]:F2}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Voltando ao menu principal");
                        Console.WriteLine();
                        Console.ReadKey();
                        break;

                    case 4:
                        DetalhesUsuario(Usuarios, CPF, Senhas, Saldo);
                        break;

                    case 5:
                        double total = Saldo.Sum();
                        Console.Clear();
                        Console.Write("Saldo total do banco: R$ ");
                        Console.WriteLine($"{total:f2}");
                        Console.WriteLine();
                        Console.WriteLine($"Saldo proveniente de {Usuarios.Count} contas");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Voltando ao menu principal...");
                        Console.WriteLine();
                        Console.ReadKey();
                        break;

                    case 6:
                        ManipularConta(Usuarios, CPF, Senhas, Saldo);
                        break;


                }

            } while (opcao!=0);

        }
    }
}
