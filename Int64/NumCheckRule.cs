using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Int64Converter
{
    class NumCheckRule : ValidationRule
    {
        private int min;
        private int max;

        public int Min { get{return min;} set{min = value; } }
        public int Max { get { return max; } set { max = value; } }


        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            Int64 iNum;
            if (!Int64.TryParse(value.ToString(), out iNum))
            {
                return new ValidationResult(false, "Invalid number format");
            }
            //if (iNum < min || iNum > max)
            //{
            //    return new ValidationResult(false, string.Format("Out of range({0}-{1})", min, max));
            //}
            return ValidationResult.ValidResult;
        }
    }
}
