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
	public partial class Week4_Page : ContentPage
    {

        public int set_max = 20;

        public int W4_1_completed;
        public int W4_2_completed;
        public int W4_3_completed = 0;
        public int W4_4_completed = 0;
        public int W4_5_completed = 0;
        public int W4_6_completed = 0;
        public int W4_7_completed = 0;
        public int W4_8_completed = 0;
        public int W4_9_completed = 0;

        public Week4_Page(int cpl)
        {
            InitializeComponent();

            W4_1_completed = cpl;

            if (W4_1_completed == 11)
            {
                btnW4_2_img.Source = "small_yescheck.png";
                btnW4_2.IsEnabled = true;
                btnW4_2.FontAttributes = FontAttributes.Bold;
                btnW4_1.IsEnabled = false;
                btnW4_1.FontAttributes = FontAttributes.Italic;
            }
            else if (W4_1_completed == cpl && W4_1_completed != 11)
            {
                btnW4_1_img.Source = "small_starthere.png";
                btnW4_1.IsEnabled = true;
                btnW4_1.FontAttributes = FontAttributes.Bold;
            }


            W4_2_completed = cpl;

            if (W4_2_completed == 12 && W4_1_completed == cpl)
            {
                btnW4_3_img.Source = "small_yescheck.png";
                btnW4_1_img.Source = null;
                btnW4_1.IsEnabled = false;
                btnW4_1.FontAttributes = FontAttributes.Italic;
                btnW4_3.IsEnabled = true;
                btnW4_3.FontAttributes = FontAttributes.Bold;


            }


            W4_3_completed = cpl;

            if (W4_3_completed == 13 && W4_1_completed == cpl)
            {
                btnW4_4_img.Source = "small_yescheck.png";
                btnW4_1_img.Source = null;
                btnW4_1.IsEnabled = false;
                btnW4_1.FontAttributes = FontAttributes.Italic;
                btnW4_4.IsEnabled = true;
                btnW4_4.FontAttributes = FontAttributes.Bold;

            }

            W4_4_completed = cpl;

            if (W4_4_completed == 14 && W4_1_completed == cpl)
            {
                btnW4_5_img.Source = "small_yescheck.png";
                btnW4_1_img.Source = null;
                btnW4_1.IsEnabled = false;
                btnW4_1.FontAttributes = FontAttributes.Italic;
                btnW4_5.IsEnabled = true;
                btnW4_5.FontAttributes = FontAttributes.Bold;

            }


            W4_5_completed = cpl;

            if (W4_5_completed == 15 && W4_1_completed == cpl)
            {
                btnW4_6_img.Source = "small_yescheck.png";
                btnW4_1_img.Source = null;
                btnW4_1.IsEnabled = false;
                btnW4_1.FontAttributes = FontAttributes.Italic;
                btnW4_6.IsEnabled = true;
                btnW4_6.FontAttributes = FontAttributes.Bold;
            }


            W4_6_completed = cpl;

            if (W4_6_completed == 16 && W4_1_completed == cpl)
            {
                btnW4_7_img.Source = "small_yescheck.png";
                btnW4_1_img.Source = null;
                btnW4_1.IsEnabled = false;
                btnW4_1.FontAttributes = FontAttributes.Italic;
                btnW4_7.IsEnabled = true;
                btnW4_7.FontAttributes = FontAttributes.Bold;
            }


            W4_7_completed = cpl;

            if (W4_7_completed == 17 && W4_1_completed == cpl)
            {
                btnW4_8_img.Source = "small_yescheck.png";
                btnW4_1_img.Source = null;
                btnW4_1.IsEnabled = false;
                btnW4_1.FontAttributes = FontAttributes.Italic;
                btnW4_8.IsEnabled = true;
                btnW4_8.FontAttributes = FontAttributes.Bold;
            }


            W4_8_completed = cpl;

            if (W4_8_completed == 18 && W4_1_completed == cpl)
            {
                btnW4_9_img.Source = "small_yescheck.png";
                btnW4_1_img.Source = null;
                btnW4_1.IsEnabled = false;
                btnW4_1.FontAttributes = FontAttributes.Italic;
                btnW4_9.IsEnabled = true;
                btnW4_9.FontAttributes = FontAttributes.Bold;
            }


            W4_9_completed = cpl;

            if (W4_9_completed == 19 && W4_1_completed == cpl)
            {
                btnW4_9_img.Source = null;
                btnW4_1_img.Source = null;
                btnW4_1.FontAttributes = FontAttributes.Italic;
                btnW4_1.IsEnabled = false;

            }


        }

        private void Button1_W4_Clicked(object sender, EventArgs e)
        {
            W4_1_completed = 11;
            App.Current.MainPage = new Exercise_Page(20, "TKegel", 4, W4_1_completed);
        }

        private void Button2_W4_Clicked(object sender, EventArgs e)
        {
            W4_2_completed = 12;
            App.Current.MainPage = new Exercise_Page(20, "RKegel", 4, W4_2_completed);

        }

        private void Button3_W4_Clicked(object sender, EventArgs e)
        {
            int W4_3_completed = 13;
            App.Current.MainPage = new Exercise_Page(90, "HSquat", 4, W4_3_completed);

        }

        private void Button4_W4_Clicked(object sender, EventArgs e)
        {
            int W4_4_completed = 14;
            App.Current.MainPage = new Exercise_Page(15, "FSquat", 4, W4_4_completed);

        }

        private void Button5_W4_Clicked(object sender, EventArgs e)
        {
            int W4_5_completed = 15;
            App.Current.MainPage = new Exercise_Page(10, "FSquat", 4, W4_5_completed);

        }

        private void Button6_W4_Clicked(object sender, EventArgs e)
        {
            int W4_6_completed = 16;
            App.Current.MainPage = new Exercise_Page(10, "FSquat", 4, W4_6_completed);

        }

        private void Button7_W4_Clicked(object sender, EventArgs e)
        {
            int W4_7_completed = 17;
            App.Current.MainPage = new Exercise_Page(20, "Hold_Squat", 4, W4_7_completed);

        }

        private void Button8_W4_Clicked(object sender, EventArgs e)
        {
            int W4_8_completed = 18;
            App.Current.MainPage = new Exercise_Page(20, "TKegel", 4, W4_8_completed);
        }

        private void Button9_W4_Clicked(object sender, EventArgs e)
        {
            int W4_9_completed = 19;
            App.Current.MainPage = new Exercise_Page(20, "RKegel", 4, W4_9_completed);

        }
    }
}