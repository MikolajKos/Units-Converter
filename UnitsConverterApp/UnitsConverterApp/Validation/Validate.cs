using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsConverterApp.Validation
{
    public class Validate
    {
        private List<IValidationTypes> listOfValidators;

        public Validate()
        {
            listOfValidators = new List<IValidationTypes>();
        }

        public void AddValidator(IValidationTypes validator)
        {
            listOfValidators.Add(validator);
        }

        public bool Validation(out string message)
        {
            foreach (IValidationTypes validator in listOfValidators)
            {
                if (!validator.Validate(out message))
                {
                    return false;
                }
            }

            message = "";
            return true;
        }

        public bool Validation(out Dictionary<string, string> dictionaryError)
        {
            dictionaryError = new Dictionary<string, string>();

            foreach (IValidationTypes validator in listOfValidators)
            {
                if (!validator.Validate(out string message))
                    dictionaryError.Add(validator.Name, "");

                dictionaryError[validator.Name] = message;
            }

            return dictionaryError.Count == 0;
        }

    }
}
