using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CPCS.Linq.System
{
    public static class CPCS_Reflection
    {
        public static object Invoke(this MethodBase methodBase, object instance)
        {
            return methodBase.Invoke(instance, new object[] { });
        }

        public static object Invoke(this MethodBase methodBase, object instance, params object[] parameters)
        {
            return methodBase.Invoke(instance, parameters);
        }

    }
}
