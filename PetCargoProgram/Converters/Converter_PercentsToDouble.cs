using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace PetCargoProgram.Converters
{
    public class Converter_PercentsToDouble : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is null ? null : System.Convert.ToDouble(value.ToString().Replace('%', '\0'));
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                double? result = value is null ? null : System.Convert.ToDouble(value.ToString().Replace('%', '\0').Replace(',', '.')) / 100.0;
                return result;
            }

            catch (System.FormatException exception)
            {

                MessageBox.Show(exception.Message);
                return 0.0;
            }
        }
    }
}
