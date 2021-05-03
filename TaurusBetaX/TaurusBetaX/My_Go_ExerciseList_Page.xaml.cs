using System;
using Rg.Plugins.Popup.Services;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaurusBetaX.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class My_Go_ExerciseList_Page : ContentPage
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
        int exDone_count;
        int wkDone_count;
        string workout_status;

        List<SetWorkout> exList = new List<SetWorkout>();
        

        

        public My_Go_ExerciseList_Page(int newID, string newWorkout, string newExercise, string newWorkType, int newCount, bool eX_done, bool wK_done, int ex_count, int wk_count, bool paid)
        {
            InitializeComponent();

            is_paid = paid;
          
            goWorkoutTitle.Text = newWorkout;
            mWork = newWorkout;
            is_exerciseDone = eX_done;
            is_workoutDone = wK_done;
            exDone_count = ex_count;
            wkDone_count = wk_count;


        }

       

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<SetWorkout>();



                var setworkouts = conn.Table<SetWorkout>().ToList();

                var exerciseList = (from w in setworkouts
                                    where w.MyWorkout.Equals(mWork)
                                    select w).ToList();

                exList = exerciseList;
                goExercise_Listview.ItemsSource = exerciseList;

                //---------------------------------------------------------------------

                //var exerciseCount = (from ec in setworkouts
                //                     where ec.MyWorkout.Equals(mWork) && ec.ExDone.Equals(true)
                //                     select ec).ToList();

                //var exerciseTotal = (from et in setworkouts
                //                     where et.MyWorkout.Equals(mWork)
                //                     select et).ToList();

                //int count_exercise_done = exerciseCount.Count();
                //int count_exercise_total = exerciseTotal.Count();

                //if (count_exercise_done > 0 && count_exercise_done < count_exercise_total)
                //{

                //    workout_status = "In Progress";


                //}


                //if (count_exercise_done == 0)
                //{

                //}


                //if (count_exercise_done >= count_exercise_total)
                //{


                //}

                //---------------------------------------------------------------------

                conn.Execute("UPDATE SetWorkout SET Workout_Status= '" + workout_status + "' WHERE MyWorkout=?", mWork);
            }
        }


        private void Exercise_Listview_Selected(object sender, ItemTappedEventArgs e)
        {
            var selectedExercise = goExercise_Listview.SelectedItem as SetWorkout;

            if (selectedExercise != null)
            {
                mWorkType = selectedExercise.WorkoutType;
                mExercise = selectedExercise.Exercise;
                mCount = selectedExercise.Reps;
                mID = selectedExercise.Id;
      
               
               App.Current.MainPage = new Exercise_Page_Extra(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
                
            }

        }

        private void Navigate_back_button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new My_WorkoutList_Page(is_paid);
        }

        private void Go_reset_button_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<SetWorkout>();


               // conn.Execute("UPDATE SetWorkout SET ExDone = '" + false + "' WHERE MyWorkout = '" + mWork + "' ");
                conn.Execute("UPDATE SetWorkout SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", mWork);

                conn.Execute("UPDATE SetWorkout SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                conn.Execute("UPDATE SetWorkout SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", mWork);

                conn.Execute("UPDATE SetWorkout SET ExDone= false WHERE MyWorkout=?", mWork);

                App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);



            }



        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new My_WorkoutList_Page(is_paid);
            return true;
        }
    }
}