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
	public partial class Week3_Page : ContentPage
    {

        public int set_max = 20;

        public int W3_1_completed;
        public int W3_2_completed;
        public int W3_3_completed = 0;
        public int W3_4_completed = 0;
        public int W3_5_completed = 0;
        public int W3_6_completed = 0;
        public int W3_7_completed = 0;
        public int W3_8_completed = 0;
        public int W3_9_completed = 0;

        public Week3_Page(int cpl)
        {
            InitializeComponent();

            W3_1_completed = cpl;

            if (W3_1_completed == 11)
            {
                btnW3_2_img.Source = "small_yescheck.png";
                btnW3_2.IsEnabled = true;
                btnW3_2.FontAttributes = FontAttributes.Bold;
                btnW3_1.IsEnabled = false;
                btnW3_1.FontAttributes = FontAttributes.Italic;
            }
            else if (W3_1_completed == cpl && W3_1_completed != 11)
            {
                btnW3_1_img.Source = "small_starthere.png";
                btnW3_1.IsEnabled = true;
                btnW3_1.FontAttributes = FontAttributes.Bold;
            }


            W3_2_completed = cpl;

            if (W3_2_completed == 12 && W3_1_completed == cpl)
            {
                btnW3_3_img.Source = "small_yescheck.png";
                btnW3_1_img.Source = null;
                btnW3_1.IsEnabled = false;
                btnW3_1.FontAttributes = FontAttributes.Italic;
                btnW3_3.IsEnabled = true;
                btnW3_3.FontAttributes = FontAttributes.Bold;


            }


            W3_3_completed = cpl;

            if (W3_3_completed == 13 && W3_1_completed == cpl)
            {
                btnW3_4_img.Source = "small_yescheck.png";
                btnW3_1_img.Source = null;
                btnW3_1.IsEnabled = false;
                btnW3_1.FontAttributes = FontAttributes.Italic;
                btnW3_4.IsEnabled = true;
                btnW3_4.FontAttributes = FontAttributes.Bold;

            }

            W3_4_completed = cpl;

            if (W3_4_completed == 14 && W3_1_completed == cpl)
            {
                btnW3_5_img.Source = "small_yescheck.png";
                btnW3_1_img.Source = null;
                btnW3_1.IsEnabled = false;
                btnW3_1.FontAttributes = FontAttributes.Italic;
                btnW3_5.IsEnabled = true;
                btnW3_5.FontAttributes = FontAttributes.Bold;

            }


            W3_5_completed = cpl;

            if (W3_5_completed == 15 && W3_1_completed == cpl)
            {
                btnW3_6_img.Source = "small_yescheck.png";
                btnW3_1_img.Source = null;
                btnW3_1.IsEnabled = false;
                btnW3_1.FontAttributes = FontAttributes.Italic;
                btnW3_6.IsEnabled = true;
                btnW3_6.FontAttributes = FontAttributes.Bold;
            }


            W3_6_completed = cpl;

            if (W3_6_completed == 16 && W3_1_completed == cpl)
            {
                btnW3_7_img.Source = "small_yescheck.png";
                btnW3_1_img.Source = null;
                btnW3_1.IsEnabled = false;
                btnW3_1.FontAttributes = FontAttributes.Italic;
                btnW3_7.IsEnabled = true;
                btnW3_7.FontAttributes = FontAttributes.Bold;
            }


            W3_7_completed = cpl;

            if (W3_7_completed == 17 && W3_1_completed == cpl)
            {
                btnW3_8_img.Source = "small_yescheck.png";
                btnW3_1_img.Source = null;
                btnW3_1.IsEnabled = false;
                btnW3_1.FontAttributes = FontAttributes.Italic;
                btnW3_8.IsEnabled = true;
                btnW3_8.FontAttributes = FontAttributes.Bold;
            }


            W3_8_completed = cpl;

            if (W3_8_completed == 18 && W3_1_completed == cpl)
            {
                btnW3_9_img.Source = "small_yescheck.png";
                btnW3_1_img.Source = null;
                btnW3_1.IsEnabled = false;
                btnW3_1.FontAttributes = FontAttributes.Italic;
                btnW3_9.IsEnabled = true;
                btnW3_9.FontAttributes = FontAttributes.Bold;
            }


            W3_9_completed = cpl;

            if (W3_9_completed == 19 && W3_1_completed == cpl)
            {
                btnW3_9_img.Source = null;
                btnW3_1_img.Source = null;
                btnW3_1.FontAttributes = FontAttributes.Italic;
                btnW3_1.IsEnabled = false;

            }


        }

        private void Button1_W3_Clicked(object sender, EventArgs e)
        {
            W3_1_completed = 11;
            App.Current.MainPage = new Exercise_Page(20, "TKegel", 3, W3_1_completed);
        }

        private void Button2_W3_Clicked(object sender, EventArgs e)
        {
            W3_2_completed = 12;
            App.Current.MainPage = new Exercise_Page(20, "RKegel", 3, W3_2_completed);

        }

        private void Button3_W3_Clicked(object sender, EventArgs e)
        {
            int W3_3_completed = 13;
            App.Current.MainPage = new Exercise_Page(90, "HSquat", 3, W3_3_completed);

        }

        private void Button4_W3_Clicked(object sender, EventArgs e)
        {
            int W3_4_completed = 14;
            App.Current.MainPage = new Exercise_Page(15, "FSquat", 3, W3_4_completed);

        }

        private void Button5_W3_Clicked(object sender, EventArgs e)
        {
            int W3_5_completed = 15;
            App.Current.MainPage = new Exercise_Page(10, "FSquat", 3, W3_5_completed);

        }

        private void Button6_W3_Clicked(object sender, EventArgs e)
        {
            int W3_6_completed = 16;
            App.Current.MainPage = new Exercise_Page(10, "FSquat", 3, W3_6_completed);

        }

        private void Button7_W3_Clicked(object sender, EventArgs e)
        {
            int W3_7_completed = 17;
            App.Current.MainPage = new Exercise_Page(20, "Hold_Squat", 3, W3_7_completed);

        }

        private void Button8_W3_Clicked(object sender, EventArgs e)
        {
            int W3_8_completed = 18;
            App.Current.MainPage = new Exercise_Page(20, "TKegel", 3, W3_8_completed);
        }

        private void Button9_W3_Clicked(object sender, EventArgs e)
        {
            int W3_9_completed = 19;
            App.Current.MainPage = new Exercise_Page(20, "RKegel", 3, W3_9_completed);

        }
    }
}