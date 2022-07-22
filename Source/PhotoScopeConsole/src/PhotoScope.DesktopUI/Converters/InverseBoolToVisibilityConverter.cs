using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using PhotoScope.Utilities.UI.Common;

namespace PhotoScope.DesktopUI.Converters
{
    public class InverseBoolToVisibilityConverter : BaseConverter
    {
        /// <summary>
        ///     Instance of this converter
        /// </summary>
        public static IValueConverter Instance { get; } = new InverseBoolToVisibilityConverter();

        /// <summary>
        /// Converts boolean to it's invert Visibility.
        /// </summary>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && bool.TryParse(value.ToString(), out var boolValue))
            {
                return boolValue ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Collapsed;
        }
    }
}
