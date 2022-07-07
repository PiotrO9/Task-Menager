
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Models;

namespace TaskMenager.Engines
{
    public static class AddSampleTasks
    {
        public static List<TaskToDo> AddSampleTasksMethod()
        {
            List<TaskToDo> taskToDos = new List<TaskToDo>();

            TaskToDo tmp1 = new TaskToDo();
            tmp1.TaskID = 1;
            tmp1.TaskName = "Test task";
            tmp1.TaskDescription = "Oto przykłądowy opis zadnaia jaki może realnie wystąpić";
            tmp1.AssignmentTime = new DateTimeOffset(new DateTime(2115, 10, 10, 21, 15, 0));
            tmp1.DurationInSeconds = 60;
            tmp1.IsTaskFinished = true;
            taskToDos.Add(tmp1);

            TaskToDo tmp2 = new TaskToDo();
            tmp2.TaskID = 2;
            tmp2.TaskName = "Testowe zadanie";
            tmp2.TaskDescription = "Oto przykłądowy opis zadnaia jaki może realnie wystąpić - tym razem dłuższa wersja opiu zadania. ";
            tmp2.AssignmentTime = new DateTimeOffset(new DateTime(2115, 10, 10, 21, 15, 0));
            tmp2.DurationInSeconds = 600;
            tmp2.IsTaskFinished = false;
            taskToDos.Add(tmp2);

            TaskToDo tmp3 = new TaskToDo();
            tmp3.TaskID = 3;
            tmp3.TaskName = "Sprzątanie";
            tmp3.TaskDescription = "Sprzątanie to nie czynność, którą darzę sympatią. Niemniej jednak musze ją odczas do czasu wykonywać. Jest to jedno z zadań, które może regularnie się powtarzać w moich zdaniach";
            tmp3.AssignmentTime = new DateTimeOffset(new DateTime(2115, 10, 10, 21, 15, 0));
            tmp3.DurationInSeconds = 1600;
            tmp3.IsTaskFinished = true;
            taskToDos.Add(tmp3);

            return taskToDos;
        }
    }
}
