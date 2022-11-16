using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitsConverterApp.MVVM.Models.DataModels;
using UnitsConverterApp.MVVM.Models.DataModels.Entities;

namespace UnitsConverterApp.MVVM.Repositories
{
    public class ContextRepo
    {
        MyDbContext myContext = new MyDbContext();
        List<string> getUnitTypeList = new List<string>();

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
    }
}
