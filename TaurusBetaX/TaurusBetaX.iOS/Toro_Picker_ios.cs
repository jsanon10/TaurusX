using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using TaurusBetaX;
using TaurusBetaX.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Toro_Picker), typeof(Toro_Picker_ios))]

namespace TaurusBetaX.iOS
{
    public class Toro_Picker_ios : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextAlignment = UITextAlignment.Center;

                //Control.Text = "---";

               


            }
        }
    }
}