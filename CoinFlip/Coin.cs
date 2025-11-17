using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoinFlip
{
    class Coin
    {
        private string ladoSorteado = "cara";

        public string LadoSorteado { get => ladoSorteado; set => ladoSorteado = value; }
        

        public Coin() { 

        }

        

        public string Flip()
        {
            Random sortear = new Random();
            if (sortear.Next(2) == 0)
            {
                LadoSorteado = "cara";
            }
            else {
                LadoSorteado = "coroa";
            }
            
            return ladoSorteado;
            //ladoSorteado = (sortear.Next(2) == 1) ? "cara" : "coroa";
        }



    }
}
