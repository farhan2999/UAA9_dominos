using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDominoConsole
{
    public struct Utilisateur
    {
   
        public bool Utilisateurs(string action )
        {
            string messageAction = "";
            int indiceDomino = -1;
            int[] dominoChoisi = null;
            bool resultat = false;
            switch (action)
            {
                case "jouer":
                    messageAction = "Action validée: Vous avez joué un domino.";
                    resultat = true;
                    break;
                case "piocher":
                    messageAction = "Action validée: Vous avez pioché un domino.";
                    resultat = true;
                    break;
                case "passer":
                    messageAction = "Action validée: Vous avez passé votre tour.";
                    resultat = true;
                    break;
            }
            return resultat;
        }
    }
}
