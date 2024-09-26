using System.Globalization;

namespace MauiTestApp.Components
{

    public class EnumConverter : IValueConverter
    {
        public EnumConverter()
        {
        }

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || value is not Enum)
            {
                throw new NotImplementedException();
            }

          return value.ToString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || value is not string || !targetType.IsEnum)
            {
                throw new NotImplementedException();
            }

            Enum.TryParse(targetType, (string)value, out var result);
            return result;
        }

    }
}
