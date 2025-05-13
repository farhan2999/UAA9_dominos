using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDominoConsole
{
    public struct Domino
    {
        public void GenererDominos()
        {
            int[,] dominos = new int[28,2];
            int k = 0;
            for (int j = 0; j <= 6; j++)
            {
                for (int i = j; i <= 6; i++)
                {
                    dominos[k, 0] = j;
                    dominos[k,1] = i;
                    k++;
                }
            }
        }
        public void Melanger()
        {

        }

    }
}
