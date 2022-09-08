using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace AgendaRevisao
{
    internal class Program
    {
        static int Menu()
        {
            int opc;
            Console.Write("\n 0-Sair\n1-Adicionar\n2-Remover\n3-Buscar\n4-Editar\n5-Imprimir contatos\n6-Imprimir contato único \nEscolha uma opção: ");
            return opc = int.Parse(Console.ReadLine());
        }
        static Pessoa AdicionarContato(List<Pessoa> agendaContatos)
        {
            Pessoa contato = new();
            Console.Write("NOME: ");
            string nome = Console.ReadLine();
            Console.Write("TELEFONE: ");
            string telefone = Console.ReadLine();
            Console.Write("EMAIL: ");
            string email = Console.ReadLine();
            Console.Write("DATA DE ANIVERSÁRIO ");
            DateTime aniversario = DateTime.Parse(Console.ReadLine());
            contato.CadastrarPessoa(nome, telefone, email, aniversario);
            contato.CadastrarPessoa(nome, telefone, email, aniversario);
            Console.WriteLine(contato.ToString());
            agendaContatos.Add(contato);
            return contato;
        }
        static void RemoverContato(List<Pessoa> agendaContato)
        {
            if (agendaContato.Count == 0)
            {
                Console.WriteLine("AGENDA VAZIA, IMPOSSÍVEL REMOVER!");
            }
            else
            {
                Console.Write("Informe o nome: ");
                string nome = Console.ReadLine();
                Pessoa p = BuscarContato(agendaContato, nome);
                agendaContato.Remove(p);
            }
        }
        static Pessoa BuscarContato(List<Pessoa> agendaContatos, string nome)
        {
            Pessoa p = new();
            if (agendaContatos.Count == 0)
            {
                Console.WriteLine("AGENDA VAZIA, IMPOSSÍVEL BUSCAR!");
                return p;
            }
            else
            {
                bool achei = false;
               
                foreach (Pessoa item in agendaContatos)
                {
                    if (item.Nome == nome)
                    {
                        achei = true;
                        p = item;
                        return p;//p do nome da pessoa, foi encontrado, está dentro do foreach
                    }
                }
                if (achei)
                {
                    Console.WriteLine(nome + " não encontrado!");
                }
                return p;//p vazio, já q está fora do foreach
            }
        }
        static void EditarContato(List<Pessoa> agendaContato)
        {
            if (agendaContato.Count == 0)
            {
                Console.WriteLine("AGENDA VAZIA, IMPOSSÍVEL EDITAR!");
            }
            else
            {
                Console.WriteLine("Informe o nome para busca: ");
                string nome = Console.ReadLine();
                Pessoa p = BuscarContato(agendaContato, nome);
                Console.WriteLine("1 - Editar Nome");
                Console.WriteLine("2 - Editar Email");
                Console.WriteLine("3 - Editar Telefone");
                Console.WriteLine("4 - Editar Aniversário");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Informe o NOVO NOME:");
                        nome = Console.ReadLine();
                        p.Nome = nome;
                        break;
                    case 2:
                        Console.WriteLine("Informe o NOVO EMAIL:");
                        string email = Console.ReadLine();
                        p.Email = email;
                        break;
                    case 3:
                        Console.WriteLine("Informe o NOVO TELEFONE:");
                        string telefone = Console.ReadLine();
                        p.Telefone = telefone;
                        break;
                    case 4:
                        Console.WriteLine("Informe o NOVO ANIVERSÁRIO:");
                        DateTime aniversario = DateTime.Parse(Console.ReadLine());
                        p.Aniversario = aniversario;
                        break;
                    default:
                        Console.Write("Opção de edição inválida!");
                        break;


                }
            }
        }
        static void ImprimirContatos(List<Pessoa> agendaContatos)
        {
            if (agendaContatos.Count == 0)
            {
                Console.WriteLine("AGENDA VAZIA, IMPOSSÍVEL IMPRIMIR!");
            }
            else
            {
                foreach (Pessoa item in agendaContatos)
                {
                    // Console.WriteLine(item.ToString());
                    ImprimirContato(item);
                }
            }
        }
        static void ImprimirContato(Pessoa contato)
        {
            Console.WriteLine(contato.ToString());
        }

        static void Main(string[] args)
        {
            List<Pessoa> agendaContatos = new();//criando listas de classes, fazendo uma relação entre as classes
            Pessoa contato = new Pessoa();//criando um objeto
            Console.WriteLine(">>> AGENDA DE CONTATOS <<<");
            int op;
            do
            {
                op = Menu();

                switch (op)
                {
                    case 0:
                        Environment.Exit(0);//encerra o programa por inteiro
                        break;
                    case 1:
                        contato = AdicionarContato(agendaContatos);
                        break;
                    case 2:

                        RemoverContato(agendaContatos);
                        break;
                    case 3:
                        Console.WriteLine("Informe o nome que deseja buscar:");//poderia deixar dentro da função aí eu não passaria o nome como parâmetro
                        string name = Console.ReadLine();
                        BuscarContato(agendaContatos, name);
                        break;
                    case 4:
                        EditarContato(agendaContatos);
                        break;
                    case 5:
                        ImprimirContatos(agendaContatos);
                        break;
                    case 6:
                        Console.WriteLine("Informe o nome que deseja buscar:");
                        name = Console.ReadLine();
                        ImprimirContato(BuscarContato(agendaContatos, name));
                        break;
                    default:
                        Console.Write("Opção inválida!");
                        break;

                }
            } while (true);
        }
    }
}
