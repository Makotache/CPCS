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
        #region contains
        public static bool Contains(Enum enum1, Enum enum2)
        {
            long v1 = Convert.ToInt64(enum1);
            long v2 = Convert.ToInt64(enum2);
            return CPCS_Binary.Contains(v1, v2);
        }
        public static bool Contains(Enum enum1, int value)
        {
            int v1 = Convert.ToInt32(enum1);
            return CPCS_Binary.Contains(v1, value);
        }
        public static bool Contains(Enum enum1, long value)
        {
            long v1 = Convert.ToInt64(enum1);
            return CPCS_Binary.Contains(v1, value);
        }
        #endregion
        public static bool EnumContainsString(string str, Enum[] arr_filter) 
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

        public static T Concat<T>(T[] arr) where T : Enum
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
