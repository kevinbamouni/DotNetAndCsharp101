using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChinookDataApp
{
    class ListColumnDataImport : ObservableCollection<DataImportDetails>
    {
        public ListColumnDataImport()
        {
            Add(new DataImportDetails("Company"));
            Add(new DataImportDetails("Origin"));
            Add(new DataImportDetails("Developpement"));
            Add(new DataImportDetails("Paid_Loss"));
        }
    }
}
