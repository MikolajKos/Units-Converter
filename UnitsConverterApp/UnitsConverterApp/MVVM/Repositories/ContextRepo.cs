using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnitsConverterApp.MVVM.Models;
using UnitsConverterApp.MVVM.Models.DataModels;
using UnitsConverterApp.MVVM.Models.DataModels.Entities;
using UnitsConverterApp.MVVM.ViewModels;

namespace UnitsConverterApp.MVVM.Repositories
{
    public class ContextRepo
    {
        private ContextRepoModel model = new ContextRepoModel();
        private MyDbContext myContext = new MyDbContext();

        #region Add Queries

        public void AddUnitType(string unitType)
        {
            myContext.UnitsType.Add(
                new UnitType
                {
                    UnitTypeName = unitType
                });

            myContext.SaveChanges();
        }

        public void AddUnit(string name, string symbol, double ratio, int unitType)
        {
            myContext.Units.Add(
                new Unit
                {
                    Name = name,
                    Symbol = symbol,
                    Ratio = ratio,
                    UnitTypeId = unitType
                });

            myContext.SaveChanges();
        }

        #endregion


        #region Get Queries
        public List<string> GetUnitTypeList()
        {
            model.getUnitTypeList = new List<string>();

            var getNamesQuery = myContext.UnitsType.Select(s => s.UnitTypeName);

            foreach (var elements in getNamesQuery)
                model.getUnitTypeList.Add(elements.ToString());

            return model.getUnitTypeList;
        }

        public List<string> GetUnitList(int typeId = 1)
        {
            model.getUnitList = new List<string>();
            var getNamesQuery = myContext.Units.Where(k => k.UnitTypeId == typeId)?.Select(s => s.Name);

            foreach (var elemens in getNamesQuery)
                model.getUnitList.Add(elemens.ToString());

            return model.getUnitList;
        }

        public string GetUnitSymbol(string unitName)
        {
            var getSymbolQuery = myContext.Units.FirstOrDefault(k => k.Name == unitName)?.Symbol;
            return getSymbolQuery;
        }
        
        private double GetRatio(string unitName)
        {
            var getRatioQuery = myContext.Units
                .FirstOrDefault(k => k.Name == unitName)?.Ratio.ToString();

            return double.Parse(getRatioQuery);
        }

        #endregion




        public string CalculateValue(string enteredValue, string fromUnit, string toUnit)
        {
            double result = (double.Parse(enteredValue) * GetRatio(toUnit)) / GetRatio(fromUnit);

            return result.ToString();
        }

        public List<Unit> FillDataGrid(int typeId = 1)
        {
            if (typeId == 0)
                return null;

            model.tableDataList = new List<Unit>();

            model.tableDataList = myContext.Units
                .Where(k => k.UnitTypeId == typeId)?
                .Select(s => new Unit { Name = s.Name, Symbol = s.Symbol, Ratio = s.Ratio }).ToList();

            return model.tableDataList;
        }

        public void UpdateDatGrid()
        {
            myContext.SaveChanges();
        }
    }
}


