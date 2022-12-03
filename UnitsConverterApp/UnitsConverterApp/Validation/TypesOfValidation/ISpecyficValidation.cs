using System;
using System.Collections.Generic;
using System.Text;

namespace UnitsConverterApp.Validation.TypesOfValidation
{
    public interface ISpecyficValidation<T>
    {
        bool Validate(T value, out string message);
    }
}
