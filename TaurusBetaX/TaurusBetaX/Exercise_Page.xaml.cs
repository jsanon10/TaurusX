using MediaManager;
using MediaManager.Playback;
using MediaManager.Library;
using MediaManager.Media;
using Rg.Plugins.Popup.Services;
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
    public partial class Exercise_Page : TabbedPage
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
        int days_to_hours;
        int hours_countdown_2;
        int minutes_countdown_2;
        bool is_waiting;
        int is_active;

        DateTime today_datetime = DateTime.Now;
        string today_string;
        DateTime yesterday_datetime;
        string yesterday_string;
        DateTime next_workout_date;

        //int hours_countdown;
        //int minutes_countdown;

        int day_difference;
        int hour_difference;
        int minute_difference;
        int next_hour;
       

        // public override event MediaItemFinishedEventHandler MediaItemFinished;
        //public void Current_MediaFinished(object sender, MediaManager.Media.MediaItemEventArgs e)

        public Exercise_Page(int newID, string newWorkout, string newExercise, string newWorkType, int newCount, bool eX_done, bool wK_done, int ex_count, int wk_count, bool waiting, int hours, int minutes)
        {
            InitializeComponent();

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
            is_waiting = waiting;
            wkDone_count = wk_count;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                //Pulling data from SQLITE database and add them to a List
                conn.CreateTable<WeekTraining>();

                var setworkouts = conn.Table<WeekTraining>().ToList();

                var verify_Active2 = (from b in setworkouts
                                     where b.MyWorkout.Equals(mWork)
                                     select b.Active).ToList();

                if (is_waiting != true && verify_Active2[0] == true)
                {

                btnStart.IsEnabled = false;

                CrossTextToSpeech.Current.Speak("Go to the exercise tab");
                Thread.Sleep(1000);
                CrossTextToSpeech.Current.Speak("Then Press the start button, to begin");

                

                }

            }

                
            

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

           btnStart.IsEnabled = true;

        }

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

        public void Play_Active_Workout()
        {

            if (is_waiting == false)
            {

                if (btnStart.Text == "Resume")
                {
                    CrossMediaManager.Current.Play();

                }

                else if (count < mCount)
                {
                    Play_Exercise();
                }


                if (count >= mCount && btnStart.Text == "<< Back")
                {
                    count = 0;

                    if (is_exerciseDone == false)
                    {

                        is_exerciseDone = true;
                        is_workoutDone = true;

                    }

                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<WeekTraining>();

                        conn.Execute("UPDATE WeekTraining SET Checkmark = '" + done_checkmark + "' WHERE Id = '" + mID + "' ");
                        conn.Execute("UPDATE WeekTraining SET ExDone = true WHERE Id = '" + mID + "' ");
                        conn.Execute("UPDATE WeekTraining SET WkDone = true WHERE Id = '" + mID + "' ");

                        //var setworkouts = conn.Table<WeekTraining>().ToList();
                    }

                    App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);
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

            else
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    var setworkouts = conn.Table<WeekTraining>().ToList();

                    //Last time you exercised
                    var exerciseYesterday = (from w in setworkouts
                                             where w.MyWorkout.Equals(mWork)
                                             select w.Yesterday).Take(1).ToList();

                    foreach (var exYesterday in exerciseYesterday)
                    {
                        yesterday_string = exYesterday.ToString();
                        yesterday_datetime = DateTime.Parse(yesterday_string);
                    }


                    today_string = today_datetime.ToString();

                    TimeSpan date_diff = today_datetime.Subtract(yesterday_datetime); // the difference increases at every onAppear


                    int day_diff = date_diff.Days;
                    int hour_diff = date_diff.Hours;
                    int min_diff = date_diff.Minutes;

                    day_difference = day_diff;
                    days_to_hours = day_difference * 24;
                    hour_difference = hour_diff + days_to_hours;
                    minute_difference = min_diff;


                    hours_countdown_2 = 1 - hour_diff;
                    if (hours_countdown_2 < 0)
                    {
                        hours_countdown_2 = 1;
                    }


                    minutes_countdown_2 = 60 - min_diff;
                    next_workout_date = today_datetime.AddHours(hours_countdown_2);
                    next_hour = next_workout_date.Hour;


                    if (hour_difference <= 1)//(next_workout_date > today_datetime)
                    {
                        conn.Execute("UPDATE WeekTraining SET Wait= true WHERE MyWorkout=?", mWork);

                        var wait_status = (from a in setworkouts
                                           where a.MyWorkout.Equals(mWork)
                                           select a.Wait).Take(1).ToList();

                        foreach (var varWait in wait_status)
                        {
                            is_waiting = true;
                        }
                    }

                    else
                    {
                        conn.Execute("UPDATE WeekTraining SET Wait= false WHERE MyWorkout=?", mWork);

                        var wait_status = (from a in setworkouts
                                           where a.MyWorkout.Equals(mWork)
                                           select a.Wait).Take(1).ToList();

                        foreach (var varWait in wait_status)
                        {
                            is_waiting = false;
                        }
                    }

                    if (is_waiting == true)
                    {
                        PopupNavigation.Instance.PushAsync(new Popup_Wait_Hours(hours_countdown_2, minutes_countdown_2, mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_waiting));
                    }
                    else
                    {
                        App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);

                    }

                }

            }



        }

        private void Start_Btn_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                //Pulling data from SQLITE database and add them to a List
                conn.CreateTable<WeekTraining>();

                var setworkouts = conn.Table<WeekTraining>().ToList();

                var active_week = (from z in setworkouts
                                      where z.Active.Equals(true)
                                      select z).ToList();

                is_active = active_week.Count();

                if (is_active == 0 && wkDone_count < 4)
                {
                    //Set "Active" for the selected workout to "true"
                   var update_Active = (from a in setworkouts
                                        where a.MyWorkout.Equals(mWork)
                                        select a).ToList();

                    foreach (var u_active in update_Active)
                    {
                        u_active.Active = true;
                    }
                    conn.Execute("UPDATE WeekTraining SET Active= true WHERE MyWorkout=?", mWork);

                    //Find and Verify that workout where Active = true is equal to selected workout
                    var verify_Active = (from b in setworkouts
                                         where b.Active.Equals(true)
                                         select b.MyWorkout).ToList();

                    //**if they are equal play the workout
                    if (verify_Active[0] == mWork && wkDone_count < 4)
                    {
                        Play_Active_Workout();
                    }
                    //**if they are not equal, pop-up a message
                    else if (verify_Active[0] != mWork)
                    {
                        PopupNavigation.Instance.PushAsync(new Popup_Alert_Active_Page(verify_Active[0]));
                    }
                    else if (wkDone_count >= 4)
                    {
     
                        PopupNavigation.Instance.PushAsync(new Popup_Max_Day(verify_Active[0]));
                    }

                }

                else if (is_active != 0)
                {
                    //Find and Verify that workout where Active = true is equal to selected workout
                    var verify_Active = (from b in setworkouts
                                         where b.Active.Equals(true)
                                         select b.MyWorkout).ToList();

                    //**if they are equal play the workout
                    if (verify_Active[0] == mWork && wkDone_count < 4)
                    {
                        Play_Active_Workout();
                    }
                    //**if they are not equal, pop-up a message
                    else if (verify_Active[0] != mWork)
                    {
                        PopupNavigation.Instance.PushAsync(new Popup_Alert_Active_Page(verify_Active[0]));
                    }
                    else if (wkDone_count >= 4 && is_waiting == false )
                    {

                        PopupNavigation.Instance.PushAsync(new Popup_Max_Day(verify_Active[0]));
                    }

                    else if (wkDone_count >= 4 && is_waiting == true)
                    {
                        Play_Active_Workout();
                    }

                }

                if (is_active == 0 && wkDone_count >= 4)
                {

                    PopupNavigation.Instance.PushAsync(new Popup_Max_Day(mWork));

                }



            }

        }

        private void Pause_Btn_Clicked(object sender, EventArgs e)
        {
            txtStatus.Text = "Pause";
            btnPause.IsEnabled = false;
            btnStart.IsEnabled = true;
            btnStart.Text = "Resume";
            CrossMediaManager.Current.Pause();
            CrossTextToSpeech.Current.Dispose();
        }

        private void Reset_Btn_Clicked(object sender, EventArgs e)
        {

            if (count <= 0 && btnReset.Text == "Cancel" && page != 5 && is_paid == true)
            {

                App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);
                CrossTextToSpeech.Current.Dispose();
            }

            if (count <= 0 && btnReset.Text == "Cancel" && page != 5 && is_paid == false)
            {
                App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);
                CrossTextToSpeech.Current.Dispose();
            }

            else if (count > 0)
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
                CrossTextToSpeech.Current.Dispose();
                App.Current.MainPage = new Exercise_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_waiting, hours_countdown_2, minutes_countdown_2);
            }
        }
    }
}