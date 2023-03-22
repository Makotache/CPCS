using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    internal static class Exception_CPCS
    {
        public static void ArgumentNullException(string argument)
        {
            throw new ArgumentNullException($"L'argument '{argument}' ne peut être null");
        }

        public static void IndexOutOfRangeException(string argument)
        {
            throw new IndexOutOfRangeException($"L'argument '{argument}' ne peut être en dehors des limites de l'objet");
        }
    }
}
