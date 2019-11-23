using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaurusBetaX.Model
{
    class WeeklySchedule
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string MyWorkout { get; set; }

        public bool Monday { get; set; }

        public bool Tuesday { get; set; }

        public bool Wednesday { get; set; }

        public bool Thursday { get; set; }

        public bool Friday { get; set; }

        public bool Saturday { get; set; }

        public bool Sunday { get; set; }

        public string Today { get; set; }

    }
}
