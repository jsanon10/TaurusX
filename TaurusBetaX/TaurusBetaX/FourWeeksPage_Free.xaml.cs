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
	public partial class FourWeeksPage_Free : MasterDetailPage
	{
        bool is_paid;

		public FourWeeksPage_Free(bool intro, int week, int isComplete, bool paid)
		{
			InitializeComponent ();

            is_paid = paid;
            
            if (intro == true && week == 0)
            {
                IsPresented = true;
            }
            if (intro == false && week == 1)
            {
                Detail = new NavigationPage(new Week1_Page_Free(isComplete));
                IsPresented = false;
            }
            if (intro == false && week == 2)
            {
                Detail = new NavigationPage(new Week2_Page(isComplete));
                IsPresented = false;
            }
            if (intro == false && week == 3)
            {
                Detail = new NavigationPage(new Week3_Page(isComplete));
                IsPresented = false;
            }
            if (intro == false && week == 4)
            {
                Detail = new NavigationPage(new Week4_Page(isComplete));
                IsPresented = false;
            }

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

            Detail = new NavigationPage(new Week1_Page_Free(0)) { BarTextColor = Color.White };
            IsPresented = false; 

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Popup_View());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Popup_View());
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Popup_View());
        }

        private void Back_Button_Clicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new IntroPage(is_paid);
            //App.Current.MainPage = new NavigationPage(new IntroPage(is_paid));

        }
    }
}