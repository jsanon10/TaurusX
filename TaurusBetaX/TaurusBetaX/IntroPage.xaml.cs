using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaurusBetaX.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CsvHelper;
using System.Reflection;
using Rg.Plugins.Popup.Services;
using System.Data;

namespace TaurusBetaX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IntroPage : ContentPage
	{
        bool is_paid;
        int repInt;
        string w_choice = "none";

        public IntroPage (bool paid)
		{
			InitializeComponent ();

            is_paid = paid;

            if (is_paid == false)
            {
                workout_selection_button.TextColor = Color.LightGray;
                workout_selection_button.BorderColor = Color.Gray;
            
            }
        }

    

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (is_paid == true)
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("TaurusBetaX.workouts.csv"))
                using (var sr = new StreamReader(stream))
                {
                    /////////////////////////////
                    string myresult = stream.ToString();
                    ////////////////////////////

                    var reader = new CsvReader(sr);
                    reader.Configuration.HeaderValidated = null;
                    reader.Configuration.MissingFieldFound = null;

                    //CSVReader will now read the whole file into an enumerable
                    IEnumerable<WeekTraining> records = reader.GetRecords<WeekTraining>();

                    //First 5 records in CSV file will be printed to the Output Window
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                         conn.CreateTable<WeekTraining>();
                        var allItems = conn.Table<WeekTraining>().ToList();
                        int rowcount = allItems.Count();
                        
                        
                        
                        if (rowcount < 1)
                        {   

                            foreach (WeekTraining record in records)
                            {
                                conn.Execute("INSERT INTO WeekTraining (MyWorkout,Exercise,WorkoutType,Reps,ExDone,WkDone,ExDone_count,WkDone_count,Wait,Active,Checkmark,Yesterday) VALUES ('" + record.MyWorkout + "', '" + record.Exercise + "','" + record.WorkoutType + "','" + record.Reps + "','" + record.ExDone + "','" + record.WkDone + "','" + record.ExDone_count + "','" + record.WkDone_count + "','" + record.Wait + "','" + record.Active + "','" + record.Checkmark + "','" + record.Yesterday + "')");

                            }

                            conn.Execute("UPDATE WeekTraining SET Active= true WHERE MyWorkout=?", "Week 1");

                            var allItems2 = conn.Table<WeekTraining>().ToList();

                        }

                    }

                }

                App.Current.MainPage = new Week_WorkoutList_Page(is_paid);

            }

            else
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("TaurusBetaX.workouts.csv"))
                using (var sr = new StreamReader(stream))
                {
                    var reader = new CsvReader(sr);
                    reader.Configuration.HeaderValidated = null;
                    reader.Configuration.MissingFieldFound = null;

                    //CSVReader will now read the whole file into an enumerable
                    IEnumerable<WeekTraining> records = reader.GetRecords<WeekTraining>();

                    //First 5 records in CSV file will be printed to the Output Window
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                       

                        conn.CreateTable<WeekTraining>();
                        var allItems = conn.Table<WeekTraining>().ToList();
                        int rowcount = allItems.Count();

                        if (rowcount > 1)
                        {
                            foreach (WeekTraining record in records)
                            {
                               // conn.Execute("INSERT INTO WeekTraining (MyWorkout,Exercise,WorkoutType,Reps,ExDone,WkDone,ExDone_count,WkDone_count,Wait,Active,Checkmark,Yesterday) VALUES ('" + record.MyWorkout + "', '" + record.Exercise + "','" + record.WorkoutType + "','" + record.Reps + "','" + record.ExDone + "','" + record.WkDone + "','" + record.ExDone_count + "','" + record.WkDone_count + "','" + record.Wait + "','" + record.Active + "','" + record.Checkmark + "','" + record.Yesterday + "')");

                            }

                        }
                    }

                }

                App.Current.MainPage = new Week_WorkoutList_Page(is_paid);
            }
            
        }

        private void Workout_Selection_Clicked(object sender, EventArgs e)
        {

            if (is_paid == true)
            {

                var assembly2 = Assembly.GetExecutingAssembly();
                using (Stream stream2 = assembly2.GetManifestResourceStream("TaurusBetaX.defaultworkouts.csv"))
                using (var sr2 = new StreamReader(stream2))
                {

                    /////////////////////////////
                    string myresult2 = stream2.ToString();
                    ////////////////////////////

                    var reader2 = new CsvReader(sr2);
                    reader2.Configuration.HeaderValidated = null;
                    reader2.Configuration.MissingFieldFound = null;

                    //CSVReader will now read the whole file into an enumerable
                    IEnumerable<SetWorkout> records2 = reader2.GetRecords<SetWorkout>();

                    //First 5 records in CSV file will be printed to the Output Window
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<SetWorkout>();


                        var allItems = conn.Table<SetWorkout>().ToList();
                        int rowcount = allItems.Count();

                        if (rowcount < 1)
                        {
                            foreach (SetWorkout record in records2)
                            {
                                conn.Execute("INSERT INTO SetWorkout (MyWorkout,Exercise,WorkoutType,Reps,ExDone,WkDone,ExDone_count,WkDone_count,Checkmark,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,TimeIs,IsScheduled,Notification_ID,Workout_Status,VibrationOn,WorkoutReady) VALUES ('" + record.MyWorkout + "', '" + record.Exercise + "','" + record.WorkoutType + "','" + record.Reps + "','" + record.ExDone + "','" + record.WkDone + "','" + record.ExDone_count + "','" + record.WkDone_count + "','" + record.Checkmark + "','" + record.Monday + "','" + record.Tuesday + "','" + record.Wednesday + "', '" + record.Thursday + "', '" + record.Friday + "', '" + record.Saturday + "', '" + record.Sunday + "', '" + record.TimeIs + "', '" + record.IsScheduled + "', '" + record.Notification_ID + "', '" + record.Workout_Status + "', '" + record.VibrationOn + "', '" + record.WorkoutReady + "' )");
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                            }

                        }
                    }

                }

                App.Current.MainPage = new My_WorkoutList_Page(is_paid);
            }

            else if (is_paid == false)
            {

                PopupNavigation.Instance.PushAsync(new Popup_View());

            }
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new IntroPage(is_paid);
            return false;
        }

        private void go_navigate_back_button_Clicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new NewsPage(is_paid);

        }
    }
}