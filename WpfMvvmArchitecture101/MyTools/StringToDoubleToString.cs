using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfMvvmArchitecture101.MyTools
{
    public class StringToDoubleToString : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Binding : Objet vers interface
            //if(value != null) 
            //{ 
            //    string v = (string)value;
            //    return v;
            //}
            return value;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Binding : Interface vers object
            if (value != null)
            {
                double v = (double)value;
                return v;
            }
            return value;
        }
    }
}
