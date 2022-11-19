using System.Collections.Generic;
using UnitsConverterApp.MVVM.Models.DataModels;
using UnitsConverterApp.MVVM.Models.DataModels.Entities;

namespace UnitsConverterApp.MVVM.Models
{
    public class ContextRepoModel
    {
        public List<string> getUnitTypeList;
        public List<string> getUnitList;
        public List<Unit> tableDataList { get; set; }
    }
}
