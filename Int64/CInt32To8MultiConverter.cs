using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace Int64Converter
{
    class CInt32To8MultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int32 iHH8Input = 0;
            if (!Int32.TryParse(values[0].ToString(), out iHH8Input))
            {
                return "0";
            }
            Int32 iHL8Input = 0;
            if (!Int32.TryParse(values[1].ToString(), out iHL8Input))
            {
                return "0";
            }
            Int32 iLH8Input = 0;
            if (!Int32.TryParse(values[2].ToString(), out iLH8Input))
            {
                return "0";
            }
            Int32 iLL8Input = 0;
            if (!Int32.TryParse(values[3].ToString(), out iLL8Input))
            {
                return "0";
            }
            Int32 iOut = (iHH8Input << 24) | (iHL8Input << 16) | (iLH8Input << 8) | iLL8Input;
            return iOut.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] result = { "0", "0", "0", "0" };
            Int32 i32Input = 0;
            if (!Int32.TryParse(value.ToString(), out i32Input))
            {
                return result;
            }
            Int32 iOutTemp = i32Input >> 24;
            result[0] = iOutTemp.ToString();
            iOutTemp = i32Input >> 16;
            result[1] = iOutTemp.ToString();
            iOutTemp = i32Input >> 8;
            result[2] = iOutTemp.ToString();
            iOutTemp = i32Input & 0xFFFF;
            result[3] = iOutTemp.ToString();
            return result;
        }
    }
}
