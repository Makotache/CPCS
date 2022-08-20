using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class CPCS_Encoding
    {
        public static string EncodeToUTF8(string str)
        {
            return EncodeTo(str, Encoding.UTF8);
        }

        public static string EncodeTo(string str, Encoding format)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return format.GetString(bytes);
        }
    }
}
