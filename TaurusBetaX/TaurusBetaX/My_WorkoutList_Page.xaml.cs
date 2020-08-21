using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using TaurusBetaX.Model;
using TaurusBetaX.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaurusBetaX;



namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class My_WorkoutList_Page : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        bool is_paid;
        int repInt;
        string w_choice = "none";
        string reset_checkmark = "small_round_nocheck.jpg";
        int mID;
        string mWork;
        string mWorkType;
        string mExercise;
        int mCount;
        bool is_exerciseDone;
        bool is_workoutDone;
        bool isDayActive;
        DateTime todayIs = DateTime.Now.Date;
        string mTime;
        bool mSchedule;
        int mNotificationID;
        bool activateStart;
        string status_string;

        object value;
        Type targetType;
        object parameter;
        CultureInfo culture;

        MyViewCell viewCellAccess;


        bool mMonday, mTuesday, mWednesday, mThursday, mFriday, mSaturday, mSunday;

        DateTime today_now = DateTime.Now;
        DateTime today_date = DateTime.Now.Date;
        DateTime today_full;

        private void defaultReset_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupReset(is_paid));

        }

        public My_WorkoutList_Page(bool paid)
        {
            InitializeComponent();

            
            this.BindingContext = MyViewModel.Instance;
            is_paid = paid;

            // workout_Listview.la




        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<SetWorkout>();

                 var setworkouts = conn.Table<SetWorkout>().ToList();

               // conn.Execute("DELETE FROM SetWorkout WHERE Id=?", 24);




                var workouts = (from w in setworkouts
                                    orderby w.Id
                                    select w.MyWorkout).Distinct().ToList();

                Dictionary<string, string> workoutList = new Dictionary<string, string>();
                foreach (var workout in workouts)
                {
                    var workout_status = (from k in setworkouts
                                 where k.MyWorkout == workout
                                 select k.Workout_Status).ToList();

                    var scheduled_time = (from j in setworkouts
                                          where j.MyWorkout == workout
                                          select j.TimeIs).ToList();

                    //---------------------------------------------------------------------

                    var exerciseCount = (from ec in setworkouts
                                         where ec.MyWorkout == workout && ec.ExDone == true
                                         select ec).ToList();

                    var exerciseTotal = (from et in setworkouts
                                         where et.MyWorkout == workout
                                         select et).ToList();
                    var scheduledExercise = (from sx in setworkouts
                                         where sx.MyWorkout == workout
                                         select sx.IsScheduled).ToList();

                    int count_exercise_done = exerciseCount.Count();
                    int count_exercise_total = exerciseTotal.Count();
                    bool isSched = scheduledExercise[0];



                    TimeSpan ts = TimeSpan.Parse(scheduled_time[0]);
                    today_full = today_date + ts;

                    ///////////////////////////////////////////////////////////////////
                    var monday_status = (from mn in setworkouts
                                         where mn.MyWorkout == workout
                                         select mn.Monday).Take(1).ToList();

                    mMonday = monday_status[0];

                    if (todayIs.DayOfWeek == DayOfWeek.Monday && mMonday == true)
                    {
                        isDayActive = true;


                    }
                    else if (todayIs.DayOfWeek == DayOfWeek.Monday && mMonday != true)
                    {
                        isDayActive = false;

                    }

                    //-------------------------------------------------------------

                    var tuesday_status = (from tu in setworkouts
                                          where tu.MyWorkout == workout
                                          select tu.Tuesday).Take(1).ToList();

                    mTuesday = tuesday_status[0];

                    if (todayIs.DayOfWeek == DayOfWeek.Tuesday && mTuesday == true)
                    {
                        isDayActive = true;


                    }
                    else if (todayIs.DayOfWeek == DayOfWeek.Tuesday && mTuesday != true)
                    {
                        isDayActive = false;

                    }

                    //-------------------------------------------------------------

                    var wednesday_status = (from wd in setworkouts
                                            where wd.MyWorkout == workout
                                            select wd.Wednesday).Take(1).ToList();

                    mWednesday = wednesday_status[0];

                    if (todayIs.DayOfWeek == DayOfWeek.Wednesday && mWednesday == true)
                    {
                        isDayActive = true;


                    }
                    else if (todayIs.DayOfWeek == DayOfWeek.Wednesday && mWednesday != true)
                    {
                        isDayActive = false;

                    }

                    //-------------------------------------------------------------

                    var thursday_status = (from th in setworkouts
                                           where th.MyWorkout == workout
                                           select th.Thursday).Take(1).ToList();

                    mThursday = thursday_status[0];

                    if (todayIs.DayOfWeek == DayOfWeek.Thursday && mThursday == true)
                    {
                        isDayActive = true;


                    }
                    else if (todayIs.DayOfWeek == DayOfWeek.Thursday && mThursday != true)
                    {
                        isDayActive = false;

                    }

                    //-------------------------------------------------------------

                    var friday_status = (from fr in setworkouts
                                         where fr.MyWorkout == workout
                                         select fr.Friday).Take(1).ToList();

                    mFriday = friday_status[0];

                    if (todayIs.DayOfWeek == DayOfWeek.Friday && mFriday == true)
                    {
                        isDayActive = true;


                    }
                    else if (todayIs.DayOfWeek == DayOfWeek.Friday && mFriday != true)
                    {
                        isDayActive = false;

                    }

                    //-------------------------------------------------------------

                    var saturday_status = (from st in setworkouts
                                           where st.MyWorkout == workout
                                           select st.Saturday).Take(1).ToList();

                    mSaturday = saturday_status[0];

                    if (todayIs.DayOfWeek == DayOfWeek.Saturday && mSaturday == true)
                    {
                        isDayActive = true;


                    }
                    else if (todayIs.DayOfWeek == DayOfWeek.Saturday && mSaturday != true)
                    {
                        isDayActive = false;

                    }

                    //-------------------------------------------------------------

                    var sunday_status = (from su in setworkouts
                                         where su.MyWorkout == workout
                                         select su.Sunday).Take(1).ToList();

                    mSunday = sunday_status[0];

                    if (todayIs.DayOfWeek == DayOfWeek.Sunday && mSunday == true)
                    {
                        isDayActive = true;


                    }
                    else if (todayIs.DayOfWeek == DayOfWeek.Sunday && mSunday != true)
                    {
                        isDayActive = false;

                    }

                    //-------------------------------------------------------------

                    ///////////////////////////////////////////////////////////////////

                    if (today_full <= today_now && count_exercise_done == 0 && isDayActive == true)
                    {
                        //viewCellAccess. ChangeStatusColor()
                        status_string = "Ready";


                        conn.Execute("UPDATE SetWorkout SET WorkoutReady= true WHERE MyWorkout=?", workout);
                        conn.Execute("UPDATE SetWorkout SET Workout_Status= '" + status_string + "' WHERE MyWorkout=?", workout);
                        workoutList.Add(workout, "Ready");

                    }

                    if (today_full <= today_now && count_exercise_done > 0 && count_exercise_done < count_exercise_total && isDayActive == true)
                    {
                        status_string = "In Progress";

                        conn.Execute("UPDATE SetWorkout SET WorkoutReady= true WHERE MyWorkout=?", workout);
                        conn.Execute("UPDATE SetWorkout SET Workout_Status= '" + status_string + "' WHERE MyWorkout=?", workout);
                        workoutList.Add(workout, "In Progress");
                    }

                    if (today_full <= today_now && count_exercise_done >= count_exercise_total && isDayActive == true)
                    {
                        status_string = "Completed";

                        conn.Execute("UPDATE SetWorkout SET WorkoutReady= true WHERE MyWorkout=?", workout);
                        conn.Execute("UPDATE SetWorkout SET Workout_Status= '" + status_string + "' WHERE MyWorkout=?", workout);
                        workoutList.Add(workout, "Completed");
                    }

                    if (today_full > today_now && count_exercise_done >= count_exercise_total && isDayActive == true)
                    {
                        status_string = "Set for today";

                        workoutList.Add(workout, "Set for today");

                        conn.Execute("UPDATE SetWorkout SET Workout_Status= '" + status_string + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET WorkoutReady= false WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET ExDone= false WHERE MyWorkout=?", workout);


                    }


                    if (today_full > today_now && count_exercise_done == 0 && isDayActive == true)
                    {
                        status_string = "Set for today";

                        workoutList.Add(workout, "Set for today" );

                        conn.Execute("UPDATE SetWorkout SET Workout_Status= '" + status_string + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET WorkoutReady= false WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET ExDone= false WHERE MyWorkout=?", workout);


                    }

                    if (isDayActive == false && isSched == true)
                    {
                        status_string = "On break today";

                        conn.Execute("UPDATE SetWorkout SET Workout_Status= '" + status_string + "' WHERE MyWorkout=?", workout);

                        workoutList.Add(workout, "On break today");

                        conn.Execute("UPDATE SetWorkout SET WorkoutReady= false WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET Checkmark = '" + reset_checkmark + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET ExDone_count = '" + 0 + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET WkDone_count = '" + 0 + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET ExDone= false WHERE MyWorkout=?", workout);

                    }

                    if (isSched == false && count_exercise_done > 0 && count_exercise_done < count_exercise_total)
                    {
                        status_string = "In Progress";

                        conn.Execute("UPDATE SetWorkout SET Workout_Status= '" + status_string + "' WHERE MyWorkout=?", workout);
                        conn.Execute("UPDATE SetWorkout SET WorkoutReady= false WHERE MyWorkout=?", workout);
                        workoutList.Add(workout, "In Progress");

                    }

                    if (isSched == false && count_exercise_done >= count_exercise_total)
                    {
                        status_string = "*Completed";

                        conn.Execute("UPDATE SetWorkout SET Workout_Status= '" + status_string + "' WHERE MyWorkout=?", workout);
                        conn.Execute("UPDATE SetWorkout SET WorkoutReady= false WHERE MyWorkout=?", workout);
                        workoutList.Add(workout, "*Completed");

                    }

                    if (isSched == false &&  count_exercise_done == 0)
                    {
                        status_string = "Un-Scheduled";

                        conn.Execute("UPDATE SetWorkout SET Workout_Status= '" + status_string + "' WHERE MyWorkout=?", workout);

                        conn.Execute("UPDATE SetWorkout SET WorkoutReady= false WHERE MyWorkout=?", workout);
                        workoutList.Add(workout, "Un-Scheduled");

                    }


                }

                workout_Listview.ItemsSource = workoutList; 
            }

        }

        private void Workout_Listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var sworkout= e.Item;
            KeyValuePair<string, string> kvp = (KeyValuePair<string, string>)sworkout;
            mWork = kvp.Key;
            var selectedWorkout = workout_Listview.SelectedItem as SetWorkout;


            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<SetWorkout>();

                var setworkouts = conn.Table<SetWorkout>().ToList();

                var monday_status = (from mn in setworkouts
                                     where mn.MyWorkout == mWork
                                     select mn.Monday).Take(1).ToList();

                mMonday = monday_status[0];

                if (todayIs.DayOfWeek == DayOfWeek.Monday && mMonday == true)
                {
                    isDayActive = true;


                }
                else if (todayIs.DayOfWeek == DayOfWeek.Monday && mMonday != true)
                {
                    isDayActive = false;

                }

                //-------------------------------------------------------------

                var tuesday_status = (from ts in setworkouts
                                      where ts.MyWorkout == mWork
                                      select ts.Tuesday).Take(1).ToList();

                mTuesday = tuesday_status[0];

                if (todayIs.DayOfWeek == DayOfWeek.Tuesday && mTuesday == true)
                {
                    isDayActive = true;


                }
                else if (todayIs.DayOfWeek == DayOfWeek.Tuesday && mTuesday != true)
                {
                    isDayActive = false;

                }

                //-------------------------------------------------------------

                var wednesday_status = (from wd in setworkouts
                                        where wd.MyWorkout == mWork
                                        select wd.Wednesday).Take(1).ToList();

                mWednesday = wednesday_status[0];

                if (todayIs.DayOfWeek == DayOfWeek.Wednesday && mWednesday == true)
                {
                    isDayActive = true;


                }
                else if (todayIs.DayOfWeek == DayOfWeek.Wednesday && mWednesday != true)
                {
                    isDayActive = false;

                }

                //-------------------------------------------------------------

                var thursday_status = (from th in setworkouts
                                       where th.MyWorkout == mWork
                                       select th.Thursday).Take(1).ToList();

                mThursday = thursday_status[0];

                if (todayIs.DayOfWeek == DayOfWeek.Thursday && mThursday == true)
                {
                    isDayActive = true;


                }
                else if (todayIs.DayOfWeek == DayOfWeek.Thursday && mThursday != true)
                {
                    isDayActive = false;

                }

                //-------------------------------------------------------------

                var friday_status = (from fr in setworkouts
                                     where fr.MyWorkout == mWork
                                     select fr.Friday).Take(1).ToList();

                mFriday = friday_status[0];

                if (todayIs.DayOfWeek == DayOfWeek.Friday && mFriday == true)
                {
                    isDayActive = true;


                }
                else if (todayIs.DayOfWeek == DayOfWeek.Friday && mFriday != true)
                {
                    isDayActive = false;

                }

                //-------------------------------------------------------------

                var saturday_status = (from st in setworkouts
                                       where st.MyWorkout == mWork
                                       select st.Saturday).Take(1).ToList();

                mSaturday = saturday_status[0];

                if (todayIs.DayOfWeek == DayOfWeek.Saturday && mSaturday == true)
                {
                    isDayActive = true;


                }
                else if (todayIs.DayOfWeek == DayOfWeek.Saturday && mSaturday != true)
                {
                    isDayActive = false;

                }

                //-------------------------------------------------------------

                var sunday_status = (from su in setworkouts
                                     where su.MyWorkout == mWork
                                     select su.Sunday).Take(1).ToList();

                mSunday = sunday_status[0];

                if (todayIs.DayOfWeek == DayOfWeek.Sunday && mSunday == true)
                {
                    isDayActive = true;


                }
                else if (todayIs.DayOfWeek == DayOfWeek.Sunday && mSunday != true)
                {
                    isDayActive = false;

                }

                //-------------------------------------------------------------
                var active_status = (from at in setworkouts
                                   where at.MyWorkout == mWork
                                   select at.WorkoutReady).Take(1).ToList();

                activateStart  = active_status[0];

                //-------------------------------------------------------------

                var time_status = (from tm in setworkouts
                                   where tm.MyWorkout == mWork
                                   select tm.TimeIs).Take(1).ToList();

                mTime = time_status[0];

                //--------------------------------------------------------------

                var schedule_status = (from sc in setworkouts
                                       where sc.MyWorkout == mWork
                                       select sc.IsScheduled).Take(1).ToList();

                mSchedule = schedule_status[0];

                //--------------------------------------------------------------

                var notificationID_status = (from nt in setworkouts
                                             where nt.MyWorkout == mWork
                                             select nt.Id).Take(1).ToList();

                mNotificationID = notificationID_status[0];

            }



            PopupNavigation.Instance.PushAsync(new Popup_Workout_ListView(selectedWorkout, is_paid, mID, mWork, mExercise, mWorkType, mCount, is_exerciseDone, is_workoutDone, false, mMonday, mTuesday, mWednesday, mThursday, mFriday, mSaturday, mSunday, mTime, mSchedule, mNotificationID, activateStart));
   
        }

        private void Add_workout_button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Popup_Repetitions(is_paid, 0, null, null, null, 0, true, mMonday, mTuesday, mWednesday, mThursday, mFriday, mSaturday, mSunday, mTime, mSchedule, mNotificationID));
        }

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
