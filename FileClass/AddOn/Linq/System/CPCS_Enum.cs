using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CPCS.Linq.System
{
    public static class CPCS_Enum
    {
        #region contains
        public static bool ContainsInt16<T>(this T enum1, T enum2) where T : Enum
        {
            return enum1.ContainsInt16(Convert.ToInt16(enum2));
        }
        public static bool ContainsInt16<T>(this T enum1, short value) where T : Enum
        {
            return CPCS_Binary.Contains(Convert.ToInt16(enum1), value);
        }

        public static bool ContainsInt32<T>(this T enum1, T enum2) where T : Enum
        {
            return enum1.ContainsInt32(Convert.ToInt32(enum2));
        }
        public static bool ContainsInt32<T>(this T enum1, int value) where T : Enum
        {
            return CPCS_Binary.Contains(Convert.ToInt32(enum1), value);
        }

        public static bool ContainsInt64<T>(this T enum1, T enum2) where T : Enum
        {
            return enum1.ContainsInt64(Convert.ToInt64(enum2));
        }
        public static bool ContainsInt64<T>(this T enum1, long value) where T : Enum
        {
            return CPCS_Binary.Contains(Convert.ToInt64(enum1), value);
        }

        #endregion
        public static bool EnumContainsString<T>(this T[] arr_filter, string str) where T : Enum
        {
            foreach (Enum filter in arr_filter)
            {
                if (str.ToLower() == filter.ToString().ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        public static T ConcatFlags<T>(this T[] arr) where T : Enum
        {
            if (arr.Length == 0)
            {
                return (T)Enum.ToObject(typeof(T), 0);
            }

            object result;

            switch (arr[0].GetTypeCode())
            {
                case TypeCode.Byte:
                    byte result8 = 0;
                    foreach (T item in arr)
                    {
                        result8 += Convert.ToByte(item);
                    }
                    result = result8;
                    break;

                case TypeCode.SByte:
                    sbyte resultS8 = 0;
                    foreach (T item in arr)
                    {
                        resultS8 += Convert.ToSByte(item);
                    }
                    result = resultS8;
                    break;

                case TypeCode.Int16:
                    short result16 = 0;
                    foreach (T item in arr)
                    {
                        result16 += Convert.ToInt16(item);
                    }
                    result = result16;
                    break;

                case TypeCode.UInt16:
                    ushort resultU16 = 0;
                    foreach (T item in arr)
                    {
                        resultU16 += Convert.ToUInt16(item);
                    }
                    result = resultU16;
                    break;

                case TypeCode.Int32:
                    int result32 = 0;
                    foreach (T item in arr)
                    {
                        result32 += Convert.ToInt32(item);
                    }
                    result = result32;
                    break;

                case TypeCode.UInt32:
                    uint resultU32 = 0;
                    foreach (T item in arr)
                    {
                        resultU32 += Convert.ToUInt32(item);
                    }
                    result = resultU32;
                    break;

                case TypeCode.Int64:
                    long result64 = 0;
                    foreach (T item in arr)
                    {
                        result64 += Convert.ToInt64(item);
                    }
                    result = result64;
                    break;

                case TypeCode.UInt64:
                    ulong Uresult64 = 0;
                    foreach (T item in arr)
                    {
                        Uresult64 += Convert.ToUInt64(item);
                    }
                    result = Uresult64;
                    break;

                default:
                    throw new ArgumentException("Type d'enum nom pris en charge");
            }
            
            return (T)Enum.ToObject(typeof(T), result);
        }
    }
}
