using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDominoConsole
{

    public struct Plateau
    {
        
        public static bool PeutJouerDomino(
            List<int[]> plateau,
            int[] dominoJoue,
            string position,
            out int[] dominoAPlacer)
        {
            dominoAPlacer = new int[2] { dominoJoue[0], dominoJoue[1] };

            if (plateau.Count == 0)
                return true;

            int[] extremiteGauche = plateau[0];
            int[] extremiteDroite = plateau[plateau.Count - 1];

            if (position.ToLower() == "g")
            {
                
                if (dominoJoue[1] == extremiteGauche[0])
                {
                    return true;
                }
                else if (dominoJoue[0] == extremiteGauche[0])
                {
                    dominoAPlacer = new int[] { dominoJoue[1], dominoJoue[0] };
                    return true;
                }
            }
            else if (position.ToLower() == "d")
            {
                
                if (dominoJoue[0] == extremiteDroite[1])
                {
                    
                    return true;
                }
                else if (dominoJoue[1] == extremiteDroite[1])
                {
                    dominoAPlacer = new int[] { dominoJoue[1], dominoJoue[0] };
                    return true;
                }
            }

            return false;
        }

    }
}


