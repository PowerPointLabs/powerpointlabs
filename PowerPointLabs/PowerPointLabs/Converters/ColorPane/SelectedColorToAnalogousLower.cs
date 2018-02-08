﻿using System;
using System.Windows.Data;
using PowerPointLabs.ColorPicker;

namespace PowerPointLabs.Converters.ColorPane
{
    class SelectedColorToAnalogousLower : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            HSLColor selectedColor = (HSLColor)value;
            return ColorHelper.GetColorShiftedByAngle(selectedColor, -30.0f);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
