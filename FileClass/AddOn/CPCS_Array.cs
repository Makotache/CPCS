using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class CPCS_Array
    {
        /// <summary>
        /// Change l'obj similaire a celui dans le tableau par le nouvel_objet.
        /// </summary>
        /// <param name="tableau">Le Tableau dans le quel on effectue la supression</param>
        /// <param name="obj">Objet à supprimer.</param>
        /// <returns>True si réussi sinon false.</returns>
        public static bool ChangeAllSimilarObject(object[,] tableau, object obj, object nouvel_objet)
        {
            if (tableau.GetLength(0) == 0 || tableau.GetLength(1) == 0)
            {
                throw new ArgumentException("La taille des ligne ou des colonnes du tableau dois être supérieur à 0.");
            }

            bool suppresion_reussi = false;
            for (int i = 0; i < tableau.GetLength(1); i++)//colonne
            {
                for (int u = 0; i < tableau.GetLength(0); i++)//ligne
                {
                    if (tableau[u, i] == obj)
                    {
                        tableau[u, i] = nouvel_objet;
                        suppresion_reussi = true;
                    }
                }
            }

            return suppresion_reussi;
        }
    }
}