using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class Popup_View : PopupPage
    {
        public Popup_View()
        {
            InitializeComponent();
        }

        private void Upgrade_btn_Clicked(object sender, EventArgs e)
        {

        }

        private void Keepfree_btn_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();

        }
    }
}