using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDominoConsole
{
    public struct Domino
    {
        public void GenererDominos(List<int[]> dominos)
        {
            dominos.Clear();
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    dominos.Add(new int[] { i, j });
                }
            }
        }

        public void MelangerDominos(List<int[]> dominos)
        {
            Random alea = new Random();
            for (int i = dominos.Count - 1; i > 0; i--)
            {
                int j = alea.Next(i + 1);
                int[] tmp = dominos[i];
                dominos[i] = dominos[j];
                dominos[j] = tmp;
            }
        }

        public void DistribuerDominos(
            List<int[]> pioche,
            List<int[]> main1,
            List<int[]> main2,
            List<int[]> stock)
        {
            main1.Clear();
            main2.Clear();
            stock.Clear();

            for (int i = 0; i < 7; i++)
            {
                main1.Add(pioche[i]);
                main2.Add(pioche[i + 7]);
            }
            for (int i = 14; i < pioche.Count; i++)
            {
                stock.Add(pioche[i]);
            }
        }

        public void AfficherDominos(List<int[]> liste)
        {
            for (int i = 0; i < liste.Count; i++)
            {
                Console.Write("(" + i + ") ");
                Console.Write("[" + liste[i][0] + "|" + liste[i][1] + "] ");

            }
            Console.WriteLine();
        }

        
        public void AfficherPlateau(List<int[]> plateau)
        {
            if (plateau.Count == 0)
            {
                Console.WriteLine("Plateau vide.");
            }
            else
            {
                for (int i = 0; i < plateau.Count; i++)
                {
                    Console.Write("[" + plateau[i][0] + "|" + plateau[i][1] + "] ");
                }
                Console.WriteLine();
            }
        }
    }

}
