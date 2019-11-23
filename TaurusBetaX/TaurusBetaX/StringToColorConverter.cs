using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;


namespace TaurusBetaX
{
    public class StringToColorConverter : IValueConverter

    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueAsString = value.ToString();
            switch (valueAsString)
            {
                case ("Not scheduled for today"):
                    {
                        return Color.Red;
                    }
                case ("Accent"):
                    {
                        return Color.Accent;
                    }
                default:
                    {
                        return Color.FromHex(value.ToString());
                    }
            }
            

        }   
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion




    }

}
