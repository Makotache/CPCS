using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public class List_CPCS
    {
        public static List<int> strArrayToIntArray(String[] tableau)
        {
            int taille_tableau = tableau.Length;
            List<int> result = new List<int>();

            for (int i = 0; i < taille_tableau; i++)
            {
                if (tableau[i] != "")
                {
                    //Console.WriteLine($"tableau[{i}] {tableau[i]}");
                    result.Add(int.Parse(tableau[i]));
                }
            }
            return result;
        }
    }
}
