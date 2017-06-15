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
            Int64 iInput = Int64.Parse(value.ToString());
            Int64 iOut = iInput >> 32;
            return iOut.ToString();
            //string strInt64 = value as string;
            //return strInt64.Length;
            //return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Int32 iInput = Int32.Parse(value.ToString());
            return iInput.ToString();
            //return value;
        }

    }
}
