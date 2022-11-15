using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsConverterApp.Core;

namespace UnitsConverterApp.MVVM.ViewModels
{
    public class AddUnitsViewModel : ObservableObject
    {
        private string _unitTypeInput;

        public string UnitTypeInput
        {
            get 
            {
                return _unitTypeInput; 
            }
            set
            {
                _unitTypeInput = value;
                OnPropertyChanged(nameof(UnitTypeInput));
            }
        }



        #region Commands

        private ICommand _addUnitType;

        public ICommand AddUnitType
        {
            get 
            {
                if (_addUnitType == null) _addUnitType = new RelayCommand(
                    (object o) =>
                    {

                    },
                    (object o) =>
                    {
                        if (string.IsNullOrWhiteSpace(UnitTypeInput))
                            return false;
                        return true;
                    });
                return _addUnitType;
            }
        }

        #endregion
    }
}
