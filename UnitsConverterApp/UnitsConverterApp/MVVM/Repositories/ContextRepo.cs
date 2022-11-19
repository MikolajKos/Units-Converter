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
/*        private MyDbContext myContext = new MyDbContext();
        private List<string> getUnitTypeList;
        private List<string> getUnitList = new List<string>();
        private List<Unit> tableDataList { get; set; }*/
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

            var myQuery = myContext.UnitsType.Select(s => s.UnitTypeName);

            foreach (var elements in myQuery)
            {
                model.getUnitTypeList.Add(elements.ToString());
            }

            return model.getUnitTypeList;
        }

        public List<string> GetUnitList()
        {
            model.getUnitList = new List<string>();
            var count = myContext.Units.Where(o => o.Id > 0).Count();

            for (int i = 1; i <= count; i++)
                model.getUnitList.Add(myContext.Units.FirstOrDefault(k => k.Id == i)?.Name.ToString());

            return model.getUnitList;
        }
        #endregion


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