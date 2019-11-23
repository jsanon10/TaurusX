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
    public partial class My_ExerciseList_Page : ContentPage
    {
        bool is_paid;
        int mID;
        string mWork;
        string mWorkType;
        string mExercise;
        string mTime;
        bool mSchedule;
        int mCount;
        int mNotificationID;
        //string current_workout;

        bool mMonday, mTuesday, mWednesday, mThursday, mFriday, mSaturday, mSunday;

        public My_ExerciseList_Page(int newID, string newWorkout, string newExercise, string newWorkType, int newCount, string xTime, bool xScheduled, int xNotificationID)
        {
            InitializeComponent();

            if (newWorkout == null)
            {
                mWork = null;
            }
            else
            {
                mWork = newWorkout;
                mWorkType = newWorkType;
                mExercise = newExercise;
                mCount = newCount;
                mID = newID;
                mTime = xTime;
                mSchedule = xScheduled;
                mNotificationID = xNotificationID;
                workoutTitle.Text = newWorkout;
            }
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

                exercise_Listview.ItemsSource = exerciseList; 
            }
        }

        

        private void Exercise_Listview_Selected(object sender, ItemTappedEventArgs e)
        {
            var selectedExercise = exercise_Listview.SelectedItem as SetWorkout;

            if (selectedExercise != null)
            {
                //PopupNavigation.Instance.PushAsync(new Popup_Exercise_ListView(selectedExercise, is_paid, mID, mWork, mExercise, mCount, false));
                PopupNavigation.Instance.PushAsync(new Popup_Exercise_ListView(selectedExercise, is_paid, mID, mWork, mExercise, mWorkType, mCount, false));
            }

        }

        private void Add_exercise_button_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<SetWorkout>();

                var setworkouts = conn.Table<SetWorkout>().ToList();

                var monday_status = (from mn in setworkouts
                                     where mn.MyWorkout == mWork
                                     select mn.Monday).Take(1).ToList();

                mMonday = monday_status[0];

                //-------------------------------------------------------------

                var tuesday_status = (from ts in setworkouts
                                      where ts.MyWorkout == mWork
                                      select ts.Tuesday).Take(1).ToList();

                mTuesday = tuesday_status[0];

                //-------------------------------------------------------------

                var wednesday_status = (from wd in setworkouts
                                        where wd.MyWorkout == mWork
                                        select wd.Wednesday).Take(1).ToList();

                mWednesday = wednesday_status[0];

                //-------------------------------------------------------------

                var thursday_status = (from th in setworkouts
                                       where th.MyWorkout == mWork
                                       select th.Thursday).Take(1).ToList();

                mThursday = thursday_status[0];

                //-------------------------------------------------------------

                var friday_status = (from fr in setworkouts
                                     where fr.MyWorkout == mWork
                                     select fr.Friday).Take(1).ToList();

                mFriday = friday_status[0];

                //-------------------------------------------------------------

                var saturday_status = (from st in setworkouts
                                       where st.MyWorkout == mWork
                                       select st.Tuesday).Take(1).ToList();

                mSaturday = saturday_status[0];

                //-------------------------------------------------------------

                var sunday_status = (from su in setworkouts
                                     where su.MyWorkout == mWork
                                     select su.Sunday).Take(1).ToList();

                mSunday = sunday_status[0];

            }

            // App.Current.MainPage = new NavigationPage(new Popup_Exercise_ListView(selectedExercise, is_paid, mID, mWork, mExercise, mCount, false));
            PopupNavigation.Instance.PushAsync(new Popup_Repetitions(is_paid, mID, mWork, mExercise, mWorkType, mCount, true, mMonday, mTuesday, mWednesday, mThursday, mFriday, mSaturday, mSunday, mTime, mSchedule, mNotificationID));
        }

        private void Navigate_back_button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new My_WorkoutList_Page();
        }
    }
}