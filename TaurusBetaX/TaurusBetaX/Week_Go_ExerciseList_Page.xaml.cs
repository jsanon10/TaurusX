using System;
using Rg.Plugins.Popup.Services;
using SQLite;
using SQLitePCL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaurusBetaX.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.LocalNotifications;
//using Microsoft.Data.Sqlite;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Week_Go_ExerciseList_Page : ContentPage
    {
        bool is_paid;
        int mID;
        string mWork;
        string mWorkType;
        string mExercise;
        string reset_checkmark = "small_round_nocheck.jpg";
        int mCount;
        bool is_exerciseDone;
        bool is_workoutDone;
        bool is_full;
        int exDone_count;
        int wkDone_count;
        int w1_days;
        int row_count;
        string stringDayCount;
        DateTime today_datetime = DateTime.Now;
        string today_string;
        DateTime yesterday_datetime;
        string yesterday_string;
        DateTime next_workout_date;
        int hours_countdown;
        int minutes_countdown;
        int days_to_hours;
        int day_difference;
        int hour_difference;
        int minute_difference;
        int next_hour;
        bool is_waiting;
        int _READY_ID = 9;
        DateTime todayIs = DateTime.Now.Date;

        string week1 = "Week 1";
        string week2 = "Week 2";
        string week3 = "Week 3";
        string week4 = "Week 4";



        List<WeekTraining> exList = new List<WeekTraining>();
        

        

        public Week_Go_ExerciseList_Page(int newID, string newWorkout, string newExercise, string newWorkType, int newCount, bool eX_done, bool wK_done, int ex_count, int wk_count, bool paid)
        {
            InitializeComponent();

            is_paid = paid;
            
            goWorkoutTitle.Text = newWorkout;
            mWork = newWorkout;
            is_exerciseDone = eX_done;
            is_workoutDone = wK_done;
            exDone_count = ex_count;
            wkDone_count = wk_count;


            ViewCell cell = new ViewCell();

            cell.Tapped += (sender, args) => {
                cell.View.BackgroundColor = Color.Red;
                //OnListViewTextCellTapped(cell);            //Run your actual `Tapped` event code
                //cell.View.BackgroundColor = Color.Default; //Turn it back to the default color after your event code is done
            };


            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                //Pulling data from SQLITE database and add them to a List
                conn.CreateTable<WeekTraining>();

                var setworkouts = conn.Table<WeekTraining>().ToList();

               

                //var current_Exercise_List = (from w in setworkouts
                //                             where w.MyWorkout.Equals(mWork)
                //                             select w).ToList();

                //exList = current_Exercise_List;
                //goExercise_Listview.ItemsSource = current_Exercise_List;

                ///////////////////////////////////////

                //Last time you exercised
                var exerciseYesterday = (from w in setworkouts
                                         where w.MyWorkout.Equals(mWork)
                                         select w.Yesterday).Take(1).ToList();

                foreach (var exYesterday in exerciseYesterday)
                {
                    //Convert the result of the last time you worked out into a String
                    yesterday_string = exYesterday.ToString();

                    //Convert the string into a DateTime
                    yesterday_datetime = DateTime.Parse(yesterday_string);
                }


                //Assign the Today(Now) Datetime to the "today_string" string
                today_string = today_datetime.ToString();

                //Convert the 'yesterday_datetime' into a string
                yesterday_datetime.ToString();

                //Calculate the difference between "Now" and the "Last Time" you exercised
                TimeSpan date_diff = today_datetime.Subtract(yesterday_datetime); // the difference increases at every onAppear

                //Get the Day difference from "date_diff" and assign it to "day_diff" interger
                int day_diff = date_diff.Days;

                //Get the Hours difference from "date_diff" and assign it to "hour_diff" interger
                int hour_diff = date_diff.Hours;

                //Get the Minutes difference from "date_diff" and assign it to "min_diff" interger
                int min_diff = date_diff.Minutes;

                day_difference = day_diff;

                //Convert the day difference into Hour
                days_to_hours = day_difference * 24;

                //Add the converted  Day to Hour  to the current hour difference
                hour_difference = hour_diff + days_to_hours;

                minute_difference = min_diff;

                //
                hours_countdown = 1 - hour_diff;
                if (hours_countdown < 0)
                {
                    hours_countdown = 1;
                }


                minutes_countdown = 60 - min_diff;
                next_workout_date = today_datetime.AddHours(hours_countdown);
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






                //Verifying amouth of exercise completed in the Weetraining table for a day of workout
                var exerciseLeft = (from z in setworkouts
                                    where z.MyWorkout.Equals(mWork)
                                    && z.ExDone.Equals(false)
                                    select z).ToList();

                int exRow_count = exerciseLeft.Count();


                //Verifying workout completion in the Weaktraining table
                var workoutFinished = (from y in setworkouts
                                       where y.MyWorkout.Equals(mWork)
                                       && y.WkDone.Equals(false)
                                       select y).ToList();

                int wkOut_count = workoutFinished.Count();






                var workout_Days_Left = (from x in setworkouts
                                         where x.MyWorkout.Equals(mWork)
                                         select x.WkDone_count).Take(1).ToList();

                foreach (var woDaysLeft in workout_Days_Left)
                {
                    stringDayCount = woDaysLeft.ToString();
                    wkDone_count = woDaysLeft;
                }


                //After last exercise, run this IF statement
                if (exRow_count == 0 && wkOut_count == 0)
                {
                    wkDone_count++;

                    stringDayCount = wkDone_count.ToString();

                    daysCompleted.Text = stringDayCount;

                    is_workoutDone = true;

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + wkDone_count + "' WHERE MyWorkout=?", mWork);
                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", mWork);
                    conn.Execute("UPDATE WeekTraining SET Wait= true WHERE MyWorkout=?", mWork);
                    conn.Execute("UPDATE WeekTraining SET Yesterday = '" + today_string + "' WHERE MyWorkout=?", mWork);

                    exRow_count = 1; // to skip the next 'if' statement

                    stringDayCount = wkDone_count.ToString();
                    is_waiting = true;
                }

                Device.BeginInvokeOnMainThread(() =>
                {
                    daysCompleted.Text = stringDayCount;
                });

                if (is_waiting == false && wkOut_count == 0)
                {

                    if (wkDone_count < 4)
                    {
                        conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", mWork);
                        conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork); 
                        conn.Execute("UPDATE WeekTraining SET WkDone= false WHERE MyWorkout=?", mWork);

                       
                    }

                    
                    else if (wkDone_count >= 4)
                    {
                        conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", mWork);
                        conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                        

                    }
                    
                    is_workoutDone = false;
                    is_waiting = false;


                    //conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", mWork);


                    //App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);

                }
            }

        }




        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                //Pulling data from SQLITE database and add them to a List
                conn.CreateTable<WeekTraining>();

                var setworkouts = conn.Table<WeekTraining>().ToList();

                var current_Exercise_List = (from w in setworkouts
                                             where w.MyWorkout.Equals(mWork)
                                             select w).ToList();

                exList = current_Exercise_List;
                goExercise_Listview.ItemsSource = current_Exercise_List;

            }


        }


        private void Exercise_Listview_Selected(object sender, ItemTappedEventArgs e)
        {
            var selectedExercise = goExercise_Listview.SelectedItem as WeekTraining;

            if (selectedExercise != null /*&& hour_difference > 1*/)
            {
                mWorkType = selectedExercise.WorkoutType;
                mExercise = selectedExercise.Exercise;
                mCount = selectedExercise.Reps;
                mID = selectedExercise.Id;


                App.Current.MainPage = new Exercise_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_waiting, hours_countdown, minutes_countdown, is_paid);
            }

        }

        private void Navigate_back_button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Week_WorkoutList_Page(is_paid);
        }

        private void Go_reset_button_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<WeekTraining>();

                if(mWork == "Week 4")
                {
                    conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", mWork);

                }

                if (mWork == "Week 3")
                {
                    conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", mWork);


                    conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", week4);

                }

                if (mWork == "Week 2")
                {
                    conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", mWork);


                    conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", week3);

                    conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", week3);

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", week3);

                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", week3);

                    conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", week3);

                    conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", week3);


                    conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", week4);

                }

                if (mWork == "Week 1")
                {
                    conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", mWork);

                    conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", mWork);


                    conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", week2);

                    conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", week2);

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", week2);

                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", week2);

                    conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", week2);

                    conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", week2);


                    conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", week3);

                    conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", week3);

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", week3);

                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", week3);

                    conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", week3);

                    conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", week3);


                    conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", week4);

                    conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", week4);

                }

                    App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);

            }

        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new Week_WorkoutList_Page(is_paid);
            return true;
        }

    }
}