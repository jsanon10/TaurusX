using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaurusBetaX.Model
{
    
 
    public class SetWorkout
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

        public string Checkmark { get; set; }

        public bool Monday { get; set; }

        public bool Tuesday { get; set; }

        public bool Wednesday { get; set; }

        public bool Thursday { get; set; }

        public bool Friday { get; set; }

        public bool Saturday { get; set; }

        public bool Sunday { get; set; }

        public string TimeIs { get; set; }

        public bool IsScheduled { get; set; }

        public int Notification_ID { get; set; }

        public string Workout_Status { get; set; }

        public bool VibrationOn { get; set; }

        public bool WorkoutReady { get; set; }
    }

     
}

