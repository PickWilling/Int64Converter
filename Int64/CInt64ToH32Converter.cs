using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;

namespace Int64Converter
{
    [ValueConversion(typeof(string), typeof(string))]
    class CInt64ToH32Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int64 iInput;
            if (!Int64.TryParse(value.ToString(), out iInput))
            {
                return "0";
            }
            Int64 iOut = iInput >> 32;
            return iOut.ToString();
            //string strInt64 = value as string;
            //return strInt64.Length;
            //return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int32 iInput;
            if (!Int32.TryParse(value.ToString(), out iInput))
            {
                return "0";
            }
            return iInput.ToString();
            //return value;
        }

    }
}
