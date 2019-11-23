using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using TaurusBetaX;
using TaurusBetaX.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform;
using Xamarin.Forms.Platform.Android;



[assembly: Xamarin.Forms.ExportRenderer(typeof(Toro_Picker), typeof(Toro_Picker_android))]

namespace TaurusBetaX.Droid
{
    public class Toro_Picker_android : PickerRenderer
    {
        public Toro_Picker_android(Context context) : base(context)
        {
            AutoPackage = false;
        }

        private AlertDialog _dialog;


        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Gravity = GravityFlags.CenterHorizontal;
                //Xamarin.Forms.But
                Control.Text = "---";




            }
        }
    }
}