using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public static class CPCS_Math
    {

        #region int
        public static bool ApproximatelyCoef(int ia, int ib, int coef)
        {
            bool add = ib <= ia + coef;
            bool remove = ia - coef <= ib;
            return add && remove;
        }

        #endregion


        #region float
        public static bool ApproximatelyCoef(float fa, float fb, float coef)
        {
            bool add = fb <= fa + coef;
            bool remove = fa - coef <= fb;
            return add && remove;
        }
        #endregion


        #region all
        public static bool IsNumberString(string text, bool withPoint)
        {
            List<char> numbers = new List<char>();
            numbers.AddRange(new char[] {
                '0', '1', '2', '3', '4',
                '5', '6', '7', '8', '9'
            });

            if(withPoint)
            {
                numbers.Add('.');
            }

            bool result = false;

            for (int i = 0; i < text.Length; i++)
            {
                for (int u = 0; u < numbers.Count; u++)
                {
                    if (numbers.Contains(text[i]))
                    {
                        break;
                    }
                }

                if (!result)
                {
                    break;
                }
            }

            return result;
        }
        #endregion

    }
}
