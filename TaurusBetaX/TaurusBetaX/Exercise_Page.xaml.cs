
using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using Xamarin.Essentials;
using Lottie.Forms;
using TaurusBetaX.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Speech.Synthesis;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exercise_Page : CustomTabbedPage
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
        string mWork_1 = "Week 1";
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
        bool vibrationOnBool;
        int is_active;
        int delay1;
        int delay2;
        float animationSpeed;
        DateTime today_datetime = DateTime.Now;
        string today_string;
        DateTime yesterday_datetime;
        string yesterday_string;
        DateTime next_workout_date;

        int day_difference;
        int hour_difference;
        int minute_difference;
        int next_hour;
        int from;
        SpeechSynthesizer synth = new SpeechSynthesizer();



        // public override event MediaItemFinishedEventHandler MediaItemFinished;
        //public void Current_MediaFinished(object sender, MediaManager.Media.MediaItemEventArgs e)

        public Exercise_Page(int newID, string newWorkout, string newExercise, string newWorkType, int newCount, bool eX_done, bool wK_done, int ex_count, int wk_count, bool waiting, int hours, int minutes, bool paid)
        {
           
            InitializeComponent();

            is_paid = paid;

            btnPause.IsEnabled = false;
            btnReset.IsEnabled = true;
            btnReset.Text = "Exit";
            mID = newID;
            mCount = newCount;
            mWork = newWorkout;
            mExercise = newExercise;
            mWorkType = newWorkType;
            is_exerciseDone = eX_done;
            is_workoutDone = wK_done;
            is_waiting = waiting;
            wkDone_count = wk_count;
            txtTimer.FontSize = 100;


            // CrossTextToSpeech.Current.Dispose();
         

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

                    //TextToSpeech.SpeakAsync("Go to the exercise tab", new SpeechOptions
                    //{
                    //    Pitch = 0.0f
                    //}) ; 
                    //Thread.Sleep(800);
                    //TextToSpeech.SpeakAsync("Then Press the start button, to begin", new SpeechOptions
                    //{
                    //    Pitch = 0.0f
                    //});

                    synth.Speak("Go to the exercise tab. Then Press the start button, to begin");



                }

                //Verify vibrate status
                var verifyVibrate = (from v in setworkouts
                                     where v.MyWorkout.Equals(mWork)
                                     select v.VibrationOn).ToList();

                vibrationOnBool = verifyVibrate[0];

                if (vibrationOnBool == true)
                {
                    vibrateButton.Text = "On   ";
                    vibrateButton.TextColor = Color.Green;
                }

                else if (vibrationOnBool == false)
                {
                    vibrateButton.Text = "Off   ";
                    vibrateButton.TextColor = Color.LightGray;
                }

            }

            if (is_paid == true)
            {
                switch (newWorkType)
                {
                    case "TKegelRapid":
                        webInstruction.Source = "https://www.toruflex.com/traditional-kegel";
                        delay1 = 0;
                        delay2 = 0;
                        animationSpeed = 1.5f;
                        videoUrl = "newKegelTrad.json";
                        animationView.Animation = videoUrl;
                        action1 = "squeeze";
                        action2 = "release";
                        break;

                    case "TKegel":
                        webInstruction.Source = "https://www.toruflex.com/traditional-kegel";
                        delay1 = 1000;
                        delay2 = 4000;
                        animationSpeed = 1.0f;
                        videoUrl = "newKegelTrad.json";
                        animationView.Animation = videoUrl;
                        action1 = "squeeze";
                        action2 = "release";
                        break;

                    case "TKegelHold":
                        webInstruction.Source = "https://www.toruflex.com/traditional-kegel";
                        delay1 = 0;
                        delay2 = 0;
                        animationSpeed = 2.0f;
                        videoUrl = "KegelHold.json";
                        animationView.Animation = videoUrl;
                        action1 = "";
                        action2 = "";
                        break;

                    case "RKegel":
                        webInstruction.Source = "https://www.toruflex.com/reverse-kegel";
                        delay1 = 1000;
                        delay2 = 4000;
                        animationSpeed = 1.0f;
                        videoUrl = "newKegelRev.json";
                        animationView.Animation = videoUrl;
                        action1 = "expand";
                        action2 = "relax";
                        break;

                    case "RKegelHold":
                        webInstruction.Source = "https://www.toruflex.com/reverse-kegel";
                        delay1 = 0;
                        delay2 = 0;
                        animationSpeed = 1.5f;
                        videoUrl = "KegelReverseHold.json";
                        animationView.Animation = videoUrl;
                        action1 = "";
                        action2 = "";
                        break;

                    case "RKegelRapid":
                        webInstruction.Source = "https://www.toruflex.com/reverse-kegel";
                        delay1 = 0;
                        delay2 = 0;
                        animationSpeed = 2.0f;
                        videoUrl = "newKegelRev.json";
                        animationView.Animation = videoUrl;
                        action1 = "expand";
                        action2 = "relax";
                        break;

                    case "HSquat":
                        webInstruction.Source = "https://www.toruflex.com/sumo-heel-squat";
                        delay1 = 1000;
                        delay2 = 5000;
                        animationSpeed = 0.6f;
                        videoUrl = "HalfSquatWarmUp.json";
                        animationView.Animation = videoUrl;
                        action1 = "squat";
                        action2 = "rise up";
                        break;

                    case "FSquat":
                        webInstruction.Source = "https://www.toruflex.com/sumo-heel-squat";
                        delay1 = 1000;
                        delay2 = 300; 
                        animationSpeed = 0.6f;
                        videoUrl = "NewHeelSquat2.json";
                        animationView.Animation = videoUrl;
                        action1 = "squat";
                        action2 = "rise up";
                        break;

                    case "Hold_Squat":
                        webInstruction.Source = "https://www.toruflex.com/crunches";
                        delay1 = 1000;
                        delay2 = 500;
                        animationSpeed = 1.0f;
                        videoUrl = "HalfSquatWarmUp.json";
                        animationView.Animation = videoUrl;
                        //action1 = "hold";
                        action2 = "hold";
                        break;

                    case "CKegel":
                        webInstruction.Source = "https://www.toruflex.com/crunches";
                        delay1 = 1000;
                        delay2 = 6000;
                        animationSpeed = 1.0f;
                        videoUrl = "HeelSquat.json";
                        animationView.Animation = videoUrl;
                        break;

                    case "TKegel_FREE":
                        webInstruction.Source = "https://www.toruflex.com/traditional-kegel";
                        delay1 = 1000;
                        delay2 = 6000;
                        animationSpeed = 1.0f;
                        videoUrl = "newKegelTrad.json";
                        animationView.Animation = videoUrl;
                        action1 = "squeeze";
                        action2 = "release";
                        break;

                    case "RKegel_FREE":
                        webInstruction.Source = "https://www.toruflex.com/reverse-kegel";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "newKegelRev.json";
                        animationView.Animation = videoUrl;
                        action1 = "expand";
                        action2 = "relax";
                        break;

                    case "HSquat_FREE":
                        webInstruction.Source = "https://www.toruflex.com/sumo-heel-squat";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "HeelSquat.json";
                        animationView.Animation = videoUrl;
                        action1 = "squat";
                        break;

                    case "FSquat_FREE":
                        webInstruction.Source = "https://www.toruflex.com/sumo-heel-squat";
                        delay1 = 1000;
                        delay2 = 6000;
                        animationSpeed = 0.6f;
                        videoUrl = "HeelSquat.json";
                        animationView.Animation = videoUrl;
                        action1 = "squat";
                        action2 = "rise up";
                        break;

                    case "Hold_Squat_FREE":
                        webInstruction.Source = "https://www.toruflex.com/crunches";
                        delay1 = 1000;
                        delay2 = 6000;
                        animationSpeed = 0.6f;
                        videoUrl = "HeelSquat.json";
                        animationView.Animation = videoUrl;
                        action1 = "hold";
                        action2 = "hold";
                        break;

                    case "HRKegel":
                        webInstruction.Source = "https://www.toruflex.com/crunches";
                        delay1 = 1000;
                        delay2 = 3000;                      
                        animationSpeed = 1.0f;
                        videoUrl = "HeelReverse.json";
                        animationView.Animation = videoUrl;
                        action1 = "expand";
                        action2 = "relax";
                        break;

                    case "Bridges":
                        webInstruction.Source = "https://www.toruflex.com/bridge";
                        delay1 = 1000;
                        delay2 = 4000;
                        animationSpeed = 1.0f;
                        videoUrl = "NewHipRaise.json";
                        animationView.Animation = videoUrl;
                        action1 = "rise";
                        action2 = "relax";
                        break;
                }

            }

            else if (is_paid == false)
            {
                switch (newWorkType)
                {

                    case "TKegel":
                        webInstruction.Source = "https://www.toruflex.com/traditional-kegel";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "newKegelTrad.json";
                        animationView.Animation = videoUrl;
                        action1 = "squeeze";
                        action2 = "release";
                        break;

                    case "RKegel":
                        webInstruction.Source = "https://www.toruflex.com/reverse-kegel";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "newKegelRev.json";
                        animationView.Animation = videoUrl;
                        action1 = "expand";
                        action2 = "relax";
                        break;

                    case "HSquat":
                        webInstruction.Source = "https://www.toruflex.com/sumo-heel-squat";
                        delay1 = 1000;
                        delay2 = 5000;
                        videoUrl = "HalfSquatWarmUp.json";
                        animationView.Animation = videoUrl;
                        action1 = "squat";
                        action2 = "rise up";
                        break;

                    case "FSquat":
                        webInstruction.Source = "https://www.toruflex.com/sumo-heel-squat";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "NewHeelSquat2.json";
                        animationView.Animation = videoUrl;
                        action1 = "squat";
                        action2 = "rise up";
                        break;

                    case "Hold_Squat":
                        webInstruction.Source = "https://www.toruflex.com/crunches";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "HalfSquatWarmUp.json";
                        animationView.Animation = videoUrl;
                        //action1 = "hold";
                        action2 = "hold";
                        break;

                    case "CKegel":
                        webInstruction.Source = "https://www.toruflex.com/crunches";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "HeelSquat.json";
                        animationView.Animation = videoUrl;
                        break;

                    case "TKegel_FREE":
                        webInstruction.Source = "https://www.toruflex.com/traditional-kegel";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "newKegelTrad.json";
                        animationView.Animation = videoUrl;
                        action1 = "squeeze";
                        action2 = "release";
                        break;

                    case "RKegel_FREE":
                        webInstruction.Source = "https://www.toruflex.com/reverse-kegel";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "newKegelRev.json";
                        animationView.Animation = videoUrl;
                        action1 = "expand";
                        action2 = "relax";
                        break;

                    case "HSquat_FREE":
                        webInstruction.Source = "https://www.toruflex.com/sumo-heel-squat";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "HeelSquat.json";
                        animationView.Animation = videoUrl;
                        action1 = "squat";
                        break;

                    case "FSquat_FREE":
                        webInstruction.Source = "https://www.toruflex.com/sumo-heel-squat";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "NewHeelSquat2.json";
                        animationView.Animation = videoUrl;
                        action1 = "squat";
                        action2 = "rise up";
                        break;

                    case "Hold_Squat_FREE":
                        webInstruction.Source = "https://www.toruflex.com/crunches";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "HeelSquat.json";
                        animationView.Animation = videoUrl;
                        action1 = "hold";
                        action2 = "hold";
                        break;

                    case "HRKegel":
                        webInstruction.Source = "https://www.toruflex.com/crunches";
                        delay1 = 1000;
                        delay2 = 3000;
                        videoUrl = "HeelReverse.json";
                        animationView.Animation = videoUrl;
                        action1 = "expand";
                        action2 = "relax";
                        break;


                    case "Bridges":
                        webInstruction.Source = "https://www.toruflex.com/bridge";
                        delay1 = 1000;
                        delay2 = 4000;
                        videoUrl = "NewHipRaise.json";
                        animationView.Animation = videoUrl;
                        action1 = "rise";
                        action2 = "relax";
                        break;
                }
            }

            btnStart.IsEnabled = true;
        }

        public void SayAction(string speach)
        {
            TextToSpeech.SpeakAsync(speach, new SpeechOptions
            {
                Pitch = 0.0f
            });
        }

        public void Vibrate()
        {
            if (vibrationOnBool == true)
            {
                Vibration.Vibrate();
            }
        }


        public void Play_And_Count()
        {
            Thread.Sleep(delay1);
            count++;
            text_Count = count.ToString();
            Device.BeginInvokeOnMainThread(() =>
            {
                txtTimer.FontSize = 100;
                txtTimer.Text = "" + count;

            });

            if (count <= mCount && count != 1)
            {
                SayAction(text_Count);
                Thread.Sleep(delay2);
                Play_Exercise();
            }
            else 
            {
                Play_Exercise();
            }
        }

        public void Play_Exercise()
        {
            if (count <= mCount)
            {
                if (count == 0)
                {
                    TextToSpeech.SpeakAsync("ready..... set..... go", new SpeechOptions
                    {
                        Pitch = 0.0f                   
                    });

                    Thread.Sleep(3000);
                    Play_And_Count();
                }
                else
                {
                    animationView.PlayMinAndMaxProgress(0.1f, 1.0f);
                    animationView.Speed = animationSpeed;     
                    SayAction(text_Count);            
                    SayAction(action1);
                    Vibrate();
                    animationView.PlayAnimation();
                }
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Vibrate();
                    SayAction(action2);
                    animationView.AbortAnimation(videoUrl);                  
                    btnStart.Text = "<< Back";
                    txtTimer.Text = "End of the exercise";
                    btnPause.IsEnabled = false;
                    btnStart.IsEnabled = true;
                    txtTimer.FontSize = 30;
                    instruction_page.IsEnabled = true;
                    count = mCount;
                    animationView.PlayMinAndMaxProgress(0.0f, 0.0f);
                    TextToSpeech.SpeakAsync("End of the exercise", new SpeechOptions
                    {
                        Pitch = 0.0f
                    });
                });
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
            }
        }

        public void Play_Active_Workout()
        {

            if (is_waiting == false)
            {

                if (btnStart.Text == "Resume")
                {
                    animationView.PlayAnimation();
                }

                else if (count < mCount)
                {
                    Play_Exercise();
                }


                if (count >= mCount && btnStart.Text == "<< Back")
                {
                    //END OF EXERCISE
                    count = 0;
                    App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
                }

                else
                {
                    txtStatus.Text = "";
                    switch (Device.RuntimePlatform)
                    {
                        case Device.iOS:
                        txtTimer.FontSize = 100;
                            break;
                        case Device.Android:
                            txtTimer.FontSize = 100;
                                break; ;
                        default:
                            txtTimer.FontSize = 100;
                            break;
                    }
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
                        PopupNavigation.Instance.PushAsync(new Popup_Wait_Hours(hours_countdown_2, minutes_countdown_2, mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_waiting, is_paid));
                    }
                    else
                    {
                        App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
                    }

                }

            }

        }

        private void Animation_View_On_Finish(object sender, EventArgs e)
        {
            count++;

            Thread.Sleep(delay2);    

            if (count <= mCount && count != 1)
            {
                text_Count = count.ToString();
                Device.BeginInvokeOnMainThread(() =>
                {
                    txtTimer.FontSize = 100;
                    txtTimer.Text = "" + count;
                });

                animationView.AbortAnimation(videoUrl);
                
                SayAction(action2);

                Vibrate();

                Play_Exercise();
            }
            else if (txtTimer.Text != "End of the exercise" && count > mCount)
            {
                Play_Exercise();
            }         
        }

        private void Start_Btn_Clicked(object sender, EventArgs e)
        {
            instruction_page.IsEnabled = false;

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
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
            animationView.PauseAnimation();
        }

        private void Reset_Btn_Clicked(object sender, EventArgs e)
        {

            if (count <= 0 && btnReset.Text == "Exit" && page != 5 && is_paid == true)
            {
                App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);             
            }

            if (count <= 0 && btnReset.Text == "Exit" && page != 5 && is_paid == false)
            {
                App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
            }

            else if (count > 0)
            {
                txtStatus.Text = "";
                txtTimer.FontSize = 100;
                btnStart.IsEnabled = true;
                btnPause.IsEnabled = false;
                count = 0;
                btnReset.Text = "Exit";
                btnStart.Text = "Start";
                animationView.PauseAnimation();
                Device.BeginInvokeOnMainThread(() =>
                {
                    txtTimer.Text = "" + count;
                });
            }
        }

        private void Vibrate_Btn_Clicked(object sender, EventArgs e)
        {
            if (vibrationOnBool == true)
            {
                Vibration.Cancel();
                vibrateButton.TextColor = Color.LightGray;
                vibrateButton.Text = "Off   ";
                vibrationOnBool = false;


                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable <WeekTraining> ();

                    conn.Execute("UPDATE WeekTraining SET VibrationOn= false WHERE MyWorkout=?", mWork);
                }
            }

            else if (vibrationOnBool == false)
            {
                vibrateButton.TextColor = Color.Green;
                vibrateButton.Text = "On   ";
                vibrationOnBool = true;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<WeekTraining>();

                    conn.Execute("UPDATE WeekTraining SET VibrationOn= true WHERE MyWorkout=?", mWork);
                }

            }
        }

        private void Web_Instruction_Navigated(object sender, WebNavigatedEventArgs e)
        {
            LoadingLabel.IsVisible = false;
        }
   
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
            return true;
        }
    }
}