using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaurusBetaX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DisclaimerPage : ContentPage
	{
        bool is_paid;

		public DisclaimerPage (bool paid)
		{
			InitializeComponent ();
            btnDisclaimer.IsEnabled = false;
            btnDisclaimer.IsEnabled = false;
            is_paid = paid;

            
        }

       

        public void Button_Clicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new IntroPage(is_paid);
           // App.Current.MainPage = new NavigationPage(new IntroPage(is_paid));
        }

        private void CheckBox_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            if (chkDisclaimer.Checked == true)
                btnDisclaimer.IsEnabled = true;
            else if (chkDisclaimer.Checked == false)
                btnDisclaimer.IsEnabled = false;
        }

        private void CheckBox_Unfocused(object sender, FocusEventArgs e)
        {
            btnDisclaimer.IsEnabled = false;
        }
    }
}