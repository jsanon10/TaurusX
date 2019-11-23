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
	public partial class Week2_Page : ContentPage
    {

        public int set_max = 20;

        public int W2_1_completed;
        public int W2_2_completed;
        public int W2_3_completed = 0;
        public int W2_4_completed = 0;
        public int W2_5_completed = 0;
        public int W2_6_completed = 0;
        public int W2_7_completed = 0;
        public int W2_8_completed = 0;
        public int W2_9_completed = 0;

        public Week2_Page(int cpl)
        {
            InitializeComponent();

            W2_1_completed = cpl;

            if (W2_1_completed == 11)
            {
                btnW2_2_img.Source = "small_yescheck.png";
                btnW2_2.IsEnabled = true;
                btnW2_2.FontAttributes = FontAttributes.Bold;
                btnW2_1.IsEnabled = false;
                btnW2_1.FontAttributes = FontAttributes.Italic;
            }
            else if (W2_1_completed == cpl && W2_1_completed != 11)
            {
                btnW2_1_img.Source = "small_starthere.png";
                btnW2_1.IsEnabled = true;
                btnW2_1.FontAttributes = FontAttributes.Bold;
            }


            W2_2_completed = cpl;

            if (W2_2_completed == 12 && W2_1_completed == cpl)
            {
                btnW2_3_img.Source = "small_yescheck.png";
                btnW2_1_img.Source = null;
                btnW2_1.IsEnabled = false;
                btnW2_1.FontAttributes = FontAttributes.Italic;
                btnW2_3.IsEnabled = true;
                btnW2_3.FontAttributes = FontAttributes.Bold;


            }


            W2_3_completed = cpl;

            if (W2_3_completed == 13 && W2_1_completed == cpl)
            {
                btnW2_4_img.Source = "small_yescheck.png";
                btnW2_1_img.Source = null;
                btnW2_1.IsEnabled = false;
                btnW2_1.FontAttributes = FontAttributes.Italic;
                btnW2_4.IsEnabled = true;
                btnW2_4.FontAttributes = FontAttributes.Bold;

            }

            W2_4_completed = cpl;

            if (W2_4_completed == 14 && W2_1_completed == cpl)
            {
                btnW2_5_img.Source = "small_yescheck.png";
                btnW2_1_img.Source = null;
                btnW2_1.IsEnabled = false;
                btnW2_1.FontAttributes = FontAttributes.Italic;
                btnW2_5.IsEnabled = true;
                btnW2_5.FontAttributes = FontAttributes.Bold;

            }


            W2_5_completed = cpl;

            if (W2_5_completed == 15 && W2_1_completed == cpl)
            {
                btnW2_6_img.Source = "small_yescheck.png";
                btnW2_1_img.Source = null;
                btnW2_1.IsEnabled = false;
                btnW2_1.FontAttributes = FontAttributes.Italic;
                btnW2_6.IsEnabled = true;
                btnW2_6.FontAttributes = FontAttributes.Bold;
            }


            W2_6_completed = cpl;

            if (W2_6_completed == 16 && W2_1_completed == cpl)
            {
                btnW2_7_img.Source = "small_yescheck.png";
                btnW2_1_img.Source = null;
                btnW2_1.IsEnabled = false;
                btnW2_1.FontAttributes = FontAttributes.Italic;
                btnW2_7.IsEnabled = true;
                btnW2_7.FontAttributes = FontAttributes.Bold;
            }


            W2_7_completed = cpl;

            if (W2_7_completed == 17 && W2_1_completed == cpl)
            {
                btnW2_8_img.Source = "small_yescheck.png";
                btnW2_1_img.Source = null;
                btnW2_1.IsEnabled = false;
                btnW2_1.FontAttributes = FontAttributes.Italic;
                btnW2_8.IsEnabled = true;
                btnW2_8.FontAttributes = FontAttributes.Bold;
            }


            W2_8_completed = cpl;

            if (W2_8_completed == 18 && W2_1_completed == cpl)
            {
                btnW2_9_img.Source = "small_yescheck.png";
                btnW2_1_img.Source = null;
                btnW2_1.IsEnabled = false;
                btnW2_1.FontAttributes = FontAttributes.Italic;
                btnW2_9.IsEnabled = true;
                btnW2_9.FontAttributes = FontAttributes.Bold;
            }


            W2_9_completed = cpl;

            if (W2_9_completed == 19 && W2_1_completed == cpl)
            {
                btnW2_9_img.Source = null;
                btnW2_1_img.Source = null;
                btnW2_1.FontAttributes = FontAttributes.Italic;
                btnW2_1.IsEnabled = false;

            }


        }

        private void Button1_W2_Clicked(object sender, EventArgs e)
        {
            W2_1_completed = 11;
            App.Current.MainPage = new Exercise_Page(20, "TKegel", 2, W2_1_completed);
        }

        private void Button2_W2_Clicked(object sender, EventArgs e)
        {
            W2_2_completed = 12;
            App.Current.MainPage = new Exercise_Page(20, "RKegel", 2, W2_2_completed);

        }

        private void Button3_W2_Clicked(object sender, EventArgs e)
        {
            int W2_3_completed = 13;
            App.Current.MainPage = new Exercise_Page(90, "HSquat", 2, W2_3_completed);

        }

        private void Button4_W2_Clicked(object sender, EventArgs e)
        {
            int W2_4_completed = 14;
            App.Current.MainPage = new Exercise_Page(15, "FSquat", 2, W2_4_completed);

        }

        private void Button5_W2_Clicked(object sender, EventArgs e)
        {
            int W2_5_completed = 15;
            App.Current.MainPage = new Exercise_Page(10, "FSquat", 2, W2_5_completed);

        }

        private void Button6_W2_Clicked(object sender, EventArgs e)
        {
            int W2_6_completed = 16;
            App.Current.MainPage = new Exercise_Page(10, "FSquat", 2, W2_6_completed);

        }

        private void Button7_W2_Clicked(object sender, EventArgs e)
        {
            int W2_7_completed = 17;
            App.Current.MainPage = new Exercise_Page(20, "Hold_Squat", 2, W2_7_completed);

        }

        private void Button8_W2_Clicked(object sender, EventArgs e)
        {
            int W2_8_completed = 18;
            App.Current.MainPage = new Exercise_Page(20, "TKegel", 2, W2_8_completed);
        }

        private void Button9_W2_Clicked(object sender, EventArgs e)
        {
            int W2_9_completed = 19;
            App.Current.MainPage = new Exercise_Page(20, "RKegel", 2, W2_9_completed);

        }
    }
}