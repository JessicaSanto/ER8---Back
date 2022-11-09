using System;
using System.Threading;
using System.Collections.Generic;


namespace AulaBackT9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PessoaFisica> listaPf = new List<PessoaFisica>();
            Console.Clear();

            List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();
            Console.Clear();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(@$"
        ======================================
        |   Bem-vindo ao sistema de cadastro |
        |   de pessoa física e jurídica      |
        ======================================
        ");

            BarraCarregamento("Iniciando");

            string? opcao;
            do

            {

                Console.WriteLine(@$"
        ===========================================
        |      Escolha uma das opções abaixo:     |
        -------------------------------------------
        |              PESSOA FÍSICA              |
        |       1 - Cadastrar Pessoa Física       |            
        |       2 - Listas Pessoa Física          |   
        |       3 - Remover Pessoa Física         |
        |                                         |
        -------------------------------------------
        |              PESSOA JURÍDICA            |
        |       4 - Cadastrar Pessoa Jurídica     |
        |       5 - Listar Pessoa Jurídica        |
        |       6 - Remover Pessoa Juridíca       |
        |                                         |
        |              0 - Sair                   |
        ===========================================    
            ");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":

                        Endereco end = new Endereco();

                        Console.WriteLine($"Digite o seu logradouro");
                        end.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número do seu endereço");
                        end.numero = Console.ReadLine();

                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        end.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endComercial = Console.ReadLine().ToUpper();

                        if (endComercial == "S")
                        {
                            end.enderecoComercial = true;
                        }
                        else
                        {

                            end.enderecoComercial = false;
                        }

                        // end.logradouro = "Rua X";
                        // end.numero = 100;
                        // end.complemento = "Próximo ao mercado";
                        // end.enderecoComercial = false;

                        PessoaFisica novapf = new PessoaFisica();

                        novapf.endereco = end;

                        Console.WriteLine($"Digite seu CPF (somente números");
                        novapf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o seu nome");
                        novapf.nome = Console.ReadLine();

                        Console.WriteLine($"Digite sua data de nascimento");
                        novapf.dataNascimento = DateTime.Parse(Console.ReadLine());

                        bool idadeValida = novapf.ValidarDataNascimento(novapf.dataNascimento);
                        Console.WriteLine(idadeValida);

                        if (idadeValida == true)
                        {
                            Console.WriteLine($"Cadastro Aprovado");
                            listaPf.Add(novapf);
                            Console.WriteLine(novapf.PagarImposto(novapf.rendimento));

                        }
                        else
                        {
                            Console.WriteLine($"Cadastro Não Aprovado");
                        }

                        Console.WriteLine($"Digite o valor do seu rendimento mensal");
                        novapf.rendimento = float.Parse(Console.ReadLine());

                        // novapf.endereco = end;
                        // novapf.cpf = "1234567";
                        // novapf.nome = "Pessoa Fisica";
                        // novapf.dataNascimento = new DateTime(2022, 02, 20);


                        break;

                    case "2":

                        foreach (var cadaItem in listaPf)
                        {
                            Console.WriteLine($"{cadaItem.nome}, {cadaItem.cpf}, {cadaItem.dataNascimento}, {cadaItem.endereco.logradouro}");
                        }

                        break;

                    case "3":

                        Console.WriteLine($"Digite o CPF que você deseja remover");
                        string cpfProcurado = Console.ReadLine();

                        PessoaFisica pessoaEncontrada = listaPf.Find(cadaItem => cadaItem.cpf == cpfProcurado);

                        if (pessoaEncontrada != null)
                        {
                            listaPf.Remove(pessoaEncontrada);
                            Console.WriteLine($"Cadastro foi removido");
                        }
                        else
                        {
                            Console.WriteLine($"CPF não encontrado");
                        }

                        break;

                    case "4":

                        Endereco endPj = new Endereco();

                        Console.WriteLine($"Digite o seu logradouro");
                        endPj.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número do seu endereço");
                        endPj.numero = Console.ReadLine();

                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        endPj.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endComercialPj = Console.ReadLine().ToUpper();

                        if (endComercialPj == "S")
                        {
                            endPj.enderecoComercial = true;
                        }
                        else
                        {

                            endPj.enderecoComercial = false;
                        }

                        // endPj.logradouro = "Rua I";
                        // endPj.numero = "100";
                        // endPj.complemento = "Próximo ao Senai";
                        // endPj.enderecoComercial = false;

                        PessoaJuridica novapj = new PessoaJuridica();

                        Console.WriteLine($"Digite o nome da sua empresa");
                        novapj.nome = Console.ReadLine();

                        Console.WriteLine($"Digite o seu CNPJ");
                        novapj.cnpj = Console.ReadLine();

                        novapj.endereco = endPj;

                        Console.WriteLine($"Digite sua razão social");
                        novapj.razaoSocial = Console.ReadLine();

                        // novapj.nome = "Jessica LTDA";
                        // novapj.cnpj = "12345678910001";
                        // novapj.endereco = endPj;
                        // novapj.razaoSocial = "Jessica Santo";


                        if (novapj.ValidarCNPJ(novapj.cnpj))
                        {
                            Console.WriteLine($"O CNPJ {novapj.cnpj} está Válido");
                        }
                        else
                        {
                            Console.WriteLine("O CNPJ" + novapj.cnpj + "está Inválido");
                        }

                        break;

                    case "5":

                        foreach (var cadaItemPj in listaPJ)
                        {
                            Console.WriteLine($"{cadaItemPj.nome}, {cadaItemPj.cnpj}, {cadaItemPj.razaoSocial}");
                        }

                        break;

                    case "6":

                        Console.WriteLine($"Digite o CNPJ que você deseja remover");

                        string cnpjProcurado = Console.ReadLine();

                        PessoaJuridica pessoajuridicaEncontrada = listaPJ.Find(cadaItemPj => cadaItemPj.cnpj == cnpjProcurado);

                        if (pessoajuridicaEncontrada != null)
                        {
                            listaPJ.Remove(pessoajuridicaEncontrada);
                            Console.WriteLine($"Cadastro foi removido");
                        }
                        else
                        {
                            Console.WriteLine($"CNPJ não encontrado");
                        }

                        break;

                    case "0":

                        BarraCarregamento("Finalizando");

                        break;

                    default:
                        Console.WriteLine($"Opção inválido, digite uma opção válida");
                        break;
                }

            } while (opcao != "0");


            static void BarraCarregamento(string textoCarregamento)
            {

                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(textoCarregamento);
                Thread.Sleep(500);

                for (int contador = 0; contador < 5; contador++)
                {

                    Console.Write(".");
                    Thread.Sleep(500);
                }

                Console.ResetColor();


            }
        }
    }
}

