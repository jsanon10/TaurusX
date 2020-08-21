using System;
using System.Globalization;
//using SampleValueConverters.Enums;
using Xamarin.Forms;

namespace TaurusBetaX.ValueConverters
{
    public class PlatformToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (value == null)
            //    return Color.Black;

            //if (!Enum.TryParse(value.ToString(), out string enumValue))
            //    return Color.Black;

            string enumValue = value.ToString(); ;

            switch (enumValue)
            {
                case "Completed":
                    return Color.DodgerBlue;

                case "Ready":
                    return Color.Green;

                case "In Progress":
                    return Color.SpringGreen;

                case "Set for today":
                    return Color.SteelBlue;

                case "On break today":
                    return Color.LightSteelBlue;

                case "Un-Scheduled":
                    return Color.SlateGray;

                default:
                    return Color.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}