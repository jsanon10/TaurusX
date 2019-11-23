using System;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaurusBetaX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Workout_Selection_Page : ContentPage
	{
        bool is_paid;
        int repetition;
        string exercise_choice = "none";

        


        public Workout_Selection_Page (bool paid, int ex_rep, string ex_choice)
		{
			InitializeComponent ();

            
            intro_btn.Text = "<< Back";
            exercise_btn.IsEnabled = false;

            is_paid = paid;
            repetition = ex_rep;
            exercise_choice = ex_choice;
            

            Traditional_K_Button_Clicked();
            Half_Squat_Button_Clicked();
            Reverse_K_Button_Clicked();
            Full_Squat_Button_Clicked();
            Hold_Squat_Button_Clicked();

            switch (exercise_choice)
            {
                case "TKegel":
                    exercise_btn.IsEnabled = true;
                    Traditional_K_Count.BackgroundColor = Color.Green;
                    Traditional_K_Count.Text = "Ready for " + repetition+ " Reps";
                   break;

                case "RKegel":
                    exercise_btn.IsEnabled = true;
                    Reverse_K_Count.BackgroundColor = Color.Green;
                    Reverse_K_Count.Text = "Ready for " + repetition + " Reps";
                    break;

                //case "HSquat":
                //    exercise_btn.IsEnabled = true;
                //    Half_Squat_Count.BackgroundColor = Color.Green;
                //    Half_Squat_Count.Text = "Ready for " + repetition + " Reps";
                //    break;

                case "FSquat":
                    exercise_btn.IsEnabled = true;
                    Full_Squat_Count.BackgroundColor = Color.Green;
                    Full_Squat_Count.Text = "Ready for " + repetition + " Reps";
                    break;

                case "Hold_Squat":
                    exercise_btn.IsEnabled = true;
                    Hold_Squat_Count.BackgroundColor = Color.Green;
                    Hold_Squat_Count.Text = "Ready for " + repetition + " Reps";
                    break;

            }






        }

        void Traditional_K_Button_Clicked()
        {
            Traditional_K_Button.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
               {
                   //App.Current.MainPage = new Repetition_Page(is_paid);
                  // PopupNavigation.Instance.PushAsync(new Popup_Repetitions(is_paid, null/*, repetition, "TKegel"*/));
               })
            });
        }

        void Half_Squat_Button_Clicked()
        {
            Half_Squat_Button.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    //App.Current.MainPage = new Repetition_Page(is_paid);
                  //  PopupNavigation.Instance.PushAsync(new Popup_Repetitions(is_paid, null/*, repetition, "HSquat"*/));
                })
            });
        }

        void Reverse_K_Button_Clicked()
        {
            Reverse_K_Button.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    //App.Current.MainPage = new Repetition_Page(is_paid);
                   // PopupNavigation.Instance.PushAsync(new Popup_Repetitions(is_paid, null/*, repetition, "RKegel"*/));
                })
            });
        }

        void Full_Squat_Button_Clicked()
        {
            Full_Squat_Button.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    //App.Current.MainPage = new Repetition_Page(is_paid);
                   // PopupNavigation.Instance.PushAsync(new Popup_Repetitions(is_paid, null/*, repetition, "FSquat"*/));
                })
            });
        }

        void Hold_Squat_Button_Clicked()
        {
            Hold_Squat_Button.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    //App.Current.MainPage = new Repetition_Page(is_paid);
                //   PopupNavigation.Instance.PushAsync(new Popup_Repetitions(is_paid, null/* repetition, "Hold_Squat"*/));
                })
            });
        }

        //private void Traditional_K_Button_Clicked(object sender, EventArgs e)
        //{
        //    App.Current.MainPage = new Repetition_Page(is_paid);
        //}

        //private void Half_Squat_Button_Clicked(object sender, EventArgs e)
        //{
        //    App.Current.MainPage = new Repetition_Page(is_paid);
        //}

        //private void Reverse_K_Button_Clicked(object sender, EventArgs e)
        //{
        //    App.Current.MainPage = new Repetition_Page(is_paid);
        //}

        //private void Full_Squat_Button_Clicked(object sender, EventArgs e)
        //{
        //    App.Current.MainPage = new Repetition_Page(is_paid);
        //}

        //private void Hold_Squat_Button_Clicked(object sender, EventArgs e)
        //{
        //    App.Current.MainPage = new Repetition_Page(is_paid);
        //}

        private void Intro_Page_Btn_Clicked(object sender, EventArgs e)
        {   
            App.Current.MainPage = new IntroPage(is_paid);
        }

        public void Excercise_Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Exercise_Page(repetition, exercise_choice, 5, 0);
        }

    }
}