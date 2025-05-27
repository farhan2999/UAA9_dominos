using System;

namespace JeuDominoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] dominos = new int[28, 2];
            int[,] joueur1 = new int[7, 2];
            int[,] joueur2 = new int[7, 2];
            int[,] stock = new int[14, 2];

            Domino domino = new Domino();
            Utilisateur Util = new Utilisateur();
            domino.GenererDominos(dominos);
            domino.MelangerDominos(dominos);
            domino.DistribuerDominos(dominos, joueur1, joueur2, stock);

            Console.WriteLine("Dominos du Joueur 1:");
            domino.AfficherDominos(joueur1);

            Console.WriteLine("Dominos du Joueur 2:");
            domino.AfficherDominos(joueur2);

            Console.WriteLine("Stock:");
            domino.AfficherDominos(stock);

            Console.Write("\nEntrez une action (jouer, piocher, passer) : ");
            string action = Console.ReadLine();
            bool resultat = Util.Utilisateurs(action);
        }
    }
}
