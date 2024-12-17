using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace EnhancedNotepad
{
    public class DueDateColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DateTime dueDate && dueDate != default)
            {
                return dueDate < DateTime.Now ? Colors.Red : Colors.Black;
            }
            return Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
