using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaurusBetaX.Model;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;

namespace TaurusBetaX
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popup_Exercise_ListView : PopupPage
    {
        SetWorkout selectedEx;
        string newWorkout;
        bool is_paid;
        string myWork;
        string myWorkType;
        int myID;
        string myExercise;
        int myCount;
        string mTime;
        bool mSchedule;
        int mNotificationID;

        bool mMonday, mTuesday, mWednesday, mThursday, mFriday, mSaturday, mSunday;

        public Popup_Exercise_ListView(SetWorkout selectedExercise, bool paid, int mID, string mWork, string mExercise, string mWorkType, int mCount, bool isNew)
        {
            InitializeComponent();
            this.selectedEx = selectedExercise;

            mWork = selectedExercise.MyWorkout;
            myExercise = selectedExercise.Exercise;
            myCount = selectedExercise.Reps;
            myID = selectedExercise.Id;
            myWorkType = selectedExercise.WorkoutType;
            myWork = mWork;
        }


        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<SetWorkout>();
                int rows = conn.Delete(selectedEx);
               
               //Navigation.PushAsync(new My_ExerciseList_Page(0, null, null, 0));
                App.Current.MainPage = new My_ExerciseList_Page(0, myWork, null, myWorkType, 0, mTime, mSchedule, mNotificationID);
                PopupNavigation.Instance.PopAsync();
            }

        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<SetWorkout>();

                var setworkouts = conn.Table<SetWorkout>().ToList();

                var monday_status = (from mn in setworkouts
                                     where mn.MyWorkout == myWork
                                     select mn.Monday).Take(1).ToList();

                mMonday = monday_status[0];

                //-------------------------------------------------------------

                var tuesday_status = (from ts in setworkouts
                                      where ts.MyWorkout == myWork
                                      select ts.Tuesday).Take(1).ToList();

                mTuesday = tuesday_status[0];

                //-------------------------------------------------------------

                var wednesday_status = (from wd in setworkouts
                                        where wd.MyWorkout == myWork
                                        select wd.Wednesday).Take(1).ToList();

                mWednesday = wednesday_status[0];

                //-------------------------------------------------------------

                var thursday_status = (from th in setworkouts
                                       where th.MyWorkout == myWork
                                       select th.Thursday).Take(1).ToList();

                mThursday = thursday_status[0];

                //-------------------------------------------------------------

                var friday_status = (from fr in setworkouts
                                     where fr.MyWorkout == myWork
                                     select fr.Friday).Take(1).ToList();

                mFriday = friday_status[0];

                //-------------------------------------------------------------

                var saturday_status = (from st in setworkouts
                                       where st.MyWorkout == myWork
                                       select st.Tuesday).Take(1).ToList();

                mSaturday = saturday_status[0];

                //-------------------------------------------------------------

                var sunday_status = (from su in setworkouts
                                     where su.MyWorkout == myWork
                                     select su.Sunday).Take(1).ToList();

                mSunday = sunday_status[0];

                //-------------------------------------------------------------

                var time_status = (from tm in setworkouts
                                   where tm.MyWorkout == myWork
                                   select tm.TimeIs).Take(1).ToList();

                mTime = time_status[0];

                //--------------------------------------------------------------

                var schedule_status = (from sc in setworkouts
                                   where sc.MyWorkout == myWork
                                   select sc.IsScheduled).Take(1).ToList();

                mSchedule = schedule_status[0];

                //--------------------------------------------------------------

                var notificationID_status = (from nt in setworkouts
                                       where nt.MyWorkout == myWork
                                       select nt.Notification_ID).Take(1).ToList();

                mNotificationID = notificationID_status[0];


            }

            PopupNavigation.Instance.PopAsync();
            PopupNavigation.Instance.PushAsync(new Popup_Repetitions(is_paid, myID, myWork, myExercise, myWorkType, myCount, false, mMonday, mTuesday, mWednesday, mThursday, mFriday, mSaturday, mSunday, mTime, mSchedule, mNotificationID));
            
        }
    }
}