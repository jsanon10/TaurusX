using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using TaurusBetaX.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Week_WorkoutList_Page : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        bool is_paid;
        int repInt;
        string w_choice = "none";
        int mID;
        string mWork;
        string mWorkType;
        string mExercise;
        int mCount;
        bool is_exerciseDone;
        bool is_workoutDone;
        int exDone_count;
        int wkDone_count;
        List<WeekTraining> exList = new List<WeekTraining>();

        

        public Week_WorkoutList_Page(bool paid)
        {
            InitializeComponent();

            is_paid = paid;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<WeekTraining>();

                var setworkouts = conn.Table<WeekTraining>().ToList();

                var workouts = (from w in setworkouts
                                orderby w.Id
                                select w.MyWorkout).Distinct().ToList();

                Dictionary<string, int> workoutList = new Dictionary<string, int>();
                foreach (var workout in workouts)
                {
                    var count = (from k in setworkouts
                                 where k.MyWorkout == workout
                                 select k).ToList();

                    

                    var count2 = (from m in setworkouts
                                   where m.MyWorkout == workout
                                   select m.WkDone_count).ToList();

                    int woCount = count2[0];


                    workoutList.Add(workout, woCount);
                }

                workout_Listview.ItemsSource = workoutList;

               
            }

        }


        private void Workout_Listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {



            var sworkout = e.Item;
            KeyValuePair<string, int> kvp = (KeyValuePair<string, int>)sworkout;
            mWork = kvp.Key;
            var selectedWorkout = workout_Listview.SelectedItem as WeekTraining;

            //if (is_paid == false && mWork != "Week 1")
            //{
            //    PopupNavigation.Instance.PushAsync(new Popup_View());
            //}

            //else
            //{
            //PopupNavigation.Instance.PushAsync(new Popup_Week_Workout(selectedWorkout, is_paid, mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, false));
            //}

            if (is_paid == true)
            { 
                App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);
            
            }
            else if (is_paid == false && mWork != "Week 1")
            {

                PopupNavigation.Instance.PushAsync(new Popup_View());

            }
            else if (is_paid == false && mWork == "Week 1")
            {

                App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);

            }



        }


        //NEW++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //private void Workout_Listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{


        //    var selectedExercise = workout_Listview.SelectedItem as WeekTraining;

        //    if (selectedExercise != null /*&& hour_difference > 1*/)
        //    {
        //        mWorkType = selectedExercise.WorkoutType;
        //        mExercise = selectedExercise.Exercise;
        //        mCount = selectedExercise.Reps;
        //        mID = selectedExercise.Id;


        //        App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);

        //    }

        //}



        private void Navigate_back_button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new IntroPage(is_paid);
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new IntroPage(is_paid);
            return true;
        }
    }

}
