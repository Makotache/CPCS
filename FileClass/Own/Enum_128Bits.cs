using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPCS
{
    public class Enum_128Bits
    {
        private DualValue<HighWeight, LowWeight> _value;
        private int toInt
        {
            get => ToInt();
        }
        public Enum_128Bits()
        {
            _value = new DualValue<HighWeight, LowWeight>(HighWeight._000, LowWeight._000);
        }
        public Enum_128Bits(HighWeight highWeight, LowWeight lowWeight)
        {
            _value = new DualValue<HighWeight, LowWeight>(highWeight, lowWeight);
        }

        #region ToString ToInt
        public int ToInt()
        {
            return int.Parse(this._value.Value1.ToString().Replace("_", "")) + int.Parse(this._value.Value2.ToString().Replace("_", ""));
        }
        public override string ToString()
        {
            return ToString(false);
        }
        public string ToString(bool makeItVisualizable)
        {
            string add0(string str)
            {
                int base_size = str.Length;
                for (int i = 0; i < 16 - base_size; i++)
                {
                    str = "0" + str;
                }
                return str;
            }

            string str_value1 = add0(Convert.ToString((long)_value.Value1, toBase: 16).ToUpper());
            string str_value2 = add0(Convert.ToString((long)_value.Value2, toBase: 16).ToUpper());

            if (makeItVisualizable)
            {
                string add_(string str)
                {
                    string _4octet_1 = str.Substring(0, 4);
                    string _4octet_2 = str.Substring(4, 4);
                    string _4octet_3 = str.Substring(8, 4);
                    string _4octet_4 = str.Substring(12);
                    return "_" + _4octet_1 + "_" + _4octet_2 + "_" + _4octet_3 + "_" + _4octet_4;
                }

                str_value1 = "0x" + add_(str_value1);
                str_value2 = add_(str_value2);
            }
           
            return str_value1 + str_value2;
        }
        #endregion

        #region Contains
        public bool Contains(string value)
        {
            return this.Contains(Enum_128Bits.ConvertFromString(value));
        }
        public bool Contains(Enum_128Bits enum2)
        {
            return CPCS_Binary.Contains(CPCS_Binary.ConvertHexaToBinary(this.ToString()), CPCS_Binary.ConvertHexaToBinary(enum2.ToString()));
        }
        public bool Contains(LowWeight value)
        {
            return CPCS_Binary.Contains((ulong)_value.Value2, (ulong)value);
        }
        public bool Contains(HighWeight value)
        {
            return CPCS_Binary.Contains((ulong)_value.Value1, (ulong)value);
        }
        #endregion 

        #region Set
        public void Add(string value)
        {
            this.Add(Enum_128Bits.ConvertFromString(value));
        }
        public void Add(Enum_128Bits enum2)
        {
            this.Add(enum2._value.Value2);
            this.Add(enum2._value.Value1);
        }
        public void Add(LowWeight value)
        {
            _value.Value2 |= value;
        }
        public void Add(HighWeight value)
        {
            _value.Value1 |= value;
        }
        #endregion

        #region Remove
        public void Remove(string value)
        {
            this.Remove(Enum_128Bits.ConvertFromString(value));
        }
        public void Remove(Enum_128Bits enum2)
        {
            this.Remove(enum2._value.Value2);
            this.Remove(enum2._value.Value1);
        }
        public void Remove(LowWeight value)
        {
            _value.Value2 ^= value;
        }
        public void Remove(HighWeight value)
        {
            _value.Value1 ^= value;
        }
        #endregion

        public Enum_128Bits Copy()
        {
            return new Enum_128Bits(this._value.Value1, this._value.Value2);
        }

        #region operateur
        public static Enum_128Bits operator |(Enum_128Bits a, Enum_128Bits b)
        {
            return new Enum_128Bits(a._value.Value1 | b._value.Value1, a._value.Value2 | b._value.Value2);
        }
        public static Enum_128Bits operator &(Enum_128Bits a, Enum_128Bits b)
        {
            return new Enum_128Bits(a._value.Value1 & b._value.Value1, a._value.Value2 & b._value.Value2);
        }
        public static Enum_128Bits operator ^(Enum_128Bits a, Enum_128Bits b)
        {
            return new Enum_128Bits(a._value.Value1 ^ b._value.Value1, a._value.Value2 ^ b._value.Value2);
        }
        #endregion

        #region static
        public static Enum_128Bits ConvertFromString(string str)
        {
            str = str.Replace("0x", "").Replace("_", "").Replace(" ", "");

            if (str.Length != 32)
            {
                throw new ArgumentException("La chaine 'str' possède un format incorrect");
            }

            try
            {
                ulong value1 = Convert.ToUInt64(str.Substring(0, 16), 16);
                ulong value2 = Convert.ToUInt64(str.Substring(16), 16);

                return new Enum_128Bits((HighWeight)value1, (LowWeight)value2);
            }
            catch
            {
                throw new ArgumentException("La chaine 'str' possède un format incorrect");
            }
        }

        public static Enum_128Bits ConvertFromInt(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("L'argument 'value' ne peut être inférieur à 0");
            }
            if (value > 128)
            {
                throw new ArgumentException("L'argument 'value' ne peut être supérieur à 128");
            }

            string lowWeight_str = value <= 64 ? value + "" : "000";
            string highWeight_str = value <= 64 ? "000" : value + "";

            lowWeight_str = CPCS_Binary.FillFirstZero(lowWeight_str, 3);
            highWeight_str = CPCS_Binary.FillFirstZero(highWeight_str, 3);

            LowWeight value1 = (LowWeight)Enum.Parse(typeof(LowWeight), "_" + lowWeight_str);
            HighWeight value2 = (HighWeight)Enum.Parse(typeof(HighWeight), "_" + highWeight_str);
            return new Enum_128Bits(value2, value1);
        }

        public static List<Enum_128Bits> CreateListEnum_128Bits(int endIndex = 128)
        {
            return CreateListEnum_128Bits(0, endIndex);
        }

        public static List<Enum_128Bits> CreateListEnum_128Bits(int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
            {
                throw new ArgumentException("L'argument 'startIndex' ne peut être supérieur à 'endIndex'");
            }

            if (endIndex > 128)
            {
                throw new ArgumentException("L'argument 'endIndex' ne peut être supérieur à 128");
            }

            List<Enum_128Bits> result = new List<Enum_128Bits>();

            for (int i = startIndex; i <= endIndex; i++)
            {
                result.Add(Enum_128Bits.ConvertFromInt(i));
            }

            return result;
        }

        /*public static Enum_128Bits Concat(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("L'argument 'minValue' ne peut être supérieur à 'maxValue'");
            }
            if (minValue > 128)
            {
                throw new ArgumentException("L'argument 'minValue' ne peut être supérieur à 128");
            }
            if (maxValue > 128)
            {
                throw new ArgumentException("L'argument 'maxValue' ne peut être supérieur à 128");
            }

            for (int i = minValue; i <= maxValue; i++)
            {
                
            }
            

            return null;
        }*/

        public static Enum_128Bits Concat(Enum_128Bits[] enums)
        {
            return Concat(enums.ToList());
        }

        public static Enum_128Bits Concat(List<Enum_128Bits> enums)
        {
            if (enums == null)
            {
                throw new NullReferenceException("L'argument 'enums' ne noit pas être null");
            }
            
            Enum_128Bits result = new Enum_128Bits();
            enums.ForEach(e => result.Add(e));

            return result;
        }
        #endregion

        #region enum
        [Flags]
        public enum LowWeight : ulong
        {
            _000 = 0x_0000_0000_0000_0000,

            _001 = 0x_0000_0000_0000_0001,
            _002 = 0x_0000_0000_0000_0002,
            _003 = 0x_0000_0000_0000_0004,
            _004 = 0x_0000_0000_0000_0008,
            _005 = 0x_0000_0000_0000_0010,
            _006 = 0x_0000_0000_0000_0020,
            _007 = 0x_0000_0000_0000_0040,
            _008 = 0x_0000_0000_0000_0080,
            _009 = 0x_0000_0000_0000_0100,
            _010 = 0x_0000_0000_0000_0200,
            _011 = 0x_0000_0000_0000_0400,
            _012 = 0x_0000_0000_0000_0800,
            _013 = 0x_0000_0000_0000_1000,
            _014 = 0x_0000_0000_0000_2000,
            _015 = 0x_0000_0000_0000_4000,
            _016 = 0x_0000_0000_0000_8000,

            _017 = 0x_0000_0000_0001_0000,
            _018 = 0x_0000_0000_0002_0000,
            _019 = 0x_0000_0000_0004_0000,
            _020 = 0x_0000_0000_0008_0000,
            _021 = 0x_0000_0000_0010_0000,
            _022 = 0x_0000_0000_0020_0000,
            _023 = 0x_0000_0000_0040_0000,
            _024 = 0x_0000_0000_0080_0000,
            _025 = 0x_0000_0000_0100_0000,
            _026 = 0x_0000_0000_0200_0000,
            _027 = 0x_0000_0000_0400_0000,
            _028 = 0x_0000_0000_0800_0000,
            _029 = 0x_0000_0000_1000_0000,
            _030 = 0x_0000_0000_2000_0000,
            _031 = 0x_0000_0000_4000_0000,
            _032 = 0x_0000_0000_8000_0000,

            _033 = 0x_0000_0001_0000_0000,
            _034 = 0x_0000_0002_0000_0000,
            _035 = 0x_0000_0004_0000_0000,
            _036 = 0x_0000_0008_0000_0000,
            _037 = 0x_0000_0010_0000_0000,
            _038 = 0x_0000_0020_0000_0000,
            _039 = 0x_0000_0040_0000_0000,
            _040 = 0x_0000_0080_0000_0000,
            _041 = 0x_0000_0100_0000_0000,
            _042 = 0x_0000_0200_0000_0000,
            _043 = 0x_0000_0400_0000_0000,
            _044 = 0x_0000_0800_0000_0000,
            _045 = 0x_0000_1000_0000_0000,
            _046 = 0x_0000_2000_0000_0000,
            _047 = 0x_0000_4000_0000_0000,
            _048 = 0x_0000_8000_0000_0000,

            _049 = 0x_0001_0000_0000_0000,
            _050 = 0x_0002_0000_0000_0000,
            _051 = 0x_0004_0000_0000_0000,
            _052 = 0x_0008_0000_0000_0000,
            _053 = 0x_0010_0000_0000_0000,
            _054 = 0x_0020_0000_0000_0000,
            _055 = 0x_0040_0000_0000_0000,
            _056 = 0x_0080_0000_0000_0000,
            _057 = 0x_0100_0000_0000_0000,
            _058 = 0x_0200_0000_0000_0000,
            _059 = 0x_0400_0000_0000_0000,
            _060 = 0x_0800_0000_0000_0000,
            _061 = 0x_1000_0000_0000_0000,
            _062 = 0x_2000_0000_0000_0000,
            _063 = 0x_4000_0000_0000_0000,
            _064 = 0x_8000_0000_0000_0000,

            All = 0x_FFFF_FFFF_FFFF_FFFF
        }

        [Flags]
        public enum HighWeight : ulong
        {
            _000 = 0x_0000_0000_0000_0000,

            _065 = 0x_0000_0000_0000_0001,
            _066 = 0x_0000_0000_0000_0002,
            _067 = 0x_0000_0000_0000_0004,
            _068 = 0x_0000_0000_0000_0008,
            _069 = 0x_0000_0000_0000_0010,
            _070 = 0x_0000_0000_0000_0020,
            _071 = 0x_0000_0000_0000_0040,
            _072 = 0x_0000_0000_0000_0080,
            _073 = 0x_0000_0000_0000_0100,
            _074 = 0x_0000_0000_0000_0200,
            _075 = 0x_0000_0000_0000_0400,
            _076 = 0x_0000_0000_0000_0800,
            _077 = 0x_0000_0000_0000_1000,
            _078 = 0x_0000_0000_0000_2000,
            _079 = 0x_0000_0000_0000_4000,
            _080 = 0x_0000_0000_0000_8000,

            _081 = 0x_0000_0000_0001_0000,
            _082 = 0x_0000_0000_0002_0000,
            _083 = 0x_0000_0000_0004_0000,
            _084 = 0x_0000_0000_0008_0000,
            _085 = 0x_0000_0000_0010_0000,
            _086 = 0x_0000_0000_0020_0000,
            _087 = 0x_0000_0000_0040_0000,
            _088 = 0x_0000_0000_0080_0000,
            _089 = 0x_0000_0000_0100_0000,
            _090 = 0x_0000_0000_0200_0000,
            _091 = 0x_0000_0000_0400_0000,
            _092 = 0x_0000_0000_0800_0000,
            _093 = 0x_0000_0000_1000_0000,
            _094 = 0x_0000_0000_2000_0000,
            _095 = 0x_0000_0000_4000_0000,
            _096 = 0x_0000_0000_8000_0000,

            _097 = 0x_0000_0001_0000_0000,
            _098 = 0x_0000_0002_0000_0000,
            _099 = 0x_0000_0004_0000_0000,
            _100 = 0x_0000_0008_0000_0000,
            _101 = 0x_0000_0010_0000_0000,
            _102 = 0x_0000_0020_0000_0000,
            _103 = 0x_0000_0040_0000_0000,
            _104 = 0x_0000_0080_0000_0000,
            _105 = 0x_0000_0100_0000_0000,
            _106 = 0x_0000_0200_0000_0000,
            _107 = 0x_0000_0400_0000_0000,
            _108 = 0x_0000_0800_0000_0000,
            _109 = 0x_0000_1000_0000_0000,
            _110 = 0x_0000_2000_0000_0000,
            _111 = 0x_0000_4000_0000_0000,
            _112 = 0x_0000_8000_0000_0000,

            _113 = 0x_0001_0000_0000_0000,
            _114 = 0x_0002_0000_0000_0000,
            _115 = 0x_0004_0000_0000_0000,
            _116 = 0x_0008_0000_0000_0000,
            _117 = 0x_0010_0000_0000_0000,
            _118 = 0x_0020_0000_0000_0000,
            _119 = 0x_0040_0000_0000_0000,
            _120 = 0x_0080_0000_0000_0000,
            _121 = 0x_0100_0000_0000_0000,
            _122 = 0x_0200_0000_0000_0000,
            _123 = 0x_0400_0000_0000_0000,
            _124 = 0x_0800_0000_0000_0000,
            _125 = 0x_1000_0000_0000_0000,
            _126 = 0x_2000_0000_0000_0000,
            _127 = 0x_4000_0000_0000_0000,
            _128 = 0x_8000_0000_0000_0000,

            All = 0x_FFFF_FFFF_FFFF_FFFF
        }
        #endregion
    }
}
