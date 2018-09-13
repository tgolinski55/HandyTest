using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HandyTest.Resources.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(
       object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var path = string.Format(@"C:\Users\{0}.png", value);
                return new BitmapImage(new Uri(path));
            }
            catch (Exception ex)
            {
                return null; // or some default image
            }
        }

        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
