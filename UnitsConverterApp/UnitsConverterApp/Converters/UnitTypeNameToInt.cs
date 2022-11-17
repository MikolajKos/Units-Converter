using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using UnitsConverterApp.MVVM.Models.DataModels;

namespace UnitsConverterApp.Converters
{
    public class UnitTypeNameToInt : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            using (MyDbContext myContext = new MyDbContext())
            {
                if (!string.IsNullOrWhiteSpace(value.ToString()))
                {
                    var getUnitTypeId = myContext.UnitsType.FirstOrDefault(k => k.UnitTypeName == value.ToString())?.Id;
                    return getUnitTypeId;
                }
                else
                    return 0;
            }
        }
    }
}
