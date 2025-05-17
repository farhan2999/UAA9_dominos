using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDominoConsole
{
    public struct Domino
    {
        public void GenererDominos(int[,] dominos)
        {
            int k = 0;
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    dominos[k, 0] = i;
                    dominos[k, 1] = j;
                    k++;
                }
            }
        }

        public void MelangerDominos(int[,] dominos)
        {
            Random alea = new Random();
            for (int i = 27; i > 0; i--)
            {
                int j = alea.Next(i + 1);
                int a = dominos[i, 0];
                int b = dominos[i, 1];

                dominos[i, 0] = dominos[j, 0];
                dominos[i, 1] = dominos[j, 1];

                dominos[j, 0] = a;
                dominos[j, 1] = b;
            }
        }

        public void DistribuerDominos(int[,] dominos, int[,] joueur1, int[,] joueur2, int[,] stock)
        {
            for (int i = 0; i < 7; i++)
            {
                joueur1[i, 0] = dominos[i, 0];
                joueur1[i, 1] = dominos[i, 1];

                joueur2[i, 0] = dominos[i + 7, 0];
                joueur2[i, 1] = dominos[i + 7, 1];
            }

            for (int i = 0; i < 14; i++)
            {
                stock[i, 0] = dominos[i + 14, 0];
                stock[i, 1] = dominos[i + 14, 1];
            }
        }

        public void AfficherDominos(int[,] dominos)
        {
            for (int i = 0; i < dominos.GetLength(0); i++)
            {
                Console.Write("[" + dominos[i, 0] + "|" + dominos[i, 1] + "] ");
            }
            Console.WriteLine();
        }

    }
}
