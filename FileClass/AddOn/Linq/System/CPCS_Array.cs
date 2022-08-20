using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS.Linq.System
{
    public static class CPCS_Array
    {
        /// <summary>
        /// Change l'obj similaire a celui dans le tableau par le nouvel_objet.
        /// </summary>
        /// <param name="tableau">Le Tableau dans le quel on effectue la supression</param>
        /// <param name="obj">Objet à supprimer.</param>
        /// <returns>True si réussi sinon false.</returns>
        public static bool ChangeAllSimilarObject(this object[,] tableau, object obj, object nouvel_objet)
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


        public static List<int> StrArrayToIntArray(this string[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("L'argument 'arr' peut être null");
            }

            int taille_tableau = arr.Length;
            List<int> result = new List<int>();

            for (int i = 0; i < taille_tableau; i++)
            {
                if (arr[i] != "")
                {
                    //Console.WriteLine($"tableau[{i}] {tableau[i]}");
                    result.Add(int.Parse(arr[i]));
                }
            }
            return result;
        }

        public static void WriteAllLines<T>(this T[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("L'argument 'arr' peut être null");
            }

            Console.WriteLine($"Type => ({typeof(T)})");
            Console.WriteLine($"Taille Tableau => ({arr.Length})");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($" - Tableau[{i}]\n\tvaleur = '{arr[i]}'");
            }
        }

        public static void ForEach<T>(this T[] arr, Action<T> action)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("L'argument 'arr' peut être null");
            }

            if (action == null)
            {
                throw new ArgumentNullException("L'argument 'action' peut être null");
            }

            for (int i = 0; i < arr.Length; i++)
            {
                action(arr[i]);
            }
        }
    }
}