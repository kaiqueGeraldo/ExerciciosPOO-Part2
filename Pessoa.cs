using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO_Part2
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Profissao { get; set; }

        public Pessoa(string nome, int idade, string profissao)
        {
            Nome = nome;
            Idade = idade;
            Profissao = profissao;
        }

        public object CalcularIdadeAnoBixssexto()
        {
            double idadeAnoBixssexto = Idade / 4;
            return idadeAnoBixssexto;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"\nNome: {Nome}");
            Console.WriteLine($"Idade: {Idade}");
            Console.WriteLine($"Em anos bixssextos {Nome} tem {CalcularIdadeAnoBixssexto()} anos.");
            Console.WriteLine($"Profissão: {Profissao}");
        }
    }
}
