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

                        if (rowcount < 1)
                        {
                            foreach (WeekTraining record in records)
                            {
                                conn.Execute("INSERT INTO WeekTraining (MyWorkout,Exercise,WorkoutType,Reps,ExDone,WkDone,ExDone_count,WkDone_count,Wait,Active,Checkmark,Yesterday) VALUES ('" + record.MyWorkout + "', '" + record.Exercise + "','" + record.WorkoutType + "','" + record.Reps + "','" + record.ExDone + "','" + record.WkDone + "','" + record.ExDone_count + "','" + record.WkDone_count + "','" + record.Wait + "','" + record.Active + "','" + record.Checkmark + "','" + record.Yesterday + "')");

                            }

                        }
                    }

                }

                App.Current.MainPage = new Week_WorkoutList_Page(is_paid);
            }
            
        }

        private void Workout_Selection_Clicked(object sender, EventArgs e)
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

                    if (rowcount < 1)
                    {
                        foreach (WeekTraining record in records)
                        {
                            conn.Execute("INSERT INTO WeekTraining (MyWorkout,Exercise,WorkoutType,Reps,ExDone,WkDone,ExDone_count,WkDone_count,Wait,Active,Checkmark,Yesterday) VALUES ('" + record.MyWorkout + "', '" + record.Exercise + "','" + record.WorkoutType + "','" + record.Reps + "','" + record.ExDone + "','" + record.WkDone + "','" + record.ExDone_count + "','" + record.WkDone_count + "','" + record.Wait + "','" + record.Active + "','" + record.Checkmark + "','" + record.Yesterday + "')");

                        }

                    }
                }

            }

            App.Current.MainPage = new My_WorkoutList_Page();
        }
    }
}