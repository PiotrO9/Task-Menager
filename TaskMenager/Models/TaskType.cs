using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Models
{
    public class TaskType : RealmObject
    {
        public bool IsTaskCyclic { get; set; }
        public DateTimeOffset NextDateOfTaskAppearance { get; set; }
        public int TaskRepetetiveIntervalInDays { get; set; }
        public TaskType(bool isTaskCyclic = false)
        {
            IsTaskCyclic = isTaskCyclic;
        }
        public TaskType()
        {

        }

    }
}
