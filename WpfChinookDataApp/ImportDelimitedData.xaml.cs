using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfChinookDataApp
{
    /// <summary>
    /// Logique d'interaction pour ImportDelimitedData.xaml
    /// </summary>
    public partial class ImportDelimitedData : Window
    {
        public ImportDelimitedData()
        {
            InitializeComponent();

            // Binding du selecteur de type de colonne pour la lecture des données
            // Liste des types / Binding datagrid contenant deux types de colonnes différentees textcolumn et comboboxcolumn
            //
            Dictionary<int, string> TypeOfColumnData = new Dictionary<int, string>{
            {1, "Key"},
            {2, "Origin"},
            {3, "Developpemnt"},
            {4, "Loss/Paid"}
            };

            ListColumnDataImport ll1 = new ListColumnDataImport();
            Binding binding1 = new Binding();
            binding1.Source = ll1;
            schemacol.SetBinding(DataGrid.ItemsSourceProperty, binding1);
            combocol.ItemsSource = TypeOfColumnData;

        }

    }
}
