using System.Globalization;

namespace MauiTestApp.Components
{
    public class BrokenMultiBindingConverter : IMultiValueConverter
    {

        public BrokenMultiBindingConverter()
        {
        }


        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var value1 = values[0];
            if (value1 == null)
            {
                return Binding.DoNothing;
            }

            var result = System.Convert.ChangeType(value1, targetType);

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return [Binding.DoNothing];
            }

            var result = System.Convert.ChangeType(value, targetTypes[0]);
            return [result];
        }
    }
}
