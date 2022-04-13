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
using Xamarin.Essentials;

using TaurusBetaX.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exercise_Page_Extra : CustomTabbedPage
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
        float animationSpeed;
        bool vibrationOnBool;

        int delay1;
        int delay2;


        public Exercise_Page_Extra(int newID, string newWorkout, string newExercise, string newWorkType, int newCount, bool eX_done, bool wK_done, int ex_count, int wk_count, bool paid)
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


            TextToSpeech.SpeakAsync("Go to the exercise tab", new SpeechOptions
            {
                Pitch = 0.0f
            });
            Thread.Sleep(800);
            TextToSpeech.SpeakAsync("Then Press the start button, to begin", new SpeechOptions
            {
                Pitch = 0.0f
            });



            //Verify vibrate status
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<SetWorkout>();

                var setworkouts = conn.Table<SetWorkout>().ToList();
                var verifyVibrate = (from v in setworkouts
                                     where v.MyWorkout.Equals(mWork)
                                     select v.VibrationOn).ToList();

                vibrationOnBool = verifyVibrate[0];

                if (vibrationOnBool == true)
                {
                    vibrateButton2.Text = "On   ";
                    vibrateButton2.TextColor = Color.Green;
                }

                else if (vibrationOnBool == false)
                {
                    vibrateButton2.Text = "Off   ";
                    vibrateButton2.TextColor = Color.LightGray;
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

                    case "HRKegel":
                        webInstruction.Source = "https://www.toruflex.com/reverse-kegel";
                        delay1 = 1000;
                        delay2 = 3000;
                        animationSpeed = 1.0f;
                        videoUrl = "HeelReverse.json";
                        animationView.Animation = videoUrl;
                        action1 = "expand";
                        action2 = "relax";
                        break;

                    case "RKegelRapid":
                        webInstruction.Source = "https://www.toruflex.com/reverse-kegel";
                        delay1 = 0;
                        delay2 = 0;
                        animationSpeed = 1.5f;
                        videoUrl = "newKegelRev.json";
                        animationView.Animation = videoUrl;
                        action1 = "expand";
                        action2 = "relax";
                        break;

                    case "RKegelHold":
                        webInstruction.Source = "https://www.toruflex.com/reverse-kegel";
                        delay1 = 1000;
                        delay2 = 4000;
                        animationSpeed = 1.0f;
                        videoUrl = "KegelReverseHold.json";
                        animationView.Animation = videoUrl;
                        action1 = "";
                        action2 = "";
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

                    //case "HRKegel":
                    //    webInstruction.Source = "https://www.toruflex.com/crunches";
                    //    delay1 = 1000;
                    //    delay2 = 3000;
                    //    videoUrl = "HeelReverse.json";
                    //    animationView.Animation = videoUrl;
                    //    action1 = "expand";
                    //    action2 = "relax";
                    //    break;

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
                        delay2 = 8000;
                        videoUrl = "NewHeelSquat2.json";
                        animationView.Animation = videoUrl;
                        action1 = "heelSquatBalanced.json";
                        action2 = "rise up";
                        break;

                    case "FSquat":
                        webInstruction.Source = "https://www.toruflex.com/sumo-heel-squat";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "HeelSquatXL.json";
                        animationView.Animation = videoUrl;
                        action1 = "squat";
                        action2 = "rise up";
                        break;

                    case "Hold_Squat":
                        webInstruction.Source = "https://www.toruflex.com/crunches";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "NewHeelSquat2.json";
                        animationView.Animation = videoUrl;
                        //action1 = "hold";
                        action2 = "hold";
                        break;

                    case "CKegel":
                        webInstruction.Source = "https://www.toruflex.com/bridge";
                        delay1 = 1000;
                        delay2 = 6000;
                        videoUrl = "NewHeelSquat2.json";
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
                        videoUrl = "NewHeelSquat2.json";
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
                        videoUrl = "NewHeelSquat2.json";
                        animationView.Animation = videoUrl;
                        action1 = "hold";
                        action2 = "hold";
                        break;
                }

            }

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
                    conn.CreateTable<SetWorkout>();
                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    var ex_counter = (from w in setworkouts
                                      where w.MyWorkout.Equals(mWork)
                                      select w.ExDone_count).ToList();
                    exDone_count = ex_counter[0];
                    exDone_count++;

                    conn.Execute("UPDATE SetWorkout SET Checkmark = '" + done_checkmark + "' WHERE Id = '" + mID + "' ");
                    conn.Execute("UPDATE SetWorkout SET ExDone_count = '" + exDone_count + "' WHERE Id = '" + mWork + "' ");
                    conn.Execute("UPDATE SetWorkout SET ExDone= true WHERE Id = '" + mID + "' ");
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
                App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
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
                App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
            }

            if (count <= 0 && btnReset.Text == "Exit" && page != 5 && is_paid == false)
            {
                App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
            }

            if (count <= 0 && btnReset.Text == "Exit" && page == 5)
            {
                App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
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
                vibrateButton2.TextColor = Color.LightGray;
                vibrateButton2.Text = "Off   ";
                vibrationOnBool = false;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    conn.Execute("UPDATE SetWorkout SET VibrationOn= false WHERE MyWorkout=?", mWork);
                }


            }

            else if (vibrationOnBool == false)
            {
                vibrateButton2.TextColor = Color.Green;
                vibrateButton2.Text = "On   ";
                vibrationOnBool = true;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    conn.Execute("UPDATE SetWorkout SET VibrationOn= true WHERE MyWorkout=?", mWork);
                }
            }

        }     

        private void Web_Instruction_Navigated(object sender, WebNavigatedEventArgs e)
        {

            LoadingLabel.IsVisible = false;

        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
            return true;
        }
    }
}