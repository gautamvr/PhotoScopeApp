﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using PhotoScope.Utilities.UI.Common;
using PhotoScope.Utilities.UI.Common.Converters;

namespace PhotoScope.DesktopUI.Converters
{
    public class NumCommentsToTextConverter : BaseConverter
    {
        public static IValueConverter Instance { get; } = new NumCommentsToTextConverter();

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int numComments) && numComments > 0)
            {
                return $"The number of comments are {numComments}";
            }

            return "There are no comments for this item";
        }
    }
}
