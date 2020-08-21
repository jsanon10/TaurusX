using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaurusBetaX.Model
{
    
 
    public class WeekTraining
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string MyWorkout { get; set; }

        public string Exercise { get; set; }

        public string WorkoutType { get; set; }

        public int Reps { get; set; }

        public bool ExDone { get; set; }

        public int ExDone_count { get; set; }

        public bool WkDone { get; set; }

        public int WkDone_count { get; set; }

        public bool Wait { get; set; }

        public bool Active { get; set; }

        public string Checkmark { get; set; }

        public bool VibrationOn { get; set; }

        public string Yesterday { get; set; }    
    }

     
}

