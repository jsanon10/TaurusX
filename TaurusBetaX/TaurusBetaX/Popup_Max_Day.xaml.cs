using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

using Xamarin.Forms;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popup_Max_Day : PopupPage
    {
   
        public Popup_Max_Day(string current_active_week)
        {

            InitializeComponent();

            max_workout_message.Text = "You have reached the maximum day of workout for " + current_active_week ;
        }

        private void Ok_button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();

        }
    }
}