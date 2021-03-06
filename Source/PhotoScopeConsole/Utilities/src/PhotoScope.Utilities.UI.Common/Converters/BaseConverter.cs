using System;
using System.Globalization;
using System.Windows.Data;

namespace PhotoScope.Utilities.UI.Common.Converters
{
    public abstract class BaseConverter : IValueConverter
    {

        #region IValueConverter Members

        /// <summary>
        ///     Abstract convert implementation.
        /// </summary>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        ///     Virtual convert back implementation.
        /// </summary>
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        #endregion
    }
}
