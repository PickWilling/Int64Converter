using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;

namespace Int64
{
    [ValueConversion(typeof(string), typeof(string))]
    class CInt64ToH32Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strInt64 = value as string;
            return strInt64.Length;
            //return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strH32 = value as string;
            return "From" + strH32.Length.ToString();
            //return value;
        }

    }
}
