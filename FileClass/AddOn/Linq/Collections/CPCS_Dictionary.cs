using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CPCS.Linq.Collections
{
    public static class CPCS_Dictionary
    {
        public static void Insert<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, int index, TKey key, TValue value)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("L'argument 'dictionary' peut être null");
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

        public static void WriteAllLines<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("L'argument 'dictionary' ne peut être null");
            }

            Console.WriteLine($"Type => ({typeof(TKey)}, {typeof(TValue)})");
            Console.WriteLine($"Taille Dictionaire => ({dictionary.Count})");
            for (int i = 0; i < dictionary.Count; i++)
            {
                Console.WriteLine($" - Dictionaire[{i}]\n\tclé = '{dictionary.ElementAt(i).Key}', valeur = '{dictionary.ElementAt(i).Value}'");
            }
        }

        public static Dictionary<Tkey, TValue> Remove<Tkey, TValue>(this Dictionary<Tkey, TValue> fromThis, Dictionary<Tkey, TValue> thisItems)
        {
            if (fromThis == null)
            {
                throw new ArgumentNullException("L'argument 'fromThis' ne peut être null");
            }

            if (thisItems == null)
            {
                throw new ArgumentNullException("L'argument 'thisItems' ne peut être null");
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

        /*#region ForEach
        public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Action<TKey, TValue> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("L'argument 'action' peut être null");
            }

            PropertyInfo dictionaryEntries = typeof(Dictionary<TKey, TValue>).GetProperty("entries", BindingFlags.NonPublic);
            Console.WriteLine("============");

            object entries = dictionaryEntries.GetValue(dictionary);
            //Entry<TKey, TValue>[] entries = (Entry<TKey, TValue>[])dictionaryEntries.GetValue(dictionary);


            Console.WriteLine("----");
            //source.Where()
            for (int i = 0; i < dictionary.Count; i++)
            {
                Console.WriteLine($"dictionary.ElementAt({i}).Key => " + dictionary.ElementAt(i).Key);
                Console.WriteLine($"dictionary.ElementAt({i}).Value => " + dictionary.ElementAt(i).Value);
                //action(entries[i].key, entries[i].value);
                dictionaryEntries.SetValue(dictionary, entries);

            }

            for (int i = 0; i < dictionary.Count; i++)
            {
                Console.WriteLine($"dictionary.ElementAt({i}).Key => " + dictionary.ElementAt(i).Key);
                Console.WriteLine($"dictionary.ElementAt({i}).Value => " + dictionary.ElementAt(i).Value);
            }
        }
        private struct Entry<TKey, TValue>
        {
            public int hashCode;

            public int next;

            public TKey key;

            public TValue value;
        }

        #endregion*/
    }
}
