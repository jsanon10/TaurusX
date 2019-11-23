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



        List<WeekTraining> exList = new List<WeekTraining>();
        

        

        public Week_Go_ExerciseList_Page(int newID, string newWorkout, string newExercise, string newWorkType, int newCount, bool eX_done, bool wK_done, int ex_count, int wk_count)
        {
            InitializeComponent();


            
            goWorkoutTitle.Text = newWorkout;
            mWork = newWorkout;
            is_exerciseDone = eX_done;
            is_workoutDone = wK_done;
            exDone_count = ex_count;
            wkDone_count = wk_count;


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
                    yesterday_string = exYesterday.ToString();
                    yesterday_datetime = DateTime.Parse(yesterday_string);
                }


                today_string = today_datetime.ToString();
                yesterday_datetime.ToString();

                TimeSpan date_diff = today_datetime.Subtract(yesterday_datetime); // the difference increases at every onAppear

                int day_diff = date_diff.Days;
                int hour_diff = date_diff.Hours;
                int min_diff = date_diff.Minutes;

                day_difference = day_diff;
                days_to_hours = day_difference * 24;
                hour_difference = hour_diff + days_to_hours;
                minute_difference = min_diff;


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


                App.Current.MainPage = new Exercise_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_waiting, hours_countdown, minutes_countdown);
            }

            //else
            //{
            //    //App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);

            //   // PopupNavigation.Instance.PushAsync(new Popup_Wait_Hours(hours_countdown, minutes_countdown, mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count));
            //}

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

                conn.Execute("UPDATE WeekTraining SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", mWork);

                conn.Execute("UPDATE WeekTraining SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                conn.Execute("UPDATE WeekTraining SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                conn.Execute("UPDATE WeekTraining SET ExDone = '" + false + "' WHERE MyWorkout=?", mWork);

                conn.Execute("UPDATE WeekTraining SET WkDone = '" + false + "' WHERE MyWorkout=?", mWork);

                conn.Execute("UPDATE WeekTraining SET Active= false WHERE MyWorkout=?", mWork);


                App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);

            }

        }

    }
}