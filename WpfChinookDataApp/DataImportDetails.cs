using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChinookDataApp
{
    public class DataImportDetails
    {
        public string Name { get; set; }
        public string? Type { get; set; }

        public static Dictionary<int, string> TypeOfColumnData = new Dictionary<int, string>{
            {1, "Key"},
            {2, "Origin"},
            {3, "Developpemnt"},
            {4, "Loss/Paid"}
        };

        public DataImportDetails(string name)
        {
            Name = name;
        }
    }
}
