using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnitsConverterApp.MVVM.Models.DataModels.Entities
{
    public class UnitType
    {
        [Key]
        public int Id { get; set; }
        public string UnitTypeName { get; set; }
    }
}
