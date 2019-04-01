using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Trace.Common.valid
{

    class NumberValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), "^[0-9]+$"))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "请输入数字");
            }

            return ValidationResult.ValidResult;
        }
    }
}
