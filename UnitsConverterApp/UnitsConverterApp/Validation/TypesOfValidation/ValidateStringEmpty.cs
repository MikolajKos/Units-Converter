using System;
using System.Collections.Generic;
using System.Text;

namespace UnitsConverterApp.Validation.TypesOfValidation
{
    public class ValidateStringEmpty : ISpecyficValidation<string>
    {
        public bool Validate(string value, out string message)
        {
            message = "";

            if (!string.IsNullOrWhiteSpace(value)) return true;
            
            message = " string is empty.";
            return false;
        }
    }
}
