using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class CPCS_BitConverter
    {
        #region From
        /// <summary>
        /// Convertie <paramref name="value"/> en tableau de boolean où chaque élément du tableau représente un bit.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool[] From(short value)
        {
            return From((long)value);
        }

        /// <summary>
        /// Convertie <paramref name="value"/> en tableau de boolean où chaque élément du tableau représente un bit.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool[] From(int value)
        {
            return From((long)value);
        }

        /// <summary>
        /// Convertie <paramref name="value"/> en tableau de boolean où chaque élément du tableau représente un bit.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool[] From(long value)
        {
            List<bool> result = new List<bool>();

            string str = Convert.ToString(value, toBase: 2);
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result.Add(str[i] == '1');
            }

            return result.ToArray();
        }
        #endregion

        #region ConvertHexaToBinary
        public static string ConvertHexaToBinary(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                result += ConvertHexaToBinary(str[i]);
            }
            return result;
        }
        public static string ConvertHexaToBinary(char c)
        {
            switch (c.ToString().ToUpper())
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

            throw new ArgumentException($"Le charactère 'c' doit correpondre a l'un des caractère suivant '{CPCS_Binary.hexaValues}'");
        }
        #endregion
    }
}
