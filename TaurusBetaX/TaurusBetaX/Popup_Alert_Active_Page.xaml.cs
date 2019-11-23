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
    public partial class Popup_Alert_Active_Page : PopupPage
    {
        public Popup_Alert_Active_Page(string current_active_week)
        {
            InitializeComponent();

            week_Workout_Number.Text = current_active_week + " workout is still active. Please complete it before proceeding";
        }

        private void Ok_button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();

        }
    }
}