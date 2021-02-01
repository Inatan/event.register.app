using System;
using System.ComponentModel.DataAnnotations;

namespace events.register.api.Attributes
{
    public class DataMaiorIdadeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime inputValue = (DateTime)value;
            return inputValue.AddYears(18) < DateTime.Today;
        }

    }
}
