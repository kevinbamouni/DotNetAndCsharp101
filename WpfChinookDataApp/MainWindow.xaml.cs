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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;


namespace WpfChinookDataApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public void  ViewAlbums(object sender, RoutedEventArgs e)
        {
            RequetesChinook requetesChinook =  new RequetesChinook();
            //dataGrid.ItemsSource= requetesChinook.dt.AsEnumerable();
            Binding b = new Binding();
            b.Source = requetesChinook;
            b.Path = new PropertyPath("dt");
            InputDataGrid.SetBinding(DataGrid.ItemsSourceProperty, b);
        }

        public void ViewArtists(object sender, RoutedEventArgs e)
        {
            RequetesChinook requetesChinook = new RequetesChinook();
            //dataGrid.ItemsSource= requetesChinook.dt.AsEnumerable();
            Binding b = new Binding();
            b.Source = requetesChinook;
            b.Path = new PropertyPath("artists");
            InputDataGrid.SetBinding(DataGrid.ItemsSourceProperty, b);
        }

        public async void ViewEmployees(object sender, RoutedEventArgs e)
        {
            await Task.Delay(600000);
            RequetesChinook requetesChinook = new RequetesChinook();
            //dataGrid.ItemsSource= requetesChinook.dt.AsEnumerable();
            Binding b = new Binding();
            b.Source = requetesChinook;
            b.Path = new PropertyPath("employees");
            InputDataGrid.SetBinding(DataGrid.ItemsSourceProperty, b);
            await Task.Delay(600000);
        }

        public async  void ViewCustumers(object sender, RoutedEventArgs e)
        {
            await Task.Delay(600000);
            RequetesChinook requetesChinook = new RequetesChinook();
            //dataGrid.ItemsSource= requetesChinook.dt.AsEnumerable();
            Binding b = new Binding();
            b.Source = requetesChinook;
            b.Path = new PropertyPath("customers");
            InputDataGrid.SetBinding(DataGrid.ItemsSourceProperty, b);
            await Task.Delay(600000);
        }
    }
}
