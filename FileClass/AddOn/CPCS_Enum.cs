using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class CPCS_Enum
    {
        public static bool EnumContainsString<T>(string str, T[] arr_filter, string relace_underscore = "_") where T : Enum
        {
            foreach (T filter in arr_filter)
            {
                if (str.ToLower() == filter.ToString().Replace("_", relace_underscore).ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
