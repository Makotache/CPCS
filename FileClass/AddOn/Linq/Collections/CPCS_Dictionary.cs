using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CPCS.Linq.Collections
{
    public static class CPCS_Dictionary
    {
        #region insert
        public static void Insert<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, int index, TKey key, TValue value)
        {
            if (dictionary == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }
            else if (index >= dictionary.Count || index < 0)
            {
                Exception_CPCS.IndexOutOfRangeException("index");
            }
            else if (key == null)
            {
                Exception_CPCS.ArgumentNullException("key");
            }
            else if (value == null)
            {
                Exception_CPCS.ArgumentNullException("value");
            }

            int nb_items = dictionary.Count;
            if (nb_items < index)
            { throw new IndexOutOfRangeException($"La taille du dictionnaire actuel est de '{nb_items}'. Vous ne pouvez pas inséré un élément à l'index '{index}'."); }

            Dictionary<TKey, TValue> ancien_dict = new Dictionary<TKey, TValue>();

            for (int i = 0; i < dictionary.Count; i++)
            { ancien_dict.Add(dictionary.Keys.ElementAt(i), dictionary.Values.ElementAt(i)); }

            dictionary.Clear();

            for (int i = 0; i < nb_items; i++)
            {
                if (i == index)
                {
                    dictionary.Add(key, value);
                }
                TKey tmp_key = ancien_dict.Keys.ElementAt(i);
                TValue tmp_value = ancien_dict.Values.ElementAt(i);
                dictionary.Add(tmp_key, tmp_value);
            }
        }

        public static void Insert<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, int index, KeyValuePair<TKey, TValue> kvp)
        {
            if (dictionary == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }
            else if (index >= dictionary.Count || index < 0)
            {
                Exception_CPCS.IndexOutOfRangeException("index");
            }
            else if ((object)kvp == null)
            {
                Exception_CPCS.ArgumentNullException("kvp");
            }

            dictionary.Insert(index, kvp.Key, kvp.Value);
        }
        #endregion

        #region add
        public static void Add<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> kvp)
        {
            if (dictionary == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }
            else if ((object)kvp == null)
            {
                Exception_CPCS.ArgumentNullException("kvp");
            }

            dictionary.Add(kvp.Key, kvp.Value);
        }

        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> fromThis, Dictionary<TKey, TValue> values)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (values == null)
            {
                Exception_CPCS.ArgumentNullException("values");
            }

            foreach (KeyValuePair<TKey, TValue> kvp in values)
            {
                fromThis.Add(kvp);
            }
        }
        #endregion


        #region replace
        public static void ReplaceKey<TKey, TValue>(this Dictionary<TKey, TValue> fromThis, TKey oldKey, TKey newKey)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (oldKey == null)
            {
                Exception_CPCS.ArgumentNullException("oldKey");
            }
            else if (newKey == null)
            {
                Exception_CPCS.ArgumentNullException("newKey");
            }

            if (fromThis.ContainsKey(newKey))
            {
                return;
            }

            TValue value = fromThis[oldKey];
            int index = fromThis.IndexOf(oldKey);
            fromThis.ReplaceAt(index, newKey, value);
        }

        public static void ReplaceAt<TKey, TValue>(this Dictionary<TKey, TValue> fromThis, int index, TKey newKey, TValue newValue)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (index >= fromThis.Count || index < 0)
            {
                Exception_CPCS.IndexOutOfRangeException("index");
            }
            else if (newKey == null)
            {
                Exception_CPCS.ArgumentNullException("newKey");
            }
            else if (newValue == null)
            {
                Exception_CPCS.ArgumentNullException("newValue");
            }

            if (fromThis.ContainsKey(newKey))
            {
                return;
            }

            fromThis.Insert(index, newKey, newValue);
            fromThis.RemoveAt(index + 1);
        }
        #endregion

        #region indexof
        public static int IndexOf<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }
            else if (key == null)
            {
                Exception_CPCS.ArgumentNullException("key");
            }

            for (int i = 0; i < dictionary.Count; i++)
            {
                if(dictionary.ElementAt(i).Key.Equals(key))
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion


        #region remove
        public static Dictionary<Tkey, TValue> Remove<Tkey, TValue>(this Dictionary<Tkey, TValue> fromThis, Dictionary<Tkey, TValue> thisItems)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }

            if (thisItems == null)
            {
                Exception_CPCS.ArgumentNullException("thisItems");
            }

            Dictionary<Tkey, TValue> result = new Dictionary<Tkey, TValue>(fromThis);
            for (int i = result.Count - 1; i >= 0; i--)
            {
                if (thisItems.ContainsKey(result.ElementAt(i).Key))
                {
                    result.Remove(result.ElementAt(i).Key);
                }
            }

            return result;
        }

        public static void Remove<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Func<KeyValuePair<TKey, TValue>, bool> function)
        {
            if (dictionary == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }
            else if (function == null)
            {
                Exception_CPCS.ArgumentNullException("function");
            }

            for (int i = dictionary.Count - 1; i >= 0; i--)
            {
                if (function(dictionary.ElementAt(i)))
                {
                    dictionary.RemoveAt(i);
                }
            }
        }

        public static void RemoveAt<TKey, TValue>(this Dictionary<TKey, TValue> fromThis, int index)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }
            else if (index >= fromThis.Count || index < 0)
            {
                Exception_CPCS.IndexOutOfRangeException("index");
            }

            for (int i = 0; i < fromThis.Count; i++)
            {
                if (i == index)
                {
                    fromThis.Remove(fromThis.ElementAt(i));
                }
            }
        }

        public static void Remove<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> item)
        {
            if (dictionary == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }
            else if ((object)item == null)
            {
                Exception_CPCS.ArgumentNullException("item");
            }

            if (dictionary.Contains(item))
            {
                dictionary.Remove(item.Key);
            }
        }
        #endregion

        #region get
        public static bool TryGetValueNoNull<TKey, TValue>(this Dictionary<TKey, TValue> fromThis, TKey key, out TValue value)
        {
            if (fromThis == null)
            {
                Exception_CPCS.ArgumentNullException("fromThis");
            }
            else if (key == null)
            {
                Exception_CPCS.ArgumentNullException("key");
            }

            if (fromThis.ContainsKey(key))
            {
                value = fromThis[key];
                bool haveElement = true;

                if (value is IEnumerable valueAsEnum)
                {
                    haveElement = valueAsEnum.Cast<object>().Count() > 0;
                }

                return value != null && haveElement;
            }

            value = default(TValue);
            return false;
        }
        #endregion

        public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Action<KeyValuePair<TKey, TValue>> action)
        {
            if (dictionary == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }
            else if (action == null)
            {
                Exception_CPCS.ArgumentNullException("action");
            }

            for (int i = 0; i < dictionary.Count; i++)
            {
                action(dictionary.ElementAt(i));
            }
        }

        public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Action<KeyValuePair<TKey, TValue>> action)
        {
            if (dictionary == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }
            else if (action == null)
            {
                Exception_CPCS.ArgumentNullException("action");
            }

            for (int i = 0; i < dictionary.Count(); i++)
            {
                action(dictionary.ElementAt(i));
            }
        }

        public static bool ContainsValues<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue[] arr)
        {
            if (dictionary == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }
            else if (arr == null)
            {
                Exception_CPCS.ArgumentNullException("arr");
            }

            int count_values = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (dictionary.ContainsValue(arr[i]))
                {
                    count_values++;
                }
            }
            return count_values == arr.Length;
        }

        public static void WriteAllLines<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                Exception_CPCS.ArgumentNullException("dictionary");
            }

            Console.WriteLine($"Type => ({typeof(TKey)}, {typeof(TValue)})");
            Console.WriteLine($"Taille Dictionaire => ({dictionary.Count})");
            for (int i = 0; i < dictionary.Count; i++)
            {
                Console.WriteLine($" - Dictionaire[{i}]\n\tclé = '{dictionary.ElementAt(i).Key}', valeur = '{dictionary.ElementAt(i).Value}'");
            }
        }

    }
}
