﻿using System;
using System.Globalization;
using System.Windows.Data;
using PhotoScope.Utilities.UI.Common.Converters;

namespace PhotoFeed.UI.Converters
{
    public class ResultsTagToTextConverter : BaseConverter
    {
        public static IValueConverter Instance { get;  } = new ResultsTagToTextConverter();

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return $"Showing results for the tag \"{value}\"";
            }

            return "";
        }
    }
}
