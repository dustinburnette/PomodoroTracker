using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PomodoroTracker.Models
{
    public class ProjectTask
    {
        public int ProjectTaskID { get; set; }
        public string Description { get; set; }
        public int EstimatedPomodoroCount { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public List<Pomodoro> Pomodoros { get; set; }
    }
}