using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO_Part2
{
    public class JogoAdivinhacao
    {
        private int numeroSecreto;
        private bool jogoAtivo;

        public JogoAdivinhacao()
        {
            Random random = new Random();
            numeroSecreto = random.Next(1, 101);
            jogoAtivo = true;
        }

        public void IniciarJogo()
        {
            do
            {
                Console.WriteLine("Tente adivinhar o número secreto (entre 1 e 100):");
                int palpite = int.Parse(Console.ReadLine());

                if (palpite == numeroSecreto)
                {
                    Console.WriteLine("Parabéns! Você acertou o número secreto.");
                    jogoAtivo = false;
                }
                else if (palpite < numeroSecreto)
                {
                    Console.WriteLine("O número secreto é maior que o seu palpite.");
                }
                else
                {
                    Console.WriteLine("O número secreto é menor que o seu palpite.");
                }

                Console.WriteLine("Deseja continuar jogando? (S/N)");
            } while (jogoAtivo && Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase));
        }
    }
}
