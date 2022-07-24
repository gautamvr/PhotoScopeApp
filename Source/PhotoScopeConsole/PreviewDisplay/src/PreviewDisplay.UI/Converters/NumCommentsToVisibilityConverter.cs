using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using PhotoScope.Utilities.UI.Common.Converters;

namespace PreviewDisplay.UI.Converters
{
    public class NumCommentsToVisibilityConverter:BaseConverter
    {
        public static IValueConverter Instance { get; } = new NumCommentsToVisibilityConverter();

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int numComments) && numComments > 0)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        
    }
}
