using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaurusBetaX
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
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
