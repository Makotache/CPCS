using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class CPCS_Random
    {
        private static readonly Random sample = new Random();

        public static int Get(int maxValue)
        {
            return sample.Next(maxValue + 1);
        }

        public static int Get(int minValue, int maxValue)
        {
            return sample.Next(minValue, maxValue + 1);
        }

        public static Object Get<T>(List<T> list)
        {
            int nb_element_lst = list.Count;
            return list[sample.Next(nb_element_lst)];
        }


        /// <summary>
        /// Permet de récupérer la position d'une Coord_CPCS null au hasard dans un tableau en 2 dimensions
        /// </summary>
        /// <param name="tableau">Tableau en 2 dimensions</param>
        /// <returns>La position pris au hasard</returns>
        public static CPCS_Coord GetRandomNullPosition<T>(T[,] tableau)
        {
            if (tableau.GetLength(0) == 0 || tableau.GetLength(1) == 0)
            {
                throw new ArgumentException("La taille des ligne ou des colonnes du tableau dois être supérieur à 0.");
            }

            //liste des élements null disponible
            List<CPCS_Coord> list_point = new List<CPCS_Coord>();

            int colonne = tableau.GetLength(0);
            int ligne = tableau.GetLength(1);


            for (int i = 0; i < colonne; i++)//colonne
            {
                for (int u = 0; u < ligne; u++)//ligne
                {
                    if (tableau[u, i] == null)
                    {
                        list_point.Add(new CPCS_Coord(u, i));
                    }
                }
            }

            if (list_point.Count < 2)
            {
                throw new ArgumentException("Tableau doit au moins contenir deux éléments null.");
            }

            CPCS_Coord coord = (CPCS_Coord)CPCS_Random.Get(list_point);
            int x = (int)coord.x;
            int y = (int)coord.y;
            return new CPCS_Coord(x, y);
        }

        /// <summary>
        /// Permet de récupérer la position d'une Coord_CPCS NON null au hasard dans un tableau en 2 dimensions
        /// </summary>
        /// <param name="tableau">Tableau en 2 dimensions</param>
        /// <returns>La position pris au hasard</returns>
        public static CPCS_Coord GetRandomNotNullPosition(CPCS_Coord[,] tableau)
        {
            if (tableau.GetLength(0) == 0 || tableau.GetLength(1) == 0)
            {
                throw new ArgumentException("La taille des ligne ou des colonnes du tableau dois être supérieur à 0.");
            }


            //liste des élements null disponible
            List<CPCS_Coord> list_point = new List<CPCS_Coord>();

            for (int i = 0; i < tableau.GetLength(1); i++)//colonne
            {
                for (int u = 0; u < tableau.GetLength(0); u++)//ligne
                {
                    if (tableau[u, i] != null)
                    {
                        list_point.Add((CPCS_Coord)tableau[u, i]);
                    }
                }
            }

            if (list_point.Count < 2)
            {
                throw new ArgumentException("Tableau doit au moins contenir deux éléments non null.");
            }

            CPCS_Coord coord = (CPCS_Coord)CPCS_Random.Get(list_point);
            int x = (int)coord.x;
            int y = (int)coord.y;
            return new CPCS_Coord(x, y);
        }


        /// <summary>
        /// Permet de récupérer un élément au hasard dans un tableau en 2 dimensions
        /// </summary>
        /// <param name="tableau">Tableau en 2 dimensions</param>
        /// <returns>Un élément pris au hasard</returns>
        public static Object GetRandomPosition(Array[][] tableau)
        {
            if (tableau.Length == 0 || tableau[0].Length == 0)
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
