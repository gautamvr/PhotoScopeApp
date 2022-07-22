using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using PhotoScope.Utilities.UI.Common;

namespace PhotoScope.DesktopUI.Converters
{
    public class BoolToVisibilityConverter : BaseConverter
    {
        /// <summary>
        ///     Gets the converter instance
        /// </summary>
        public static IValueConverter Instance { get; } = new BoolToVisibilityConverter();

        /// <summary>
        ///     Returns Visibility as Visible when value is true
        ///     otherwise returns Visibility as Collapsed.
        /// </summary>
        /// <param name="value">Data</param>
        /// <param name="targetType">Target type</param>
        /// <param name="parameter">Converter parameter</param>
        /// <param name="culture">Culture Info</param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Hidden;
            }
            bool.TryParse(value.ToString(), out var result);
            return result ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
