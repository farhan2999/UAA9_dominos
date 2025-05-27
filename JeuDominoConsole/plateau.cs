using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDominoConsole
{
    public struct plateau
    {
        public static bool PeutJouerDomino(string[] plateau, int[] dominoJoue, string position, out int[] dominoAPlacer)
        {
            dominoAPlacer = new int[2] { dominoJoue[0], dominoJoue[1] };

            if (plateau == null || plateau.Length == 0 || plateau[0] == null)
            {
                return true;
            }
            for (int iLigne = 0; iLigne < plateau.Length; iLigne++) 
            {
                dominoAPlacer[iLigne] = 0; 
            }  
        }
    }
}


