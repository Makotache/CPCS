using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS.Linq.System
{
    public static class CPCS_String
    {
        private const string specialLetter = "àãä" + "éêèë" + "ç" + "îïì" + "õòöô" + "ùûü" + "ÿ";
        private const string normalLetter = "abcdefghijklmnopqrstuvwxyz";
        private const string numbers = "0123456789";

        public static bool Contains(this string strToVerify, string withIt, bool ignoreCase)
        {
            if (ignoreCase)
            {
                return strToVerify.IndexOf(withIt, StringComparison.OrdinalIgnoreCase) > -1;
            }
            else
            {
                return strToVerify.IndexOf(withIt) > -1;
            }
        }

        public static string StringLatinLetterOnly(this string str, string customCharacter, bool ignoreCase = true, bool withAccent = true)
        {
            string letter =  normalLetter + customCharacter + (withAccent ? specialLetter : "");

            for (int i = str.Length - 1; i > -1; i--)
            {
                if (!Contains(letter, str[i].ToString(), ignoreCase))
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }

        public static bool ContainsLatinLetter(this string str, string customCharacter, bool ignoreCase = true, bool withAccent = true)
        {
            string letter = normalLetter + customCharacter + (withAccent ? specialLetter : "");

            for (int i = str.Length - 1; i > -1; i--)
            {
                if (!Contains(letter, str[i].ToString(), ignoreCase))
                {
                    return false;
                }
            }
            return true;
        }

        public static int OccurrenceCount(this string str, string occurrence)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.IndexOf(occurrence, i) > 0)
                {
                    result++;
                }
            }
            return result;
        }

        public static int[] GetAllIntNumbers(this string str)
        {
            List<int> result = new List<int>();

            string tmp_int = "";
            bool isNumbers;

            for(int i = 0; i < str.Length; i++)
            {
                isNumbers = false;
                for (int u = 0; u < numbers.Length; u++)
                {
                    if (str[u] == str[i])
                    {
                        tmp_int += str[u];
                        isNumbers = true;
                    }
                }

                if(!isNumbers && tmp_int.Length > 0)
                {
                    result.Add(int.Parse(tmp_int));
                }
            }

            if(result.Count == 0)
            { 
                return null; 
            }

            return result.ToArray();
        }

        public static bool EqualIgnorCase(this string str, string withIt)
        {
            if (str.Length != withIt.Length)
            { return false; }

            return str.IndexOf(withIt, StringComparison.OrdinalIgnoreCase) > -1;
        }

        #region IsUpper IsLower
        public static bool IsUpper(this char c)
        {
            return c == c.ToString().ToUpper()[0];
        }

        public static bool IsLower(this char c)
        {
            return c == c.ToString().ToLower()[0];
        }

        public static bool IsUpper(this string str)
        {
            return str == str.ToUpper();
        }

        public static bool IsLower(this string str)
        {
            return str == str.ToLower();
        }
        #endregion
    }
}
