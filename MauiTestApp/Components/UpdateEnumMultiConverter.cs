using System.Globalization;

namespace MauiTestApp.Components
{
    internal class UpdateEnumMultiConverter : IMultiValueConverter
    {
        private readonly EnumConverter _enumConverter = new();

        public UpdateEnumMultiConverter()
        {
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2)
            {
                throw new NotImplementedException();
            }

            var value = values[1];
            if (value == null) {
                return null;
            }

            return _enumConverter.Convert(value, targetType, parameter, culture);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value == null || targetTypes.Length != 2)
            {
                throw new NotImplementedException();
            }

            var targetType = targetTypes[1];
            return new object[] { null, _enumConverter.ConvertBack(value, targetType, parameter, culture) };
        }
    }
}
