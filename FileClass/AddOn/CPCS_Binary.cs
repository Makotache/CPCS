using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{ 
    public static class CPCS_Binary
    {
        #region variables
        private const string hexaValues = "0123456789" + "ABCDEF";
        private const string binaryValues = "01";
        #endregion

        #region contains
        public static bool Contains(short valueContains, short thisItem)
        {
            return Contains((long)valueContains, thisItem);
        }

        public static bool Contains(ushort valueContains, ushort thisItem)
        {
            return Contains((long)valueContains, thisItem);
        }

        public static bool Contains(int valueContains, int thisItem)
        {
            return Contains((long)valueContains, thisItem);
        }

        public static bool Contains(uint valueContains, uint thisItem)
        {
            return Contains((long)valueContains, thisItem);
        }

        public static bool Contains(ulong valueContains, ulong thisItem)
        {
            return Contains((long)valueContains, (long)thisItem);
        }

        public static bool Contains(long valueContains, long thisItem)
        {
            //A    contains(B)          R
            //00            00          false
            //01            00          false
            //00            01          false
            //110           101         false
            if (thisItem > valueContains || valueContains == 0 || thisItem == 0)
            {
                return false;
            }

            string valueContains_str = Convert.ToString(valueContains, toBase: 2 );
            string thisItem_str = Convert.ToString(thisItem, toBase: 2 );

            //01            11          false
            //10            11          false
            for (int i = 0; i < thisItem_str.Length; i++)
            {
                if (thisItem_str[i] == '1' && thisItem_str[i] != valueContains_str[i])
                {
                    return false;
                }
            }

            //01            01			true
            //11			01			true
            return true;
        }

        public static bool Contains(string valueContains, string thisValue)
        {
            if(!ContainsBinaryValueOnly(valueContains))
            {
                throw new ArgumentException($"La chaine 'valueContains' possède un format incorrect");
            }
            else if (!ContainsBinaryValueOnly(thisValue))
            {
                throw new ArgumentException($"La chaine 'thisValue' possède un format incorrect");
            }

            valueContains = RemoveFirstZero(valueContains);
            thisValue = RemoveFirstZero(thisValue);

            //A    contains(B)          R
            //00            00          false
            //01            00          false
            //00            01          false
            //110           101         false
            if (thisValue.Length > valueContains.Length || AllIs(valueContains, false) || AllIs(valueContains, false))
            {
                return false;
            }

            //01            11          false
            //10            11          false
            for (int i = 0; i < thisValue.Length; i++)
            {
                if (thisValue[i] == '1' && thisValue[i] != valueContains[i])
                {
                    return false;
                }
            }

            //01            01			true
            //11			01			true
            return true;
        }
        #endregion

        private static bool AllIs(string str, bool isTrue)
        {
            char c = isTrue ? '1' : '0';

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '0')
                {
                    return false;
                }
            }

            return true;
        }

        public static string RemoveFirstZero(string str)
        {
            string s = "";
            bool reach1 = false;
            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] != 0)
                {
                    reach1 = true;
                    s += str[i];
                }
                else if(reach1 && str[i] == '0')
                {
                    s += str[i];
                }

            }
            return s;
        }

        public static bool ContainsBinaryValueOnly(string str)
        {
            return CompareValue(str, binaryValues);
        }

        public static bool ContainsHexaValueOnly(string str)
        {
            return CompareValue(str, hexaValues);
        }

        private static bool CompareValue(string str, string values)
        {
            for (int i = 0; i < str.Length; i++)
            {
                bool isValue = false;

                for (int u = 0; u < values.Length; u++)
                {
                    if (str[i] == values[u])
                    {
                        isValue = true;
                        break;
                    }
                }

                if (!isValue)
                {
                    return false;
                }
            }

            return true;
        }

        public static string ConvertHexaToBinary(string str)
        {
            string result = "";
            for(int i = 0; i < str.Length; i++)
            {
                result += ConvertHexaToBinary(str[i]);
            }
            return result;
        }
        public static string ConvertHexaToBinary(char c)
        {
            switch(c.ToString().ToUpper())
            {
                case "0": return "0000";
                case "1": return "0001";
                case "2": return "0010";
                case "3": return "0011";
                case "4": return "0100";
                case "5": return "0101";
                case "6": return "0101";
                case "7": return "0111";
                case "8": return "1000";
                case "9": return "1001";
                case "A": return "1010";
                case "B": return "1011";
                case "C": return "1100";
                case "D": return "1101";
                case "E": return "1110";
                case "F": return "1111";
            }

            throw new ArgumentException($"Le charactère 'c' doit correpondre a l'un des caractère suivant '{hexaValues}'");
        }
    }
}
