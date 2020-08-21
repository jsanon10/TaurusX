﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using TaurusBetaX.Model;
using SQLite;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popup_Repetitions : PopupPage
    {
        int repInt;
        bool is_paid;
        bool new_entry;
        int w_ID;
        string w_Exercise;
        string w_choice_type;
        string mCount_string;
        string w_Workout;
        bool w_Sunday = false;
        bool w_Monday = false;
        bool w_Tuesday = false;
        bool w_Wednesday = false;
        bool w_Thursday = false;
        bool w_Friday = false;
        bool w_Saturday = false;
        bool w_Scheduled = false;
        int w_NotificationID = 10;
        bool w_vibrateBool;
        string w_workoutStatus = "Un-Scheduled";

        string w_Time = "12:00:00";




        public Popup_Repetitions( bool paid, int mID, string mWork, string mExercise, string mWorkType, int mCount, bool isNew, bool xMonday, bool xTuesday, bool xWednesday, bool xThursday, bool xFriday, bool xSaturday, bool xSunday, string xTime, bool xScheduled, int xNotification)
        {
            InitializeComponent();
                
                is_paid = paid;
                w_ID = mID;
                new_entry = isNew;
                repInt = mCount;
                w_Exercise = mExercise;
                mCount_string = repInt.ToString();


                SetExercisePicker.Title = w_Exercise;
                SetRepPicker.Title = mCount_string;
                SetExercisePicker.TextColor = Color.Red;
                SetRepPicker.TextColor = Color.Red;





            if (mWork != null)
            {
                my_WorkoutEntry.Text = mWork;

                w_Workout = mWork;

                my_WorkoutEntry.IsEnabled = false;

                w_Exercise = mExercise;

                w_choice_type = mWorkType;

                w_Monday = xMonday;

                w_Tuesday = xTuesday;

                w_Wednesday = xWednesday;

                w_Thursday = xThursday;

                w_Friday = xFriday;

                w_Saturday = xSaturday;

                w_Sunday = xSunday;

                w_Time = xTime;

                w_Scheduled = xScheduled;

                w_NotificationID = xNotification;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    var verifyVibrate = (from b in setworkouts
                                         where b.MyWorkout.Equals(mWork)
                                         select b.VibrationOn).ToList();

                    w_vibrateBool = verifyVibrate[0];

                }
            }

            else if (mWork == null)
            {
                w_NotificationID = w_NotificationID * w_ID;
                w_vibrateBool = false;
            }

            if (w_Scheduled == false)
            {
                w_workoutStatus = "Un-scheduled";

            }
            else if (w_Scheduled == true)
            {
                w_workoutStatus = "Scheduled";
            }



            
            workout_btn.Text = "Continue";

            SetRepPicker.Items.Add("5");
            SetRepPicker.Items.Add("10");
            SetRepPicker.Items.Add("15");
            SetRepPicker.Items.Add("20");
            SetRepPicker.Items.Add("25");
            SetRepPicker.Items.Add("30");
            SetRepPicker.Items.Add("35");
            SetRepPicker.Items.Add("40");
            SetRepPicker.Items.Add("45");
            SetRepPicker.Items.Add("50");
            SetRepPicker.Items.Add("55");
            SetRepPicker.Items.Add("60");
            SetRepPicker.Items.Add("65");
            SetRepPicker.Items.Add("70");
            SetRepPicker.Items.Add("75");
            SetRepPicker.Items.Add("80");
            SetRepPicker.Items.Add("85");
            SetRepPicker.Items.Add("90");
            SetRepPicker.Items.Add("95");
            SetRepPicker.Items.Add("100");


            SetExercisePicker.Items.Add("Bridges (Hip Raise)");
            SetExercisePicker.Items.Add("BC Crunches (Long)");
            SetExercisePicker.Items.Add("BC Crunches (Short)");
            SetExercisePicker.Items.Add("Reverse Kegel (Long)");
            SetExercisePicker.Items.Add("Reverse Kegel (Short)");
            SetExercisePicker.Items.Add("Reverse Back Kegel");
            SetExercisePicker.Items.Add("Heel Half Squats");
            SetExercisePicker.Items.Add("Sumo Heel Squats");
            SetExercisePicker.Items.Add("Hold Heel Squat");

        }

        private void SetRepPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var set_num = SetRepPicker.Items[SetRepPicker.SelectedIndex];

            repInt = Convert.ToInt32(set_num);
        }


        private void SetExercisePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            w_Exercise = SetExercisePicker.Items[SetExercisePicker.SelectedIndex];

            switch (w_Exercise)
            {
                case "Traditional Kegel":
                    w_choice_type = "TKegel";
         
                    break;

                case "Reverse Kegel":
                    w_choice_type = "RKegel";
                    break;

                case "Reverse Back Kegel":
                    w_choice_type = "CKegel";
                    break;

                case "Low Heel Hold Squat":
                    w_choice_type = "Hold_Squat";
                    break;

                case "Sumo Heel Squats":
                    w_choice_type = "FSquat";
                    break;

                case "Half Heel Squats":
                    w_choice_type = "HSquat";
                    break;

            }

        }

        private void Workout_Selection_Clicked(object sender, EventArgs e)
        {

            SetWorkout setworkout = new SetWorkout()
            {
                Id = w_ID,

                MyWorkout = my_WorkoutEntry.Text,

                Exercise = w_Exercise,

                WorkoutType = w_choice_type,

                Reps = repInt,

                ExDone = false,

                WkDone = false,

                ExDone_count = 0,

                WkDone_count = 0,

                Checkmark = "small_round_nocheck.jpg",

                Monday = w_Monday,

                Tuesday = w_Tuesday,

                Wednesday = w_Wednesday,

                Thursday = w_Thursday,

                Friday = w_Friday,

                Saturday = w_Saturday,

                Sunday = w_Sunday,

                TimeIs = w_Time,

                IsScheduled = w_Scheduled,

                Notification_ID = w_NotificationID,

                Workout_Status = w_workoutStatus,

                VibrationOn = w_vibrateBool,

                WorkoutReady = true,

            };

            w_Workout = my_WorkoutEntry.Text;

            //my_RepEntry.Text = mCount_string;
            //repInt = repInt = Convert.ToInt32(mCount_string); 


            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                if (w_Workout == "")
                {
                    w_Workout = null;

                }

                if (w_Workout != null && repInt != 0 && w_Exercise != null)
                {
                    if (new_entry == true)
                    {
                        conn.CreateTable<SetWorkout>();
                        int rows = conn.Insert(setworkout);
                        w_ID = 0;
                    }
                    else
                    {
                        conn.CreateTable<SetWorkout>();
                        int rows = conn.Update(setworkout);
                    }
                    
                    
                    //-----------------------------------------------------
                    //PopupNavigation.Instance.PopAsync(true);

                    App.Current.MainPage = new My_ExerciseList_Page(w_ID, w_Workout, w_Exercise, w_choice_type, repInt, w_Time, w_Scheduled, w_NotificationID, is_paid);
                    PopupNavigation.Instance.PopAsync();
                }

                if (repInt == 0 && w_Exercise == null && w_Workout == null)
                {
                    error_message.Text = "Missing: Workout name, Exercise and Set count ";
                }

                if (repInt == 0  && w_Exercise == null && w_Workout != null)
                {
                    error_message.Text = "Missing: Exercise and Set count ";
                }

                if (repInt != 0 && w_Exercise == null && w_Workout != null)
                {
                    error_message.Text = "Missing: Exercise ";
                }

                if (repInt == 0 && w_Exercise != null && w_Workout != null)
                {
                    error_message.Text = "Missing: Set count ";
                }

                if (repInt != 0 && w_Exercise != null && w_Workout == null)
                {
                    error_message.Text = "Missing: Workout name";
                }

                if (repInt == 0 && w_Exercise != null && w_Workout == null)
                {
                    error_message.Text = "Missing: Workout name and Set count";
                }

                if (repInt != 0 && w_Exercise == null && w_Workout == null)
                {
                    error_message.Text = "Missing: Workout name and Exercise";
                }






            }




        }

    }
}