using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Dashboard1
{
    /// <summary>
    /// Converts a full path to a specific image type of a drive, folder or file
    /// </summary>
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object test, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the full path
            var test1 = (Test)test;

            // If the path is null, ignore
            if (test1.CateId == 1)
                return "Fullscreen";
            else
                return "FullscreenExit";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
