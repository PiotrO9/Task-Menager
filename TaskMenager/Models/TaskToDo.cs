using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Interfaces;

namespace TaskMenager.Models
{
    public class TaskToDo : RealmObject
    {
        public int? TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsTaskFinished { get; set; }
        public int DurationInSeconds { get; set; }
        public DateTimeOffset AssignmentTime { get; set; }
        public TaskType TaskType { get; set; }

        public TaskToDo(IRealmEngine realmEngine, string NameOfTask)
        {
            TaskID = realmEngine.GetCollectionLength() + 1;

            if(string.IsNullOrEmpty(NameOfTask))
            {
                throw new Exception("Name of task is empty");
            }
            else
            {
                TaskName = NameOfTask;
            }

        }
        public TaskToDo()
        {

        }
    }
}
