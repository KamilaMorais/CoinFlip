using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlip
{
    internal class Game
    {
        private int total;
        private int sequencia;

        public int Total { get => total; set => total = value; }
        public int Sequencia { get => sequencia; set => sequencia = value; }
        
        public Game()
        {
            total = 0;
            sequencia = 0;
        }

        public Boolean CheckWinner(int escolhido, int vencedor)
        {
            if(escolhido == vencedor)
            {
                total++;
                sequencia++;
                return true;
            }
            else
            {
                sequencia = 0;
                return false;
            }
        }

        public void reset()
        {
            total = 0;
            sequencia = 0;
        }

    }
}
