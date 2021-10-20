using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class String_CPCS
    {
        public static bool ChaineContiensChaine(string chaine_a_verifier, string avec_celle_ci, bool IgnoreMajuscule)
        {
            if (IgnoreMajuscule)
            {
                return chaine_a_verifier.IndexOf(avec_celle_ci, StringComparison.OrdinalIgnoreCase) > -1;
            }
            else
            {
                return chaine_a_verifier.IndexOf(avec_celle_ci) > -1;
            }
        }
    }
}
