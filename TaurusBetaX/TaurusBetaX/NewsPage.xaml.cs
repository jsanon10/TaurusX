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
    public partial class NewsPage : ContentPage
    {
        bool is_paid;

        public NewsPage(bool paid)
        {
            InitializeComponent();
            is_paid = paid;

            webInstruction.Source = "https://www.toruflex.com/news";
        }



        private void Web_Instruction_Navigated(object sender, WebNavigatedEventArgs e)
        {

            LoadingLabel.IsVisible = false;

        }

        private void startButton_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new DisclaimerPage(is_paid);
            App.Current.MainPage = new IntroPage(is_paid);

        }

        private void backButton_Clicked(object sender, EventArgs e)
        {

            if (webInstruction.CanGoBack)
            {
                webInstruction.GoBack();
            }

        }

        private void forwardButton_Clicked(object sender, EventArgs e)
        {
            if (webInstruction.CanGoForward)
            {
                webInstruction.GoForward();
            }



        }
    }
}