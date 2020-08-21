using Plugin.LocalNotifications;
using SQLite;
using System;
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
    public partial class My_Workout_Schedule : ContentPage
    {
        bool is_paid;

        int _MONDAY_ID = 1;
        int _TUESDAY_ID = 2;
        int _WEDNESDAY_ID = 3;
        int _THURSDAY_ID = 4;
        int _FRIDAY_ID = 5;
        int _SATURDAY_ID = 6;
        int _SUNDAY_ID = 7;



        int w_ID;

        bool updated_monday;
        bool updated_tuesday;
        bool updated_wednesday;
        bool updated_thursday;
        bool updated_friday;
        bool updated_saturday;
        bool updated_sunday;

        string myTime;
        string mWork;
        int checkBoxCount = 0;

        DateTime notification_time;
        DateTime todayIs = DateTime.Now.Date;
        TimeSpan selectedTime;
        DateTime today_full;




        public My_Workout_Schedule(string newWorkout, bool xMonday, bool xTuesday, bool xWednesday, bool xThursday, bool xFriday, bool xSaturday, bool xSunday, string xTime, bool xScheduled, int xNotificationID, bool paid)
        {
            InitializeComponent();

            is_paid = paid;

            sunday_box.IsChecked = xSunday;
            monday_box.IsChecked = xMonday;
            tuesday_box.IsChecked = xTuesday;
            wednesday_box.IsChecked = xWednesday;
            thursday_box.IsChecked = xThursday;
            friday_box.IsChecked = xFriday;
            saturday_box.IsChecked = xSaturday;

            TimeSpan ts = TimeSpan.Parse(xTime);

            scheduled_time.Time = ts;




            mWork = newWorkout;
            workoutTitle.Text = newWorkout;
            myTime = xTime;

            _MONDAY_ID = 1 + xNotificationID;
            _TUESDAY_ID = 2 + xNotificationID;
            _WEDNESDAY_ID = 3 + xNotificationID;
            _THURSDAY_ID = 4 + xNotificationID;
            _FRIDAY_ID = 5 + xNotificationID;
            _SATURDAY_ID = 6 + xNotificationID;
            _SUNDAY_ID = 7 + xNotificationID;


        }

        private void Go_navigate_back_button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new My_WorkoutList_Page(is_paid);

        }

        private void Save_schedule_button_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<SetWorkout>();

                var setworkouts = conn.Table<SetWorkout>().ToList();

                //conn.Execute("UPDATE SetWorkout SET Monday = '" + updated_monday + "' WHERE MyWorkout=?", mWork);

                //conn.Execute("UPDATE SetWorkout SET Tuesday = '" + updated_tuesday + "' WHERE MyWorkout=?", mWork);

                //conn.Execute("UPDATE SetWorkout SET Wednesday = '" + updated_wednesday + "' WHERE MyWorkout=?", mWork);

                //conn.Execute("UPDATE SetWorkout SET Thursday = '" + updated_thursday + "' WHERE MyWorkout=?", mWork);

                //conn.Execute("UPDATE SetWorkout SET Friday = '" + updated_friday + "' WHERE MyWorkout=?", mWork);

                //conn.Execute("UPDATE SetWorkout SET Saturday = '" + updated_saturday + "' WHERE MyWorkout=?", mWork);

                //conn.Execute("UPDATE SetWorkout SET Sunday = '" + updated_sunday + "' WHERE MyWorkout=?", mWork);

                //conn.Execute("UPDATE SetWorkout SET TimeIs = '" + myTime + "' WHERE MyWorkout=?", mWork);



                if (updated_monday == true)
                {
                    if (todayIs.DayOfWeek == DayOfWeek.Monday)
                    {
                        CrossLocalNotifications.Current.Show("Toruflex", "Your scheduled workout '" + mWork + "' is ready", _MONDAY_ID, today_full);
                    }
                }
                else if (updated_monday == false)
                {
                    CrossLocalNotifications.Current.Cancel(_MONDAY_ID);
                }

                if (updated_tuesday == true)
                {
                    if (todayIs.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        CrossLocalNotifications.Current.Show("Toruflex", "Your scheduled workout '" + mWork + "' is ready", _TUESDAY_ID, today_full);
                    }
                }
                else if (updated_tuesday == false)
                {
                    CrossLocalNotifications.Current.Cancel(_TUESDAY_ID);
                }

                if (updated_wednesday == true)
                {
                    if (todayIs.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        CrossLocalNotifications.Current.Show("Toruflex", "Your scheduled workout '" + mWork + "' is ready", _WEDNESDAY_ID, today_full);
                    }
                }
                else if (updated_wednesday == false)
                {
                    CrossLocalNotifications.Current.Cancel(_WEDNESDAY_ID);
                }

                if (updated_thursday == true)
                {
                    if (todayIs.DayOfWeek == DayOfWeek.Thursday)
                    {
                        CrossLocalNotifications.Current.Show("Toruflex", "Your scheduled workout '" + mWork + "' is ready", _THURSDAY_ID, today_full);
                    }
                }
                else if (updated_thursday == false)
                {
                    CrossLocalNotifications.Current.Cancel(_THURSDAY_ID);
                }

                if (updated_friday == true)
                {
                    if (todayIs.DayOfWeek == DayOfWeek.Friday)
                    {
                        CrossLocalNotifications.Current.Show("Toruflex", "Your scheduled workout '" + mWork + "' is ready", _FRIDAY_ID, today_full);
                    }
                }
                else if (updated_friday == false)
                {
                    CrossLocalNotifications.Current.Cancel(_FRIDAY_ID);
                }

                if (updated_saturday == true)
                {
                    if (todayIs.DayOfWeek == DayOfWeek.Saturday)
                    {
                        CrossLocalNotifications.Current.Show("Toruflex", "Your scheduled workout '" + mWork + "' is ready", _SATURDAY_ID, today_full);
                    }
                }
                else if (updated_saturday == false)
                {
                    CrossLocalNotifications.Current.Cancel(_SATURDAY_ID);
                }

                if (updated_sunday == true)
                {
                    if (todayIs.DayOfWeek == DayOfWeek.Sunday)
                    {
                        CrossLocalNotifications.Current.Show("Toruflex", "Your scheduled workout '" + mWork + "' is ready", _SUNDAY_ID, today_full);
                    }
                }
                else if (updated_sunday == false)
                {
                    CrossLocalNotifications.Current.Cancel(_SUNDAY_ID);
                }

                
                conn.Execute("UPDATE SetWorkout SET TimeIs= '" + myTime + "'  WHERE MyWorkout=?", mWork);

                if (checkBoxCount <= 0)
                {
                    conn.Execute("UPDATE SetWorkout SET IsScheduled= false WHERE MyWorkout=?", mWork);

                }
                else if (checkBoxCount > 0)
                {
                    conn.Execute("UPDATE SetWorkout SET IsScheduled= true WHERE MyWorkout=?", mWork);

                }

                App.Current.MainPage = new My_WorkoutList_Page(is_paid);
            }
            

        }

        private void Sunday_box_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

            if (sunday_box.IsChecked == true)
            {
                updated_sunday = true;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Sunday= true WHERE MyWorkout=?", mWork);

                }

                checkBoxCount++;

            }
            else if (sunday_box.IsChecked == false)
            {
                updated_sunday = false;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Sunday= false WHERE MyWorkout=?", mWork);

                }

                if (checkBoxCount > 0)
                {
                    checkBoxCount--;
                }
            }
        }

        private void Monday_box_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (monday_box.IsChecked == true)
            {
                updated_monday = true;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Monday= true WHERE MyWorkout=?", mWork);

                }

                    checkBoxCount++;


            }
            else if (monday_box.IsChecked == false)
            {
                updated_monday = false;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Monday= false WHERE MyWorkout=?", mWork);

                }

                if (checkBoxCount > 0)
                {
                    checkBoxCount--;
                }

            }

        }

        private void Tuesday_box_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (tuesday_box.IsChecked == true)
            {
                updated_tuesday = true;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Tuesday= true WHERE MyWorkout=?", mWork);

                }

                checkBoxCount++;

            }
            else if (tuesday_box.IsChecked == false)
            {
                updated_tuesday = false;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Tuesday= false WHERE MyWorkout=?", mWork);

                }

                if (checkBoxCount > 0)
                {
                    checkBoxCount--;
                }

            }

        }

        private void Wednesday_box_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (wednesday_box.IsChecked == true)
            {
                updated_wednesday = true;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Wednesday= true WHERE MyWorkout=?", mWork);

                }
                checkBoxCount++;

            }
            else if (wednesday_box.IsChecked == false)
            {
                updated_wednesday = false;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Wednesday= false WHERE MyWorkout=?", mWork);

                }

                if (checkBoxCount > 0)
                {
                    checkBoxCount--;
                }

            }

        }

        private void Thursday_box_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (thursday_box.IsChecked == true)
            {
                updated_thursday = true;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Thursday= true WHERE MyWorkout=?", mWork);

                }

                checkBoxCount++;


            }
            else if (thursday_box.IsChecked == false)
            {
                updated_thursday = false;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Thursday= false WHERE MyWorkout=?", mWork);

                }

                if (checkBoxCount > 0)
                {
                    checkBoxCount--;
                }

            }

        }

        private void Friday_box_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (friday_box.IsChecked == true)
            {
                updated_friday = true;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Friday= true WHERE MyWorkout=?", mWork);

                }

                checkBoxCount++;

            }
            else if (friday_box.IsChecked == false)
            {
                updated_friday = false;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Friday= false WHERE MyWorkout=?", mWork);

                }

                if (checkBoxCount > 0)
                {
                    checkBoxCount--;
                }

            }

        }

        private void Saturday_box_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (saturday_box.IsChecked == true)
            {
                updated_saturday = true;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Saturday= true WHERE MyWorkout=?", mWork);

                }

                checkBoxCount++;


            }
            else if (saturday_box.IsChecked == false)
            {
                updated_sunday = false;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    var setworkouts = conn.Table<SetWorkout>().ToList();

                    conn.Execute("UPDATE SetWorkout SET Saturday= false WHERE MyWorkout=?", mWork);

                }

                if (checkBoxCount > 0)
                {
                    checkBoxCount--;
                }

            }

        }

        private void Scheduled_time_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            
            myTime = scheduled_time.Time.ToString();

            selectedTime = scheduled_time.Time;
            today_full = todayIs + selectedTime;


        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new My_WorkoutList_Page(is_paid);
            return true;
        }
    }
}