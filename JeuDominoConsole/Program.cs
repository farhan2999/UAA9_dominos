using System;

namespace JeuDominoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int[]> piocheTotale = new List<int[]>();   
            List<int[]> mainJoueur1 = new List<int[]>();   
            List<int[]> mainJoueur2 = new List<int[]>();  
            List<int[]> stock = new List<int[]>();         
            List<int[]> plateau = new List<int[]>();       

            Domino domino = new Domino();
            Utilisateur util = new Utilisateur();

            domino.GenererDominos(piocheTotale);
            domino.MelangerDominos(piocheTotale);

            domino.DistribuerDominos(piocheTotale, mainJoueur1, mainJoueur2, stock);

            int joueurActuel = 1;
            bool partieTerminee = false;

            while (!partieTerminee)
            {
                Console.Clear();
                Console.WriteLine("------------Jeu de Dominos----------------");
                Console.WriteLine();

                Console.WriteLine("Plateau:");
                domino.AfficherPlateau(plateau);
                Console.WriteLine();

                if (joueurActuel == 1)
                {
                    Console.WriteLine("Main Joueur 1:");
                    domino.AfficherDominos(mainJoueur1);
                }
                else
                {
                    Console.WriteLine("Main Joueur 2:");
                    domino.AfficherDominos(mainJoueur2);
                }
                Console.WriteLine();

                bool coupPossible = false;
                List<int[]> mainActuelle = (joueurActuel == 1) ? mainJoueur1 : mainJoueur2;
                for (int i = 0; i < mainActuelle.Count; i++)
                {
                    int[] d = mainActuelle[i];
                    int[] tmp;
                    if (Plateau.PeutJouerDomino(plateau, d, "g", out tmp) ||
                        Plateau.PeutJouerDomino(plateau, d, "d", out tmp))
                    {
                        coupPossible = true;
                        break;
                    }
                }

                if (!coupPossible && stock.Count == 0)
                {
                    Console.WriteLine("Impossible de bouger et le stock est vide. Partie bloquée !");
                    partieTerminee = true;
                    break;
                }

                if (!coupPossible && stock.Count > 0)
                {
                    Console.WriteLine("Joueur " + joueurActuel + ", impossible de bouger : vous devez piocher.");
                    int[] dominoPioche = stock[0];
                    stock.RemoveAt(0);
                    mainActuelle.Add(dominoPioche);
                    Console.WriteLine("Vous piochez [" + dominoPioche[0] + "|" + dominoPioche[1] + "].");
                    Console.WriteLine("Appuyez sur Entrée pour continuer...");
                    Console.ReadLine();
                    continue;
                }

                Console.Write("Joueur " + joueurActuel + ", que voulez-vous faire ? (jouer(j), piocher(p) ou passer(s) : ");
                string action = Console.ReadLine().ToLower();

                if (!util.Utilisateurs(action))
                {
                    Console.WriteLine("Action inconnue. Tapez \"jouer(j)\", \"piocher(p)\" ou \"passer(s)\".");
                    Console.WriteLine("Appuyez sur Entrée pour réessayer...");
                    Console.ReadLine();
                    continue;
                }

                if (action == "p")
                {
                    if (stock.Count == 0)
                    {
                        Console.WriteLine("Le stock est vide, vous ne pouvez pas piocher.");
                        Console.WriteLine("Appuyez sur Entrée pour continuer...");
                        Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        int[] dominoPioche = stock[0];
                        stock.RemoveAt(0);
                        mainActuelle.Add(dominoPioche);
                        Console.WriteLine("Vous avez pioché [" + dominoPioche[0] + "|" + dominoPioche[1] + "].");
                        Console.WriteLine("Appuyez sur Entrée pour passer votre tour...");
                        Console.ReadLine();
                        joueurActuel = (joueurActuel == 1) ? 2 : 1;
                        continue;
                    }
                }
                else if (action == "s")
                {
                    Console.WriteLine("Joueur " + joueurActuel + " passe son tour.");
                    Console.WriteLine("Appuyez sur Entrée pour continuer...");
                    Console.ReadLine();
                    joueurActuel = (joueurActuel == 1) ? 2 : 1;
                    continue;
                }
                else if (action == "j")
                {
                    Console.Write("Entrez l'indice du domino dans votre main à jouer : ");
                    string saisie = Console.ReadLine();
                    int indiceDomino = int.Parse(saisie);
                    int[] dominoChoisi = mainActuelle[indiceDomino];



                    Console.Write("Voulez-vous le poser à gauche ou à droite du plateau ? (gauche(g)/droite(d)) : ");
                    string position = Console.ReadLine().ToLower();
                    if (position != "g" && position != "d")
                    {
                        Console.WriteLine("Position invalide. Appuyez sur Entrée pour recommencer...");
                        Console.ReadLine();
                        continue;
                    }

                    int[] dominoAPlacer;
                    bool peut = Plateau.PeutJouerDomino(plateau, dominoChoisi, position, out dominoAPlacer);
                    if (!peut)
                    {
                        Console.WriteLine("Vous ne pouvez pas poser ce domino à cet endroit. Appuyez sur Entrée pour réessayer...");
                        Console.ReadLine();
                        continue;
                    }

                    mainActuelle.RemoveAt(indiceDomino);
                    if (plateau.Count == 0)
                    {
                        plateau.Add(dominoAPlacer);
                    }
                    else if (position == "g")
                    {
                        plateau.Insert(0, dominoAPlacer);
                    }
                    else 
                    {
                        plateau.Add(dominoAPlacer);
                    }

                    if (mainActuelle.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Joueur " + joueurActuel + " a posé son dernier domino et gagne la partie !");
                        Console.WriteLine();

                        break;
                    }

                    joueurActuel = (joueurActuel == 1) ? 2 : 1;
                    continue;
                }
            }


            if (!partieTerminee)
            {
                Console.WriteLine();
                Console.WriteLine("Appuyez sur Entrée pour quitter...");
                Console.ReadLine();
            }
        }
    }
}
