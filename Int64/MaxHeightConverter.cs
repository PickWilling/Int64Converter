using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace Int64Converter
{
    class CMaxHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double dMaxHeight = 307.1;
            double dMaxWidth;
            if (double.TryParse(value.ToString(), out dMaxWidth))
            {
                dMaxHeight = (120 / 540) * dMaxWidth;
            }
            return dMaxHeight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
