using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public class CPCS_Dictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public void Insert(int index, TKey key, TValue value)
        {
            int nb_items = this.Count;
            if (nb_items < index)
            { throw new IndexOutOfRangeException($"La taille du dictionnaire actuel est de '{nb_items}'. Vous ne pouvez pas inséré un élément à l'index '{index}'."); }

            Dictionary<TKey, TValue> ancien_dict = new Dictionary<TKey, TValue>();

            for (int i = 0; i < this.Count; i++)
            { ancien_dict.Add(this.Keys.ElementAt(i), this.Values.ElementAt(i)); }

            this.Clear();

            for (int i = 0; i < nb_items; i++)
            {
                if (i == index)
                {
                    this.Add(key, value);
                }
                TKey tmp_key = ancien_dict.Keys.ElementAt(i);
                TValue tmp_value = ancien_dict.Values.ElementAt(i);
                this.Add(tmp_key, tmp_value);
            }
        }

        public void DebugReadAllLines()
        {
            if (this.Count > 0)
            {
                TKey tmp_key = this.Keys.ElementAt(0);
                TValue tmp_value = this.Values.ElementAt(0);

                Console.WriteLine($"Taille Dictionaire({tmp_key}, {tmp_value})");
                for (int i = 0; i < this.Count; i++)
                {
                    Console.WriteLine($" - Dictionaire[{i}], clé = '{this.ElementAt(i).Key}', valeur = '{this.ElementAt(i).Value}'");
                }
            }
        }
    }
}
