using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace Int64Converter
{
    class CInt64To32MultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int32 iH32Input = 0;
            if (!Int32.TryParse(values[0].ToString(), out iH32Input))
            {
                return "0";
            }
            Int32 iL32Input = 0;
            if (!Int32.TryParse(values[1].ToString(), out iL32Input))
            {
                return "0";
            }
            Int64 iTemp = iL32Input;
            Int64 iOut = iH32Input;
            iOut = (iOut << 32) | iTemp;
            return iOut.ToString();

            //return "1";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] result = {"0", "0"};
            Int64 i64Input = 0;
            if (!Int64.TryParse(value.ToString(), out i64Input))
            {
                return result;
            }
            Int64 iOutTemp = i64Input >> 32;
            result[0] = iOutTemp.ToString();
            iOutTemp = i64Input & 0xFFFFFFFF;
            result[1] = iOutTemp.ToString();
            return result;
        }
    }
}
