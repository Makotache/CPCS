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
        /// <param name="array">Le Tableau dans le quel on effectue la supression</param>
        /// <param name="obj">Objet à supprimer.</param>
        /// <returns>True si réussi sinon false.</returns>
        public static bool ChangeAllSimilarObject<T>(this T[,] array, T obj, T nouvel_objet)
        {
            if(array == null)
            {
                throw new ArgumentException("L'argument 'array' ne peut être null");
            }
            else if (array.GetLength(0) == 0 || array.GetLength(1) == 0)
            {
                throw new ArgumentException("La taille des ligne ou des colonnes du tableau dois être supérieur à 0");
            }

            bool suppresion_reussi = false;
            for (int i = 0; i < array.GetLength(1); i++)//colonne
            {
                for (int u = 0; i < array.GetLength(0); i++)//ligne
                {
                    if (array[u, i].Equals(obj))
                    {
                        array[u, i] = nouvel_objet;
                        suppresion_reussi = true;
                    }
                }
            }

            return suppresion_reussi;
        }


        public static int[] StrArrayToIntArray(this string[] arr)
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
            return result.ToArray();
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

        public static int IndexOf<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public static T[] Reverse<T>(this T[] arr)
        {
            List<T> result = new List<T>();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static bool IndexIsValid<T>(this T[] arr, int index)
        {
            if (arr == null)
            {
                Exception_CPCS.ArgumentNullException("arr");
            }

            return 0 <= index && index < arr.Length;
        }
    }
}