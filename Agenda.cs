using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO_Part2
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
    }

    public class Agenda
    {
        public List<Contato> Contatos { get; set; }

        public Agenda()
        {
            Contatos = new List<Contato>();
        }

        public void IniciarAgenda()
        {
            do
            {
                Console.WriteLine("O que deseja fazer? Adicionar contato(1); Editar contato(2); Excluir contato(3); Buscar contato(4): ");
                int escolha = Escolha();

                if (escolha == 1)
                {
                    do
                    {
                        AddContato();
                        Console.WriteLine("Deseja adicionar um novo contato? (S/N)");

                    } while (Console.ReadLine().Equals("S", StringComparison.CurrentCultureIgnoreCase));
                }
                else if (escolha == 2)
                {
                    do
                    {
                        EditContato();
                        Console.WriteLine("Deseja editar outro contato? (S/N)");

                    } while (Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase));
                }
                else if (escolha == 3)
                {
                    do
                    {
                        DeleteContato();
                        Console.WriteLine("Deseja excluir outro contato? (S/N)");

                    } while (Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    do
                    {
                        BuscarContato();
                        Console.WriteLine("Deseja buscar outro contato? (S/N)");
                    } while (Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase));
                }

                Console.WriteLine("Deseja voltar as opções?: (S/N)");
                string loop = Console.ReadLine();

                if (!loop.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    ExibirContatos();
                    break;
                }

            } while (true);
        }

        public int Escolha()
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 4)
            {
                Console.WriteLine("Escolha inválida! Tente novamente. Adicionar contato(1); Editar contato(2); Excluir contato(3); Buscar contato(4): ");
            }
            return escolha;
        }

        public void AddContato()
        {
            Console.WriteLine("Insira o nome do contato: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o número do contato: ");
            string numero = Console.ReadLine();

            Contato contato = new Contato { Nome = nome, Numero = numero };
            Contatos.Add(contato);
        }

        public void EditContato()
        {
            Console.WriteLine("Qual contato deseja editar? Digite seu nome ou número: ");
            string editarContato = Console.ReadLine();

            foreach (Contato contato in Contatos)
            {
                if (contato.Nome == editarContato || contato.Numero == editarContato)
                {
                    Console.WriteLine("O que seja editar: Nome(1) Número(2): ");
                    int editarNomeNumero = EditarNomeNumero();

                    if (editarNomeNumero == 1)
                    {
                        Console.WriteLine("Novo nome do contato: ");
                        string novoNome = Console.ReadLine();

                        contato.Nome = novoNome;
                    }
                    else
                    {
                        Console.WriteLine("Novo número do contato: ");
                        string novoNumero = Console.ReadLine();

                        contato.Numero = novoNumero;
                    }

                    Console.WriteLine("Contato editado com sucesso.");
                    return;
                }
            }

            Console.WriteLine("Contato não encontrado.");
        }

        public int EditarNomeNumero()
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 2)
            {
                Console.WriteLine("Escolha inválida! Tente novamente. Nome(1) Número(2): ");
            }
            return escolha;
        }

        public void DeleteContato()
        {
            Console.WriteLine("Qual contato deseja apagar? Digite seu nome ou número: ");
            string deleteContato = Console.ReadLine();

            for (int i = 0; i < Contatos.Count; i++)
            {
                Contato contato = Contatos[i];
                if (contato.Nome == deleteContato || contato.Numero == deleteContato)
                {
                    Contatos.RemoveAt(i);
                    Console.WriteLine("Contato removido.");
                    return;
                }
            }

            Console.WriteLine("Contato não encontrado.");
        }

        public void BuscarContato()
        {
            Console.WriteLine("Qual contato deseja buscar? Digite seu nome ou número: ");
            string buscarContato = Console.ReadLine();

            foreach (Contato contato in Contatos)
            {
                if (contato.Nome == buscarContato || contato.Numero == buscarContato)
                {
                    Console.WriteLine($"Contato encontrado: \nNome: {contato.Nome}\nNúmero: {contato.Numero}");
                    return;
                }
            }

            Console.WriteLine("Contato não encontrado.");
        }
        public void ExibirContatos()
        {
            Console.WriteLine($"\nLista de contatos atual contém {Contatos.Count} contatos:");
            foreach (Contato contato in Contatos)
            {
                Console.WriteLine($"\nNome: {contato.Nome}\nNúmero: {contato.Numero}.");
            }
        }
    }
}
