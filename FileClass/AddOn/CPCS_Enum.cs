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

        private static MethodInfo cast_method = typeof(Enumerable).GetMethod("Cast");
        private static MethodInfo toArray_method = typeof(Enumerable).GetMethod("ToArray");

        public static object StringConvertToEnum(string str, Type type, string relace_underscore = "_")
        {
            Array enum_values = Enum.GetValues(type);

            cast_method = cast_method.MakeGenericMethod(new Type[] { type });
            var cas_invoked = cast_method.Invoke(null, new object[] { enum_values });

            toArray_method = toArray_method.MakeGenericMethod(new Type[] { type });
            var all_values = (IList)toArray_method.Invoke(null, new object[] { cas_invoked });

            foreach (var value in all_values)
            {
                if (str.ToLower() == value.ToString().Replace("_", relace_underscore).ToLower())
                {
                    return value;
                }
            }
            return all_values[0];
        }
    }
}
