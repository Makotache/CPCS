using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class CPCS_String
    {
        public static bool StringContainString(string strToVerify, string withIt, bool ignoreCase)
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

        public static string StringLatinLetterOnly(string str, string customCharacter, bool ignoreCase = true, bool withAccent = true)
        {
            const string specialLetter = "àãä" + "éêèë" + "ç" + "îïì" + "õòöô" + "ùûü" + "ÿ";
            string letter = "abcdefghijklmnopqrstuvwxyz" + customCharacter + (withAccent ? specialLetter : "");

            for (int i = str.Length - 1; i > -1; i--)
            {
                if (!StringContainString(letter, str[i].ToString(), ignoreCase))
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }

        public static bool StringContainLatinLetter(string str, string customCharacter, bool ignoreCase = true, bool withAccent = true)
        {
            const string specialLetter = "àãä" + "éêèë" + "ç" + "îïì" + "õòöô" + "ùûü" + "ÿ";
            string letter = "abcdefghijklmnopqrstuvwxyz" + customCharacter + (withAccent ? specialLetter : "");

            for (int i = str.Length - 1; i > -1; i--)
            {
                if (!StringContainString(letter, str[i].ToString(), ignoreCase))
                {
                    return false;
                }
            }
            return true;
        }

        public static int OccurrenceCount(string str, string occurrence)
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
    }
}
