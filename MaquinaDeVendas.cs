using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO_Part2
{
    public class MaquinaDeVendas
    {
        public List<Produto> Produtos { get; set; }
        public double DinheiroInserido { get; set; }

        public MaquinaDeVendas()
        {
            Produtos = new List<Produto>();
            DinheiroInserido = 0;
        }

        public void IniciarMaquina()
        {
            do
            {
                Console.WriteLine("\nMáquina de vendas.\nO que você deseja fazer?: Cadastrar produto(1); Comprar Produto(2); Inserir Dinheiro(3); Exibir Estoque(4); Encerrar(5): ");
                int escolha = Escolha();

                if (escolha == 1)
                {
                    CadastrarProduto();
                }
                else if (escolha == 2)
                {
                    SelecionarProdutoCompra();
                }
                else if (escolha == 3)
                {
                    InserirDinheiro();
                }
                else if (escolha == 4)
                {
                    ExibirEstoque();
                }
                else
                {
                    Console.WriteLine("Encerrando programa...");
                    break;
                }

            } while (true);
        }

        private int Escolha()
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 5)
            {
                Console.WriteLine("Escolha inválida! Tente novamente.");
            }
            return escolha;
        }

        private void CadastrarProduto()
        {
            Console.WriteLine("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o valor do produto:");
            double valor = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade em estoque:");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto = new Produto { Nome = nome, Valor = valor, Quantidade = quantidade };
            Produtos.Add(produto);

            Console.WriteLine($"Produto '{nome}' cadastrado com sucesso.");
        }

        private void SelecionarProdutoCompra()
        {
            Console.WriteLine("Produtos disponíveis:\n");
            for (int i = 0; i < Produtos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Produtos[i].Nome} - R${Produtos[i].Valor} - Estoque: {Produtos[i].Quantidade}");
            }

            Console.WriteLine("Digite o número do produto que deseja comprar: ");
            int escolha = int.Parse(Console.ReadLine());

            if (escolha >= 1 && escolha <= Produtos.Count)
            {
                Produto produtoSelecionado = Produtos[escolha - 1];
                if (produtoSelecionado.Quantidade > 0)
                {
                    if (DinheiroInserido >= produtoSelecionado.Valor)
                    {
                        DinheiroInserido -= produtoSelecionado.Valor;
                        produtoSelecionado.Quantidade--;
                        Console.WriteLine($"Compra realizada com sucesso! Retire {produtoSelecionado.Nome}.");
                        Console.WriteLine($"Seu troco: R${DinheiroInserido}.");
                    }
                    else
                    {
                        Console.WriteLine("Dinheiro insuficiente.");
                    }
                }
                else
                {
                    Console.WriteLine("Produto indisponível no estoque.");
                }
            }
            else
            {
                Console.WriteLine("Escolha inválida!");
            }
        }

        private void InserirDinheiro()
        {
            Console.WriteLine("Digite o valor a ser inserido na máquina: ");
            double valor = double.Parse(Console.ReadLine());
            DinheiroInserido += valor;
            Console.WriteLine($"Dinheiro inserido: R${DinheiroInserido}");
        }

        private void ExibirEstoque()
        {
            Console.WriteLine("\nEstoque disponível:");
            foreach (var produto in Produtos)
            {
                Console.WriteLine($"\n-{produto.Nome} - R${produto.Valor} - Estoque: {produto.Quantidade}");
            }
        }
    }
}