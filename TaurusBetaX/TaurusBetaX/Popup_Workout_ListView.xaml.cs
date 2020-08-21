using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using System.Collections.ObjectModel;
using SQLite;
using TaurusBetaX.Model;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popup_Workout_ListView : PopupPage
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

        string mTime;
        bool mScheduled;
        int mNotificationID;

        SetWorkout selectedWorkout;

        bool mMonday, mTuesday, mWednesday, mThursday, mFriday, mSaturday, mSunday;

        public Popup_Workout_ListView(SetWorkout selectedExercise, bool paid, int newID, string newWorkout, string newExercise, string newWorkType, int newCount, bool eX_done, bool wK_done, bool isNew, bool xMonday, bool xTuesday, bool xWednesday, bool xThursday, bool xFriday, bool xSaturday, bool xSunday, string xTime, bool xScheduled, int xNotificationID, bool isActive)
        {
            InitializeComponent();

            is_paid = paid;

            mWork = newWorkout;
            mWorkType = newWorkType;

            mMonday = xMonday;
            mTuesday = xTuesday;
            mWednesday = xWednesday;
            mThursday = xThursday;
            mFriday = xFriday;
            mSaturday = xSaturday;
            mSunday = xSunday;

            mTime = xTime;
            mScheduled = xScheduled;
            mNotificationID = xNotificationID;

            if (isActive == false)
            {
                start_workout_button.IsEnabled = false;
                start_workout_button.BackgroundColor = Color.LightGray;
            }

            else if (isActive == true)
            {
                start_workout_button.IsEnabled = true;

            }
            

        }

        

        private void Start_workout_button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();

            App.Current.MainPage = new My_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_paid);

        }

        private void View_update_button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();

            App.Current.MainPage = new My_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, mTime, mScheduled, mNotificationID, is_paid) ;

        }

        private void Schedule_button_Clicked(object sender, EventArgs e)
        {


            PopupNavigation.Instance.PopAsync();

            App.Current.MainPage = new My_Workout_Schedule(mWork, mMonday, mTuesday, mWednesday, mThursday, mFriday, mSaturday, mSunday, mTime, mScheduled, mNotificationID, is_paid);

        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<SetWorkout>();
               
                conn.Execute("DELETE FROM SetWorkout WHERE MyWorkout=?", mWork);

                PopupNavigation.Instance.PopAsync();

                App.Current.MainPage = new My_WorkoutList_Page(is_paid);
                
            }

        }
    }
}