using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TaurusBetaX.Model
{
    public class MyViewCell 
    {
        public MyViewCell()
        {
            Image Checkmark = new Image();

            Checkmark.SetBinding(Image.SourceProperty, "small_round_check.jpg");

        }
        // public string MyImage { get; set; }

        //public string GetIcon()
        //{ }

        //MyImage

    }
}
