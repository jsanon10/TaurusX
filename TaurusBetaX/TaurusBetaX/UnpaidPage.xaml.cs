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
    public partial class UnpaidPage : ContentPage
    {
        public UnpaidPage(string name, string email, string preferredUsername)
        {
            InitializeComponent();
        }

        private void Upgrade_btn_Clicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new DisclaimerPage(true);


        }

        private void Freenium_btn_Clicked(object sender, System.EventArgs e)
        {

            App.Current.MainPage = new DisclaimerPage(false);




        }
    }
}