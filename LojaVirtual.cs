using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO_Part2
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
    }

    public class LojaVirtual
    {
        public string Nome { get; set; }
        public List<Produto> Carrinho { get; set; }
        public double Desconto { get; set; }
        public double ValorFinal { get; set; }

        public LojaVirtual(string nome)
        {
            Nome = nome;
            Carrinho = new List<Produto>();
        }

        public void IniciarLoja()
        {
            Console.WriteLine($"\n{Nome}\nO que você deseja fazer? Cadastrar Produto(1); Gerar Carrinho(2): ");
            double escolha = Escolha();

            if (escolha == 1)
            {
                do
                {
                    AddProduto();
                    Console.WriteLine("Deseja cadastrar um novo produto? (S/N)");
                } while (Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase));

                GerarCarrinho();
            }
            else
            {
                GerarCarrinho();
            }
        }

        public double Escolha()
        {
            double escolha;
            while (!double.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 2)
            {
                Console.WriteLine("Escolha inválida! Tente novamente. Cadastrar Produto(1); Gerar Carrinho(2): ");
            }
            return escolha;
        }

        public void AddProduto()
        {
            Console.WriteLine("Insira o nome do produto: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o valor do produto: ");
            double valor = double.Parse(Console.ReadLine());

            Produto produto = new Produto { Nome = nome, Valor = valor };
            Carrinho.Add(produto);
        }

        public void AddDesconto()
        {
            Console.WriteLine("Insira o valor do desconto: ");
            double descontoValor = double.Parse(Console.ReadLine());

            Desconto = descontoValor;
        }

        public void GerarCarrinho()
        {
            Console.WriteLine("Adicionar desconto? (S/N)");
            string escolhaDesconto = Console.ReadLine();

            if (escolhaDesconto.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                AddDesconto();
            }

            double total = 0;
            Console.WriteLine("\n");
            foreach (Produto produto in Carrinho)
            {
                Console.WriteLine($"- {produto.Nome} R${produto.Valor}");
                total += produto.Valor;
            }

            ValorFinal = total - Desconto;

            Console.WriteLine("Deseja continuar comprando? (S/N)");
            if (Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                IniciarLoja();
            }
            else
            {
                Console.WriteLine("\nEncerrando programa...");
            }
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"\nNome da loja: {Nome}");
            Console.WriteLine("Itens no carrinho:");
            foreach (Produto produto in Carrinho)
            {
                Console.WriteLine($"- {produto.Nome} R${produto.Valor}");
            }
            Console.WriteLine($"Descontos: R${Desconto}");
            Console.WriteLine($"Valor Final: R${ValorFinal}");
        }
    }
}
