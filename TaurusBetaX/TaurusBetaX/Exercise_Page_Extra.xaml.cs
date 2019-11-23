using MediaManager;
using MediaManager.Playback;
using MediaManager.Library;
using MediaManager.Media;
using MediaManager.Player;
using MediaManager.Queue;
//using Plugin.MediaManager;
//using Plugin.MediaManager.Abstractions.Enums;
//using Plugin.MediaManager.Abstractions.EventArguments;
using SQLite;
using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

using TaurusBetaX.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exercise_Page_Extra : TabbedPage
    {
        int count = 0;
        bool is_paid = true;
        //Timer timer;
        int mCount;
        int mID;
        int page = 1;
        int exComplete;
        int origin;
        string mExercise;
        string mWork;
        string mWorkType;
        string done_checkmark = "small_round_check.jpg";
        bool is_exerciseDone;
        bool is_workoutDone;
        int exDone_count;
        int wkDone_count;
        string videoUrl;
        string text_Count;
        string action1;
        string action2;



        public void Current_MediaFinished(object sender, MediaItemEventArgs e)
        {


            count++;

            text_Count = count.ToString();
            Device.BeginInvokeOnMainThread(() =>
            {
                txtTimer.Text = "" + count;
            });

            if (count <= mCount)
            {

                CrossTextToSpeech.Current.Speak(action2);
                CrossTextToSpeech.Current.Speak(text_Count);
            }



            Play_Exercise();

        }

        public void Play_Exercise()
        {
            if (count <= mCount)
            {

                if (count == 0)
                {
                    CrossTextToSpeech.Current.Speak("Ready");
                    CrossTextToSpeech.Current.Speak("Set");
                    CrossTextToSpeech.Current.Speak("Go");
                    CrossTextToSpeech.Current.Speak(action1);
                    CrossMediaManager.Current.PlayFromResource("threefourth.mp4");
                }
                else
                {
                    CrossTextToSpeech.Current.Speak(action1);
                    CrossMediaManager.Current.SeekToStart();
                    CrossMediaManager.Current.Play();
                }
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
                        //CrossMediaManager.Current.MediaQueue.Clear();
                        CrossMediaManager.Current.Queue.Clear();
                        //CrossMediaManager.Current.MediaFinished -= Current_MediaFinished;
                        CrossMediaManager.Current.MediaItemFinished -= Current_MediaFinished;
                        //CrossMediaManager.Current.

                });

            }
        }

        public Exercise_Page_Extra(int newID, string newWorkout, string newExercise, string newWorkType, int newCount, bool eX_done, bool wK_done, int ex_count, int wk_count)
		{
			InitializeComponent ();

            btnPause.IsEnabled = false;
            btnReset.IsEnabled = true;
            btnReset.Text = "Cancel";
            mID = newID;
            mCount = newCount;
            mWork = newWorkout;
            mExercise = newExercise;
            mWorkType = newWorkType;
            is_exerciseDone = eX_done;
            is_workoutDone = wK_done;

            CrossTextToSpeech.Current.Speak("Go to the exercise tab");
            Thread.Sleep(1000);
            CrossTextToSpeech.Current.Speak("Then Press the start button, to begin");

            //CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
            CrossMediaManager.Current.MediaItemFinished += Current_MediaFinished;




            switch (newWorkType)
            {
                case "TKegel":
                    directions_img1.Source = "WWW30minutewalk.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    action1 = "squeeze";
                    action2 = "release";
                    break;

                case "RKegel":
                    directions_img1.Source = "WWWbadknees.jpg";
                    directions_img2.Source = "WWWcatchingfire.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    action1 = "expand";
                    action2 = "relax";
                    break;

                case "HSquat":
                    directions_img1.Source = "WWWcatchingfire.jpg";
                    directions_img2.Source = "WWW30minutewalk.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    action1 = "squat";
                    action2 = "rise up";
                    break;

                case "FSquat":
                    directions_img1.Source = "WWWepicabsintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    action1 = "squat";
                    action2 = "rise up";
                    break;

                case "Hold_Squat":
                    directions_img1.Source = "WWWepicarmintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    action1 = "hold";
                    action2 = "hold";
                    break;

                case "CKegel":
                    directions_img1.Source = "WWWepicarmintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    break;

                case "TKegel_FREE":
                    directions_img1.Source = "WWW30minutewalk.jpg";
                    directions_img2.Source = "WWWepicarmintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    action1 = "squeeze";
                    action2 = "release";
                    break;

                case "RKegel_FREE":
                    directions_img1.Source = "WWWbadknees.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    action1 = "expand";
                    action2 = "relax";
                    break;

                case "HSquat_FREE":
                    directions_img1.Source = "WWWcatchingfire.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    action1 = "squat";
                    break;

                case "FSquat_FREE":
                    directions_img1.Source = "WWWepicabsintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    action1 = "squat";
                    action2 = "rise up";
                    break;

                case "Hold_Squat_FREE":
                    directions_img1.Source = "WWWepicarmintro.jpg";
                    videoUrl = "https://axel.isouard.fr/media/mov_bbb.mp4";
                    action1 = "hold";
                    action2 = "hold";
                    break;
            }


        }

        private void Start_Btn_Clicked(object sender, EventArgs e)
        {

            if (btnStart.Text == "Resume")
            {
                //CrossMediaManager.Current.PlaybackController.Play();   
                CrossMediaManager.Current.Play();
            }

            else if (count < mCount)
            {
                //CrossMediaManager.Current.Play(videoUrl, MediaFileType.Video);
                //CrossMediaManager.Current.MediaQueue.Repeat = RepeatType.RepeatAll;
                Play_Exercise();

            }


            if (count >= mCount && btnStart.Text == "<< Back")
            {
                count = 0;

                if (is_exerciseDone == false)
                {
                    is_exerciseDone = true;

                }

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();
                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    var ex_counter = (from w in setworkouts
                                       where w.MyWorkout.Equals(mWork)
                                       select w.ExDone_count).ToList();
                    exDone_count = ex_counter[0];
                    exDone_count++;

                    conn.Execute("UPDATE SetWorkout SET Checkmark = '" + done_checkmark + "' WHERE Id = '"+ mID +"' ");
                    conn.Execute("UPDATE SetWorkout SET ExDone_count = '" + exDone_count + "' WHERE Id = '" + mWork + "' ");
                    conn.Execute("UPDATE SetWorkout SET ExDone= true WHERE Id = '" + mID + "' ");
                }

                App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);
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
                App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);
            }

            if (count <= 0 && btnReset.Text == "Cancel" && page != 5 && is_paid == false)
            {
                App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);
            }

            if (count <= 0 && btnReset.Text == "Cancel" && page == 5)
            {
                App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);
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
                CrossMediaManager.Current.MediaItemFinished += Current_MediaFinished;
                CrossMediaManager.Current.Stop();
                Device.BeginInvokeOnMainThread(() =>
                {
                    txtTimer.Text = "" + count;
                });
            }
        }
    }
}