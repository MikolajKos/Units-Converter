﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnitsConverterApp.MVVM.Models.DataModels;
using UnitsConverterApp.MVVM.Models.DataModels.Entities;
using UnitsConverterApp.MVVM.ViewModels;

namespace UnitsConverterApp.MVVM.Repositories
{
    public class ContextRepo
    {
        private MyDbContext myContext = new MyDbContext();
        private List<string> getUnitTypeList = new List<string>();
        private List<Unit> tableDataList { get; set; }

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

        public List<string> GetUnitTypeList()
        {
            var count = myContext.UnitsType.Where(o => o.Id > 0).Count();

            for (int i = 1; i <= count; i++)
                getUnitTypeList.Add(myContext.UnitsType.FirstOrDefault(k => k.Id == i).UnitTypeName.ToString());

            return getUnitTypeList;
        }

        public List<Unit> FillDataGrid(int typeId)
        {
            if (typeId == 0)
                return null;

            tableDataList = myContext.Units
                .Where(k => k.UnitTypeId == typeId)
                .Select(s => new Unit { Name = s.Name, Symbol = s.Symbol, Ratio = s.Ratio }).ToList();
            
            return tableDataList;
        }

        public void UpdateDatGrid()
        {
            myContext.SaveChanges();
        }
    }
}
