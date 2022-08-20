using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS.Linq.Collections
{
    public static class CPCS_List
    {
        public static void WriteAllLines<T>(this List<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("L'argument 'list' peut être null");
            }

            Console.WriteLine($"Type => ({typeof(T)})");
            Console.WriteLine($"Taille Liste => ({list.Count})");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($" - Liste[{i}]\n\tvaleur = '{list[i]}'");
            }
        }

        public static List<T> Remove<T>(this List<T> fromThis, List<T> thisItems)
        {
            if (fromThis == null)
            {
                throw new ArgumentNullException("L'argument 'fromThis' peut être null");
            }

            if (thisItems == null)
            {
                throw new ArgumentNullException("L'argument 'thisItems' peut être null");
            }

            List<T> result = new List<T>(fromThis);
            for (int i = result.Count - 1; i >= 0; i--)
            {
                for (int u = 0; u < thisItems.Count; u++)
                {
                    if (result[i].Equals(thisItems[u]))
                    {
                        result.Remove(thisItems[u]);
                    }
                }
            }

            return result;
        }
    }
}
