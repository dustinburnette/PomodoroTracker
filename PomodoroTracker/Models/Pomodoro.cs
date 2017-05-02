using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PomodoroTracker.Models
{
    public class Pomodoro
    {
        public int PomodoroID { get; set; }

        public int ProjectTaskID { get; set; }
        public ProjectTask ProjectTask { get; set; }

        public DateTime StartTime { get; set; }
        public int DurationInMinutes  { get; set; }
    }
}