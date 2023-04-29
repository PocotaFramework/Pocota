using System.Globalization;
using System.Windows.Data;

namespace MaterialDesignThemes.Wpf.Converters
{
    internal class ComboBoxClearButtonMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(values[0] is Thickness padding))
            {
                padding = new Thickness();
            }
            if (!(values[1] is Thickness borderThickness))
            {
                borderThickness = new Thickness();
            }
            if (!(values[2] is Thickness anotherThickness))
            {
                anotherThickness = new Thickness();
            }
            var floatingHintTopOffset = anotherThickness.Top;
            return new Thickness(
                borderThickness.Left,
                borderThickness.Top + padding.Top + floatingHintTopOffset,
                borderThickness.Right + padding.Right + Constants.ComboBoxArrowSize + Constants.TextBoxInnerButtonSpacing,
                borderThickness.Bottom + padding.Bottom);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
