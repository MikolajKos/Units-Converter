using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsConverterApp.MVVM.ViewModels
{
    public class MainViewModel
    {
        TestModel model = new TestModel();

        List<string> myList = new List<string>();

        public List<string> ModelDataGrid
        {
            get
            {
                myList.Add("Mikołaj");
                myList.Add("Mikołaj");
                myList.Add("Mikołaj");
                myList.Add("Mikołaj");
                return myList;
            }
        }
    }
}
