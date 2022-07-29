using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class CPCS_Time
    {
        /// <summary>
        /// </summary>
        /// <returns>Le timestamp en milisecon</returns>
        public static long GetMillisecondTimeStamp()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}
