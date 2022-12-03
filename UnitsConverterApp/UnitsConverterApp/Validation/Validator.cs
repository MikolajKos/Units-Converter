using System;
using System.Collections.Generic;
using System.Text;
using UnitsConverterApp.Validation.TypesOfValidation;

namespace UnitsConverterApp.Validation
{
    public class Validator<T> : IValidationTypes
    {
        private T value;
        public string Name { get; set; }
        private List<ISpecyficValidation<T>> typesOfValidationList;

        public Validator(T value, string name, List<ISpecyficValidation<T>> typesOfValidationList)
        {
            this.value = value;
            this.Name = name;
            this.typesOfValidationList = typesOfValidationList;
        }

        public bool Validate(out string message)
        {
            message = "";

            foreach (ISpecyficValidation<T> typesOfValidation in typesOfValidationList)
            {
                if (!typesOfValidation.Validate(value, out message))
                {
                    message = Name + " " + message;
                    return false;
                }
            }
            return true;
        }
    }
}
