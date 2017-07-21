using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFValueConverter
{
    public class MultiValueConverter : IMultiValueConverter
    {
        private readonly Func<object[], Type, object, CultureInfo, object> convertFunction;

        public MultiValueConverter(Func<object[], Type, object, CultureInfo, object> convertFunction)
        {
            this.convertFunction = convertFunction;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return convertFunction?.Invoke(values, targetType, parameter, culture);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class MultiValueConverter<T1, T2> : MultiValueConverter
    {
        public MultiValueConverter(Func<T1, T2, object> convertFunction)
            : base(WrapConvertFunction(convertFunction))
        {
        }

        private static Func<object[], Type, object, CultureInfo, object> WrapConvertFunction(Func<T1, T2, object> f)
        {
            return (objects, targetType, parameter, culture) => f(
                (T1)System.Convert.ChangeType(objects[0], typeof(T1), culture),
                (T2)System.Convert.ChangeType(objects[1], typeof(T2), culture)
                );
        }
    }

    public class MultiValueConverter<T1, T2, T3> : MultiValueConverter
    {
        public MultiValueConverter(Func<T1, T2, T3, object> convertFunction)
            : base(WrapConvertFunction(convertFunction))
        {
        }

        private static Func<object[], Type, object, CultureInfo, object> WrapConvertFunction(Func<T1, T2, T3, object> f)
        {
            return (objects, targetType, parameter, culture) => f(
                (T1)System.Convert.ChangeType(objects[0], typeof(T1), culture),
                (T2)System.Convert.ChangeType(objects[1], typeof(T2), culture),
                (T3)System.Convert.ChangeType(objects[2], typeof(T3), culture)
                );
        }
    }

    public class MultiValueConverter<T1, T2, T3, T4> : MultiValueConverter
    {
        public MultiValueConverter(Func<T1, T2, T3, T4, object> convertFunction)
            : base(WrapConvertFunction(convertFunction))
        {
        }

        private static Func<object[], Type, object, CultureInfo, object> WrapConvertFunction(Func<T1, T2, T3, T4, object> f)
        {
            return (objects, targetType, parameter, culture) => f(
                (T1)System.Convert.ChangeType(objects[0], typeof(T1), culture),
                (T2)System.Convert.ChangeType(objects[1], typeof(T2), culture),
                (T3)System.Convert.ChangeType(objects[2], typeof(T3), culture),
                (T4)System.Convert.ChangeType(objects[3], typeof(T4), culture)
                );
        }
    }
}