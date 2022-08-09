using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class CPCS_Reflection
    {
        private static MethodInfo cast_method = typeof(Enumerable).GetMethod("Cast");
        private static MethodInfo toArray_method = typeof(Enumerable).GetMethod("ToArray");

        public static object GetValueObjFromEnum(string value, Type enumType)
        {
            Array enum_values = Enum.GetValues(enumType);

            /*cast_method = cast_method.MakeGenericMethod(typeof(Array));
            var cas_invoked = cast_method.Invoke(null, new object[] { enum_values });

            toArray_method = toArray_method.MakeGenericMethod(typeof(Array));
            var all_values = (IList)toArray_method.Invoke(null, new object[] { cas_invoked });*/

            foreach (var str in enum_values)
            {
                if (value == str.ToString())
                {
                    return str;
                }
            }
            return null;
        }
    }
}
