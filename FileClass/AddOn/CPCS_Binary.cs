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
        public const string hexaValues = "0123456789" + "ABCDEF";
        public const string binaryValues = "01";
        #endregion

        #region operation
        #region contains

        public static bool Contains(int valueContains, int thisItem)
        {
            return Contains((long)valueContains, thisItem);
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

            bool[] valueContains_arr = CPCS_BitConverter.From(valueContains);
            bool[] thisItem_arr = FillFirstZero(thisItem, valueContains_arr.Length);


            //01            11          false
            //10            11          false
            for (int i = 0; i < thisItem_arr.Length; i++)
            {
                if (thisItem_arr[i] && thisItem_arr[i] != valueContains_arr[i])
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
            if (!ContainsBinaryValueOnly(thisValue))
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

        public static string Or(string operaterA, string operaterB)
        {
            if (!ContainsBinaryValueOnly(operaterA))
            {
                throw new ArgumentException($"La chaine 'operaterA' possède un format incorrect");
            }
            if (!ContainsBinaryValueOnly(operaterB))
            {
                throw new ArgumentException($"La chaine 'operaterB' possède un format incorrect");
            }

            bool smaller_operater_isA = operaterA.Length < operaterB.Length;
            string smaller_operater = smaller_operater_isA ? operaterA : operaterB;
            string biggest_operater = smaller_operater_isA ? operaterB : operaterA;

            int spaceBetwenAB = biggest_operater.Length - smaller_operater.Length;
            string result = "";
            for(int i = 0; i < smaller_operater.Length; i++)
            {
                //A     0100
                //B   010001
                //R   010101
                result = smaller_operater[i] == '1' || biggest_operater[spaceBetwenAB + i] == '1' ? result + "1": result + "0";
            }

            string highWeight = biggest_operater.Substring(0, spaceBetwenAB);
            return highWeight + result;
        }
        #endregion

        #region RemoveFirstZero

        public static bool[] FillFirstZero(long lng, int maxLenght)
        {
            List<bool> result = CPCS_BitConverter.From(lng).ToList();
            if (result.Count >= maxLenght || maxLenght < 0 || maxLenght > 64)
            {
                return result.ToArray();
            }

            while (result.Count < maxLenght)
            {
                result.Add(false);
            }

            return result.ToArray();
        }

        public static string RemoveFirstZero(string str)
        {
            string result = "";
            bool reach1 = false;
            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] != 0)
                {
                    reach1 = true;
                    result += str[i];
                }
                else if(reach1 && str[i] == '0')
                {
                    result += str[i];
                }

            }
            return result;
        }

        public static string FillFirstZero(string str, int maxLenght)
        {
            if (str.Length >= maxLenght || maxLenght < 0)
            {
                return str;
            }

            while(str.Length < maxLenght)
            {
                str = "0" + str;
            }

            return str;
        }
        #endregion

        #region ContainsXXXXValueOnly

        public static bool ContainsBinaryValueOnly(string str)
        {
            return CompareValue(str, binaryValues);
        }

        public static bool ContainsHexaValueOnly(string str)
        {
            return CompareValue(str, hexaValues);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isTrue"></param>
        /// <returns>true si tout les caractères de <paramref name="str"/> correspond a 0 ou 1 en fonction de <paramref name="isTrue"/>. Sinon False</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="values"></param>
        /// <returns>true si tout les caractères de <paramref name="str"/> correspond à l'un des caractères de <paramref name="values"/>. Sinon False</returns>
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
    }
}
