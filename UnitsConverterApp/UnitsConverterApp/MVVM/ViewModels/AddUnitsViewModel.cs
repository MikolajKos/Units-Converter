﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsConverterApp.Core;
using UnitsConverterApp.MVVM.Models.DataModels.Entities;
using UnitsConverterApp.MVVM.Repositories;

namespace UnitsConverterApp.MVVM.ViewModels
{
    public class AddUnitsViewModel : ObservableObject
    {
        ContextRepo crep = new ContextRepo();

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


        private string _unitName;

        public string UnitName
        {
            get
            {
                return _unitName;
            }
            set
            {
                _unitName = value;
                OnPropertyChanged(nameof(UnitName));
            }
        }


        private string _unitSymbol;

        public string UnitSymbol
        {
            get
            {
                return _unitSymbol;
            }
            set
            {
                _unitSymbol = value;
                OnPropertyChanged(nameof(UnitSymbol));
            }
        }


        private string _unitRatio;

        public string UnitRatio
        {
            get
            {
                return _unitRatio;
            }
            set
            {
                _unitRatio = value;
                OnPropertyChanged(nameof(UnitRatio));
            }
        }


        private List<string> _unitTypeList;

        public List<string> UnitTypeList
        {
            get
            {
                return crep.GetUnitTypeList();
            }
            set
            {
                _unitTypeList = value;
                OnPropertyChanged(nameof(UnitTypeList));
            }
        }


        private int _selectedUnitType;

        public int SelectedUnitType
        {
            get
            {
                return _selectedUnitType;
            }
            set
            {
                _selectedUnitType = value;
                OnPropertyChanged(nameof(SelectedUnitType));
            }
        }


        private List<Unit> _dataGridSource;

        public List<Unit> DataGridSource
        {
            get
            {
                return _dataGridSource;
            }
            set
            {
                _dataGridSource = value;
                OnPropertyChanged(nameof(DataGridSource));
            }
        }





        #region Commands

        private ICommand _addUnitType;

        public ICommand AddUnitTypeCommand
        {
            get
            {
                if (_addUnitType == null) _addUnitType = new RelayCommand(
                    (object o) =>
                    {
                        crep.AddUnitType(UnitTypeInput);

                        UnitTypeInput = string.Empty;
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


        private ICommand _addUnitCommand;

        public ICommand AddUnitCommand
        {
            get
            {
                if (_addUnitCommand == null) _addUnitCommand = new RelayCommand(
                    (object o) =>
                    {
                        crep.AddUnit(UnitName, UnitSymbol, double.Parse(UnitRatio), SelectedUnitType);
                    },
                    (object o) => true);
                return _addUnitCommand;
            }
        }


        private ICommand _selectedUnitTypeCommand;

        public ICommand SelectedUnitTypeCommand
        {
            get
            {
                if (_selectedUnitTypeCommand == null) _selectedUnitTypeCommand = new RelayCommand(
                    (object o) =>
                    {
                        DataGridSource = crep.FillDataGrid(SelectedUnitType);
                    },
                    (object o) => true);
                return _selectedUnitTypeCommand;
            }
        }



        private ICommand _updateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null) _updateCommand = new RelayCommand(
                    (object o) =>
                    {
                        crep.UpdateDatGrid();
                    },
                    (object o) => true);
                return _updateCommand;
            }
        }


        #endregion
    }
}
