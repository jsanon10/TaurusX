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
//using TaurusBetaX.Views;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popup_Week_Workout : PopupPage
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
        SetWorkout selectedWorkout;

        public Popup_Week_Workout (WeekTraining selectedExercise, bool paid, int newID, string newWorkout, string newExercise, string newWorkType, int newCount, bool eX_done, bool wK_done, bool isNew)
        {
            InitializeComponent();

            mWork = newWorkout;
            mWorkType = newWorkType;
        }

        

        private void Start_workout_button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();

            App.Current.MainPage = new Week_Go_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, exDone_count, wkDone_count);

        }


        private void Schedule_button_Clicked(object sender, EventArgs e)
        {


        }

    }
}