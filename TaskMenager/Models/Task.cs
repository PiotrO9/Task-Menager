using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Models
{
    internal class TaskToDo : RealmObject
    {
        public int? TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsTaskFinished { get; set; }
        public int DurationInSeconds { get; set; }
        public DateTimeOffset AssignmentTime { get; set; }
        public TaskToDo AsignedTo { get; set; }
        //public Task MyProperty { get; set; }
    }
}
