using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Analysis;

namespace ReservingPropertyAndCasualty
{
    
    public class HatariITriangle
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DataFrame TriangleData { get; set; }

        public HatariITriangle(string pathToData, string name, string description, char separator, Encoding encoding)
        {
            Date = DateTime.Now;
            TriangleData = DataFrame.LoadCsv(pathToData, separator, true, default, default, -1, 10, false, encoding) ;
            Name = name;
            Description = description;

        }


    }
}
