using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace SharedLogic
{
    public class OneToTenValidation : ValidationRule
    {
        public OneToTenValidation() { }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int tempNumber;
            int.TryParse(value.ToString(), out tempNumber);

            try
            {
                if(tempNumber > 10 || tempNumber < 1)
                {

                }
            } catch (Exception e)
            {
                return new ValidationResult(false, "Please enter a number between " + " - " + ".");
            }

            return ValidationResult.ValidResult;
        }
    }
}
