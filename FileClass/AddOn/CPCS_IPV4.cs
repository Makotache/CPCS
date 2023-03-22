using CPCS.Linq.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CPCS
{
    public static class CPCS_IPV4
    {
        public static bool ValideIp(string chaine)
        {
            string base_pattern = "(25[0-4]|2[0-4][0-9]|[01]?[0-9][0-9]?)";
            string pattern = @"\b" + base_pattern + @"\." + base_pattern + @"\." + base_pattern + @"\." + base_pattern + @"\b";
            //Console.WriteLine(pattern);

            char[] chiffre = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.' };
            char[] chaineArray = chaine.ToArray();
            bool[] chaineArrayValide = new bool[chaine.Length];

            //on vérifie que tout les caractères de l'ip sont correctes
            for (int i = 0; i < chaineArray.Length; i++)
            {
                for (int u = 0; u < chiffre.Length; u++)
                {
                    if (chaineArray[i].Equals(chiffre[u]))
                    {
                        chaineArrayValide[i] = true;
                        break;
                    }
                }

                //si autre chose que chiffres et points est présent
                if (!chaineArrayValide[i])
                { return false; }
            }

            //si la 'chaine' correspond un minimum au format d'une ip
            if (Regex.IsMatch(chaine, pattern))
            {
                //si la 'chaine' possède bien 4 octets
                if (chaine.Split('.').Length == 4)
                {
                    int[] octets = chaine.Split('.').StrArrayToIntArray();
                    if (octets[0] == 0)
                    { return false; }

                    for (int i = 0; i < 4; i++)
                    {
                        //sinon la taille des octets fait 1, 2 ou 3 caractère et est inférieur à 255 
                        if (octets[i].ToString().Length < 1 || octets[i].ToString().Length > 3 || octets[i] > 254)
                        { return false; }
                    }
                    return true;
                }
                //sinon false
            }
            return false;
        }
    }
}
