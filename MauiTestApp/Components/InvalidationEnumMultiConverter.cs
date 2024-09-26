using System.Globalization;

namespace MauiTestApp.Components
{
    internal class InvalidationEnumMultiConverter : IMultiValueConverter
    {
        private readonly EnumConverter _enumConverter = new();

        private const string INVALIDATION_MARKER = "(i)";

        public InvalidationEnumMultiConverter()
        {
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2)
            {
                throw new NotImplementedException();
            }

            var value0 = values[0] as bool?;
            if (value0 == null)
            {
                return null;
            }
            

            var value1 = values[1] as Enum;
            if (value1 == null)
            {
                return null;
            }

            var prefix = value0 == true ? INVALIDATION_MARKER : "";
            var result = _enumConverter.Convert(value1, targetType, parameter, culture);

            return $"{prefix}{result}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value == null || targetTypes.Length != 2)
            {
                throw new NotImplementedException();
            }

            var invalidation = false;
            var valueString = value as string;
            if (valueString != null && valueString.StartsWith(INVALIDATION_MARKER))
            {
                invalidation = true;
                valueString = valueString.Replace(INVALIDATION_MARKER, string.Empty);
            }

            var targetType = targetTypes[1];
            return new object[] { invalidation, _enumConverter.ConvertBack(valueString, targetType, parameter, culture) };
        }
    }
}
