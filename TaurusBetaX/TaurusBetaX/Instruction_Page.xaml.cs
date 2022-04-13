using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Instruction_Page : ContentPage
    {
        bool is_paid;

        string mWork, mExercise, mWorkType;
        int mID;
        int mCount;

        string mTime;
        bool mSchedule;
        int mNotificationID;

        public Instruction_Page(int mID, string newWorkout, string exType, string exerciseW, string xTime, bool xScheduled, int xNotificationID, bool paid)
        {
            InitializeComponent();

            is_paid = paid;
       
            mExercise = exerciseW;
            mWorkType = exType;
            mWork = newWorkout;

            mTime = xTime;
            mSchedule = xScheduled;
            mNotificationID = xNotificationID;


            switch (exType)
            {
                case "TKegel":
                    //directions_img1.Source = "Traditional_Kegel_1.PNG";
                    //directions_img2.Source = "Traditional_Kegel_2.PNG";
                    webInstruction.Source = "https://www.toruflex.com/traditional-kegel";

                    break;

                case "RKegel":
                    //directions_img1.Source = "Reverse_Kegel_1.PNG";
                    //directions_img2.Source = "Reverse_Kegel_2.PNG";
                    webInstruction.Source = "https://www.toruflex.com/reverse-kegel";
                    break;

                case "HSquat":
                    //directions_img1.Source = "WWWcatchingfire.jpg";
                    //directions_img2.Source = "WWW30minutewalk.jpg";
                    webInstruction.Source = "https://www.toruflex.com/traditional-kegel";
                    break;

                case "FSquat":
                    //directions_img1.Source = "WWWepicabsintro.jpg";
                    webInstruction.Source = "https://www.toruflex.com/traditional-kegel";
                    break;

                case "Hold_Squat":
                    //directions_img1.Source = "WWWepicarmintro.jpg";
                    webInstruction.Source = "https://www.toruflex.com/traditional-kegel";
                    break;

                case "CKegel":
                    //directions_img1.Source = "WWWepicarmintro.jpg";
                    webInstruction.Source = "https://www.toruflex.com/traditional-kegel";
                    break;

            }

        }

        private void Web_Instruction_Navigated(object sender, WebNavigatedEventArgs e)
        {
            LoadingLabel.IsVisible = false;
        }

        private void go_navigate_back_button_Clicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new My_WorkoutList_Page(is_paid);

            //PopupNavigation.Instance.PopAsync();

    
            App.Current.MainPage = new My_ExerciseList_Page(mID, mWork, mExercise, mWorkType, mCount, mTime, mSchedule, mNotificationID, is_paid);

        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new My_WorkoutList_Page(is_paid);
            return true;
        }
    }
}