using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Models
{
    internal class Task
    {
        public int? TaskID { get; set; }
        public string? TaskName { get; set; }
        public string TaskDescription { get; set; }
        public TaskStatus? TaskStatus { get; set; }
        public uint DurationInSeconds { get; set; }
        public DateTime? AssignmentTime { get; set; }
    }
}
