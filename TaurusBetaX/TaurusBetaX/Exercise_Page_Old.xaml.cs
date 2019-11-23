
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using TaurusBetaX.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exercise_Page_Old : TabbedPage
    {
        int count = 0;
        bool is_paid;
        Timer timer;
        int max;
        int mID;
        int page;
        int exComplete;
        int origin;
        string mExercise;
        string mWork;
        string w_type;
        string videoUrl;

        //List<SetWorkout> exerciseList = new List<SetWorkout>();
        //List<string> list3 = new List<string>() {"RKegel", "HSquat", "FSquat" };
   


        public void Play_Exercise()
        {
            if (count < max)
            {
                count++;

                Device.BeginInvokeOnMainThread(() =>
                {
                    txtTimer.Text = "" + count;
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {

                        CrossMediaManager.Current.Stop();
                        btnStart.Text = "<< Back";
                        txtTimer.Text = "End of Set";
                        btnPause.IsEnabled = false;
                        btnStart.IsEnabled = true;
                        txtTimer.FontSize = 30;
                        CrossMediaManager.Current.MediaQueue.Clear();
                        CrossMediaManager.Current.MediaFinished -= Current_MediaFinished;
                    
                });

            }
        }

        public void  Current_MediaFinished(object sender, Plugin.MediaManager.Abstractions.EventArguments.MediaFinishedEventArgs e)
        {
            Play_Exercise();   
        }

        public Exercise_Page_Old(int maxSet, string workout_type, int wpage, int completed)
		{
			InitializeComponent ();
            //Prepare_Exercise(maxSet, workout_type, wpage, completed);
            //item = list3[index];
            btnPause.IsEnabled = false;
            btnReset.IsEnabled = true;
            btnReset.Text = "Cancel";
            max = maxSet;
            page = wpage;
            w_type = workout_type;

            exComplete = completed;
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;



            switch (workout_type)
            {
                case "TKegel":
                    directions_img1.Source = "WWW30minutewalk.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;

                case "RKegel":
                    directions_img1.Source = "WWWbadknees.jpg";
                    directions_img2.Source = "WWWcatchingfire.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;

                case "HSquat":
                    directions_img1.Source = "WWWcatchingfire.jpg";
                    directions_img2.Source = "WWW30minutewalk.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;

                case "FSquat":
                    directions_img1.Source = "WWWepicabsintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;

                case "Hold_Squat":
                    directions_img1.Source = "WWWepicarmintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;

                case "TKegel_FREE":
                    directions_img1.Source = "WWW30minutewalk.jpg";
                    directions_img2.Source = "WWWepicarmintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;

                case "RKegel_FREE":
                    directions_img1.Source = "WWWbadknees.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;

                case "HSquat_FREE":
                    directions_img1.Source = "WWWcatchingfire.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;

                case "FSquat_FREE":
                    directions_img1.Source = "WWWepicabsintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;

                case "Hold_Squat_FREE":
                    directions_img1.Source = "WWWepicarmintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;
            }


        }

        private void Start_Btn_Clicked(object sender, EventArgs e)
        {

            if (btnStart.Text == "Resume")
            {
                CrossMediaManager.Current.PlaybackController.Play();   
            }

            else if (count < max)
            {
               CrossMediaManager.Current.Play(videoUrl, MediaFileType.Video);
               CrossMediaManager.Current.MediaQueue.Repeat = RepeatType.RepeatAll;
            }

            
            if (count >= max && is_paid == true && page != 5 && btnStart.Text != "Continue")
            {    
                count = 0;
                App.Current.MainPage = new FourWeeksPage(false, page, exComplete, is_paid);
            }

            if (count >= max && is_paid == false && page != 5 && btnStart.Text != "Continue")
            {
                count = 0;
                App.Current.MainPage = new FourWeeksPage_Free(false, page, exComplete, is_paid);
            }

            if (count >= max && page == 5 && btnStart.Text != "Continue")
            {
                w_type = "none";
                App.Current.MainPage = new Workout_Selection_Page(is_paid, max, w_type);
            }

            else
            {

                txtStatus.Text = "";
                txtTimer.FontSize = 50;
                btnStart.Text = "Start";
                btnReset.Text = "Reset";
                btnPause.IsEnabled = true;
                btnReset.IsEnabled = true;
                btnStart.IsEnabled = false;
            }

        }


        private void Pause_Btn_Clicked(object sender, EventArgs e)
        {
            txtStatus.Text = "Pause";
            btnPause.IsEnabled = false;
            btnStart.IsEnabled = true;
            btnStart.Text = "Resume";
            CrossMediaManager.Current.Pause();
        }

        private void Reset_Btn_Clicked(object sender, EventArgs e)
        {

            if (count <= 0 && btnReset.Text == "Cancel" && page != 5 && is_paid == true)
            {
                App.Current.MainPage = new FourWeeksPage(false, page, exComplete -1, is_paid);
            }

            if (count <= 0 && btnReset.Text == "Cancel" && page != 5 && is_paid == false)
            {
                App.Current.MainPage = new FourWeeksPage_Free(false, page, exComplete - 1, is_paid);
            }

            if (count <= 0 && btnReset.Text == "Cancel" && page == 5)
            {
                w_type = "none";
                //App.Current.MainPage = new Workout_Selection_Page(is_paid, max, w_type);
               // App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, w_type, max);
            }

            else
            {
                txtStatus.Text = "";
                txtTimer.FontSize = 50;
                btnStart.IsEnabled = true;
                btnPause.IsEnabled = false;
                count = 0;
                btnReset.Text = "Cancel";
                btnStart.Text = "Start";
                CrossMediaManager.Current.Stop();
                Device.BeginInvokeOnMainThread(() =>
                {
                    txtTimer.Text = "" + count;
                });
            }
        }
    }
}