using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFValueConverter
{
    public class ValueConverter<T> : ValueConverter
    {
        public ValueConverter(Func<T, object> convertFunction)
            : base(WrapConvertFunction(convertFunction))
        {
        }

        private static Func<object, Type, object, CultureInfo, object> WrapConvertFunction(Func<T, object> f)
        {
            return (objValue, targetType, parameter, culture) => f(
                (T)System.Convert.ChangeType(objValue, typeof(T), culture));
        }
    }

    public class ValueConverter : IValueConverter
    {
        private readonly Func<object, Type, object, CultureInfo, object> convertFunction;

        public ValueConverter(Func<object, Type, object, CultureInfo, object> convertFunction)
        {
            this.convertFunction = convertFunction;
        }

        public object Convert(object value, Type targetType, object parameter = null, CultureInfo culture = null)
        {
            return convertFunction?.Invoke(value, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}