using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDominoConsole
{
    public struct Utilisateur
    {
        
        public bool Utilisateurs(string action)
        {
            switch (action.ToLower())
            {
                case "j":
                case "p":
                case "s":
                    return true;
                default:
                    return false;
            }
        }
    }
}
