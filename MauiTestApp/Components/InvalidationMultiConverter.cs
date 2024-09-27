using System.Globalization;

namespace MauiTestApp.Components
{
    internal class InvalidationMultiConverter : IMultiValueConverter
    {
        private readonly IValueConverter? _converter;

        private const string INVALIDATION_MARKER = "(i)";

        public InvalidationMultiConverter(IValueConverter? converter)
        {
            _converter = converter;
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
                return Binding.DoNothing;
            }
            

            var value1 = values[1];
            if (value1 == null)
            {
                return Binding.DoNothing;
            }

            var prefix = value0 == true ? INVALIDATION_MARKER : "";
            var result = _converter?.Convert(value1, targetType, parameter, culture);

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
            var result = _converter?.ConvertBack(valueString, targetType, parameter, culture);
            return new object[] { invalidation, result };
        }
    }
}
