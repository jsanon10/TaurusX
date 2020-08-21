using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;


namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popup_Wait_Hours : PopupPage
    {
        int mCount;
        int mID;
        string mExercise;
        string mWork;
        string mWorkType;
        bool is_exerciseDone;
        bool is_workoutDone;
        int exDone_count;
        int wkDone_count;
        int hours_wait;
        int minutes_wait;
        bool is_waiting;
        bool is_paid;

        public Popup_Wait_Hours(int hours, int minutes, int newID, string newWorkout, string newExercise, string newWorkType, int newCount, bool eX_done, bool wK_done, int ex_count, int wk_count, bool waiting, bool paid)
        {
            InitializeComponent();

            is_paid = paid;

            hoursleft.Text = hours + " hour";
            minutesleft.Text = minutes + " minutes";
            hours_wait = hours;
            minutes_wait = minutes;
            mCount = newCount;
            mID = newID;
            mExercise = newExercise;
            mWork = newWorkout;
            mWorkType = newWorkType;
            is_exerciseDone = eX_done;
            is_workoutDone = wK_done;
            is_waiting = waiting;
            exDone_count = ex_count;
            wkDone_count = wk_count;



        }

        private void Ok_button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();

            App.Current.MainPage = new Exercise_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count, is_waiting, hours_wait, minutes_wait, is_paid);

            
            //App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);

        }
    }
}