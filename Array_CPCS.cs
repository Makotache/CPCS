using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class Array_CPCS
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableau">Tableau en 2 dimensions</param>
        /// <returns>Un élément pris au hasard</returns>
        public static Object GetRandomElement(Array[][] tableau)
        {
            if(tableau.Length == 0 || tableau[0].Length == 0)
            {
                throw new ArgumentException("La taille des ligne ou des colonnes du tableau dois être supérieur à 0.");
            }

            Random aleatoire = new Random();
            int ligne = aleatoire.Next(tableau.Length);
            int colonne = aleatoire.Next(tableau[0].Length);

            return tableau[ligne][colonne];
        }
    }
}
