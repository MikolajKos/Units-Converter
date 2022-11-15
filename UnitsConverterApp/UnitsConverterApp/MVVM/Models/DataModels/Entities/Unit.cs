using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnitsConverterApp.MVVM.Models.DataModels.Entities
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Ratio { get; set; }
        public int UnitTypeId { get; set; }
        public UnitType UnitType { get; set; }
    }
}
