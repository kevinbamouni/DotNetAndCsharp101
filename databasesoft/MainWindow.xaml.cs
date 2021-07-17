using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace databasesoft
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

        private void run_CallPricing(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a NumberFormatInfo object and set some of its properties.
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                Pricer callprice = new Pricer();
                StringBuilder res;
                res = callprice.Call_pricer(double.Parse(S0.Text), double.Parse(K.Text), Convert.ToDouble(r.Text, provider), int.Parse(T.Text), Convert.ToDouble(sigma.Text, provider), int.Parse(N.Text), int.Parse(M.Text));

                resultext.Text = res.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} Exception caught.", ex));
            }

        }
    }
}
