using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
