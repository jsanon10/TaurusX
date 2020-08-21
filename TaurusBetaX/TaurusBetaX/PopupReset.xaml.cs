using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CsvHelper;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaurusBetaX.Model;
using System.IO;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupReset : PopupPage
    {
        bool is_paid;

        public PopupReset(bool paid)
        {
            InitializeComponent();

            is_paid = paid;
        }


        private void cancelDeleteBtn_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();

        }


        private void resetBtn_Clicked(object sender, EventArgs e)
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



                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<SetWorkout>();

                    conn.Execute("DELETE FROM SetWorkout");



                    ///

                    var allItems = conn.Table<SetWorkout>().ToList();
                    int rowcount = allItems.Count();

                    if (rowcount < 1)
                    {
                        foreach (SetWorkout record in records2)
                        {
                            conn.Execute("INSERT INTO SetWorkout (MyWorkout,Exercise,WorkoutType,Reps,ExDone,WkDone,ExDone_count,WkDone_count,Checkmark,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,TimeIs,IsScheduled,Notification_ID,Workout_Status,VibrationOn,WorkoutReady) VALUES ('" + record.MyWorkout + "', '" + record.Exercise + "','" + record.WorkoutType + "','" + record.Reps + "','" + record.ExDone + "','" + record.WkDone + "','" + record.ExDone_count + "','" + record.WkDone_count + "','" + record.Checkmark + "','" + record.Monday + "','" + record.Tuesday + "','" + record.Wednesday + "', '" + record.Thursday + "', '" + record.Friday + "', '" + record.Saturday + "', '" + record.Sunday + "', '" + record.TimeIs + "', '" + record.IsScheduled + "', '" + record.Notification_ID + "', '" + record.Workout_Status + "', '" + record.VibrationOn + "', '" + record.WorkoutReady + "' )");

                        }

                    }




                    PopupNavigation.Instance.PopAsync();

                    App.Current.MainPage = new My_WorkoutList_Page(is_paid);




                }       
            }

        }
    }
}