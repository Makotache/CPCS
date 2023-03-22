using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS.Linq.Collections
{
    public static class CPCS_List
    {
        #region remove
        public static void Remove<T>(this List<T> fromThis, List<T> thisItems)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }

            if (thisItems == null)
            {
                Exception_CPCS.ArgumentNullException("thisItems");
            }

            for (int i = fromThis.Count - 1; i >= 0; i--)
            {
                for (int u = 0; u < thisItems.Count; u++)
                {
                    if (fromThis[i].Equals(thisItems[u]))
                    {
                        fromThis.Remove(thisItems[u]);
                        break;
                    }
                }
            }
        }

        public static void Remove<T>(this List<T> fromThis, Func<T, bool> function)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (function == null)
            {
                Exception_CPCS.ArgumentNullException("function");
            }

            for (int i = fromThis.Count - 1; i >= 0; i--)
            {
                if (function(fromThis[i]))
                {
                    fromThis.Remove(fromThis[i]);
                }
            }

        }
        #endregion

        #region replace
        public static void Replace<T>(this List<T> fromThis, T thisItem, T withThis)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (thisItem == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (withThis == null)
            {
                Exception_CPCS.ArgumentNullException("withThis");
            }

            if (!fromThis.Contains(thisItem))
            {
                return;
            }
            else if (fromThis.Contains(withThis))
            {
                return;
            }

            int index = fromThis.IndexOf(thisItem);
            fromThis.ReplaceAt(index, withThis);
        }

        public static void ReplaceAt<T>(this List<T> fromThis, int index, T withThis)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (withThis == null)
            {
                Exception_CPCS.ArgumentNullException("withThis");
            }

            if (fromThis.Contains(withThis))
            {
                return;
            }

            fromThis.Insert(index, withThis);
            fromThis.RemoveAt(index + 1);
        }

        public static void ReplaceFirst<T>(this List<T> fromThis, T withThis, Func<T, bool> function)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (withThis == null)
            {
                Exception_CPCS.ArgumentNullException("withThis");
            }
            else if (function == null)
            {
                Exception_CPCS.ArgumentNullException("function");
            }

            for(int i = fromThis.Count - 1; i >= 0; i--)
            {
                if (function(fromThis[i]))
                {
                    fromThis.ReplaceAt(i, withThis);
                    return;
                }
            }
        }

        public static void ReplaceAll<T>(this List<T> fromThis, T withThis, Func<T, bool> function)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (withThis == null)
            {
                Exception_CPCS.ArgumentNullException("withThis");
            }
            else if (function == null)
            {
                Exception_CPCS.ArgumentNullException("function");
            }

            for (int i = fromThis.Count - 1; i >= 0; i--)
            {
                if (function(fromThis[i]))
                {
                    fromThis.ReplaceAt(i, withThis);
                }
            }
        }

        public static void ReplaceAll<T>(this List<T> fromThis, List<T> withThis)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (withThis == null)
            {
                Exception_CPCS.ArgumentNullException("withThis");
            }

            fromThis.Clear();
            fromThis.AddRange(withThis);
        }

        /// <summary>
        /// Ne remplace que les éléments remplissiant la condition <paramref name="function"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fromThis"></param>
        /// <param name="withThis"></param>
        /// <param name="function"></param>
        public static void ReplaceAll<T>(this List<T> fromThis, List<T> withThis, Func<T, bool> function)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (withThis == null)
            {
                Exception_CPCS.ArgumentNullException("withThis");
            }
            else if (function == null)
            {
                Exception_CPCS.ArgumentNullException("function");
            }

            fromThis.Remove(function);
            fromThis.AddRange(withThis);
        }
        #endregion

        #region add
        public static void AddRangeAndRemoveDuplicates<T>(this List<T> fromThis, IEnumerable<T> values)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (values == null)
            {
                Exception_CPCS.ArgumentNullException("values");
            }

            List<T> tmp_values = new List<T>(values);
            tmp_values.Remove(fromThis);
            fromThis.AddRange(tmp_values);
        }
        #endregion

        public static bool IndexIsValid<T>(this List<T> list, int index)
        {
            if (list == null)
            {
                Exception_CPCS.ArgumentNullException("list");
            }

            return 0 <= index && index < list.Count;
        }
        public static void WriteAllLines<T>(this List<T> list)
        {
            if (list == null)
            {
                Exception_CPCS.ArgumentNullException("list");
            }

            Console.WriteLine($"Type => ({typeof(T)})");
            Console.WriteLine($"Taille Liste => ({list.Count})");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($" - Liste[{i}]\n\tvaleur = '{list[i]}'");
            }
        }
    }
}