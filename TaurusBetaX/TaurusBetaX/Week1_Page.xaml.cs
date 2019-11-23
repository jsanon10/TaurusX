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
	public partial class Week1_Page : ContentPage
	{
        
        public int set_max = 20;
          
        public int W1_1_completed;
        public int W1_2_completed;
        public int W1_3_completed = 0;
        public int W1_4_completed = 0;
        public int W1_5_completed = 0;
        public int W1_6_completed = 0;
        public int W1_7_completed = 0;
        public int W1_8_completed = 0;
        public int W1_9_completed = 0;

        public Week1_Page(int cpl)
        {
            InitializeComponent();

            W1_1_completed = cpl;

            if (W1_1_completed == 11)
            {
                btnW1_2_img.Source = "small_yescheck.png";
                btnW1_2.IsEnabled = true;
                btnW1_2.FontAttributes = FontAttributes.Bold;
                btnW1_1.IsEnabled = false;
                btnW1_1.FontAttributes = FontAttributes.Italic;
            }
            else if (W1_1_completed == cpl && W1_1_completed != 11)
            {
                btnW1_1_img.Source = "small_starthere.png";
                btnW1_1.IsEnabled = true;
                btnW1_1.FontAttributes = FontAttributes.Bold;
            }


            W1_2_completed = cpl;

            if (W1_2_completed == 12 && W1_1_completed == cpl)
            {
                btnW1_3_img.Source = "small_yescheck.png";
                btnW1_1_img.Source = null;
                btnW1_1.IsEnabled = false;
                btnW1_1.FontAttributes = FontAttributes.Italic;
                btnW1_3.IsEnabled = true;
                btnW1_3.FontAttributes = FontAttributes.Bold;


            }


            W1_3_completed = cpl;

            if (W1_3_completed == 13 && W1_1_completed == cpl)
            {
                btnW1_4_img.Source = "small_yescheck.png";
                btnW1_1_img.Source = null;
                btnW1_1.IsEnabled = false;
                btnW1_1.FontAttributes = FontAttributes.Italic;
                btnW1_4.IsEnabled = true;
                btnW1_4.FontAttributes = FontAttributes.Bold;

            }

            W1_4_completed = cpl;

            if (W1_4_completed == 14 && W1_1_completed == cpl)
            {
                btnW1_5_img.Source = "small_yescheck.png";
                btnW1_1_img.Source = null;
                btnW1_1.IsEnabled = false;
                btnW1_1.FontAttributes = FontAttributes.Italic;
                btnW1_5.IsEnabled = true;
                btnW1_5.FontAttributes = FontAttributes.Bold;

            }


            W1_5_completed = cpl;

            if (W1_5_completed == 15 && W1_1_completed == cpl)
            {
                btnW1_6_img.Source = "small_yescheck.png";
                btnW1_1_img.Source = null;
                btnW1_1.IsEnabled = false;
                btnW1_1.FontAttributes = FontAttributes.Italic;
                btnW1_6.IsEnabled = true;
                btnW1_6.FontAttributes = FontAttributes.Bold;
            }


            W1_6_completed = cpl;

            if (W1_6_completed == 16 && W1_1_completed == cpl)
            {
                btnW1_7_img.Source = "small_yescheck.png";
                btnW1_1_img.Source = null;
                btnW1_1.IsEnabled = false;
                btnW1_1.FontAttributes = FontAttributes.Italic;
                btnW1_7.IsEnabled = true;
                btnW1_7.FontAttributes = FontAttributes.Bold;
            }


            W1_7_completed = cpl;

            if (W1_7_completed == 17 && W1_1_completed == cpl)
            {
                btnW1_8_img.Source = "small_yescheck.png";
                btnW1_1_img.Source = null;
                btnW1_1.IsEnabled = false;
                btnW1_1.FontAttributes = FontAttributes.Italic;
                btnW1_8.IsEnabled = true;
                btnW1_8.FontAttributes = FontAttributes.Bold;
            }


            W1_8_completed = cpl;

            if (W1_8_completed == 18 && W1_1_completed == cpl)
            {
                btnW1_9_img.Source = "small_yescheck.png";
                btnW1_1_img.Source = null;
                btnW1_1.IsEnabled = false;
                btnW1_1.FontAttributes = FontAttributes.Italic;
                btnW1_9.IsEnabled = true;
                btnW1_9.FontAttributes = FontAttributes.Bold;
            }


            W1_9_completed = cpl;

            if (W1_9_completed == 19 && W1_1_completed == cpl)
            {
                btnW1_9_img.Source = null;
                btnW1_1_img.Source = null;
                btnW1_1.FontAttributes = FontAttributes.Italic;
                btnW1_1.IsEnabled = false;

            }


        }

        private void Button1_W1_Clicked(object sender, EventArgs e)
        {
            W1_1_completed = 11;
            App.Current.MainPage = new Exercise_Page(20, "TKegel", 1, W1_1_completed);
        }

        private void Button2_W1_Clicked(object sender, EventArgs e)
        {
            W1_2_completed = 12;
            App.Current.MainPage = new Exercise_Page(20, "RKegel", 1, W1_2_completed);

        }

        private void Button3_W1_Clicked(object sender, EventArgs e)
        {
            int W1_3_completed = 13;
            App.Current.MainPage = new Exercise_Page(50, "HSquat", 1, W1_3_completed);

        }

        private void Button4_W1_Clicked(object sender, EventArgs e)
        {
            int W1_4_completed = 14;
            App.Current.MainPage = new Exercise_Page(15, "FSquat", 1, W1_4_completed);

        }

        private void Button5_W1_Clicked(object sender, EventArgs e)
        {
            int W1_5_completed = 15;
            App.Current.MainPage = new Exercise_Page(10, "FSquat", 1, W1_5_completed);

        }

        private void Button6_W1_Clicked(object sender, EventArgs e)
        {
            int W1_6_completed = 16;
            App.Current.MainPage = new Exercise_Page(10, "FSquat", 1, W1_6_completed);

        }

        private void Button7_W1_Clicked(object sender, EventArgs e)
        {
            int W1_7_completed = 17;
            App.Current.MainPage = new Exercise_Page(20, "Hold_Squat", 1, W1_7_completed);

        }

        private void Button8_W1_Clicked(object sender, EventArgs e)
        {
            int W1_8_completed = 18;
            App.Current.MainPage = new Exercise_Page(20, "TKegel", 1, W1_8_completed);
        }

        private void Button9_W1_Clicked(object sender, EventArgs e)
        {
            int W1_9_completed = 19;
            App.Current.MainPage = new Exercise_Page(20, "RKegel", 1, W1_9_completed);

        }
    }
}