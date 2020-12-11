using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
namespace Dashboard1
{
    public class ImageConverter1 : IValueConverter
    {
        public static ImageConverter1 Instance = new ImageConverter1();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var CategoryId = (int)value;
            if (CategoryId == 0)
            {
                return "BlenderSoftware";
            }
            else
            {
                return "CardAccountDetailsStarOutline";
            }
            // If the path is null, ignore
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
