using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PomodoroTracker.Models
{
    public class Project
    {
        public int ProjectID{ get; set; }
        public string Description { get; set; }

        public List<ProjectTask> ProjectTasks { get; set; }

        
    }
}