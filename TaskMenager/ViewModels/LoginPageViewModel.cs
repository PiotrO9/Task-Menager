using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Engines;
using TaskMenager.Models;

namespace TaskMenager.ViewModels
{
    internal class LoginPageViewModel : INotifyPropertyChanged
    {
        private string _sampleText;

        public string SampleText
        {
            get { return _sampleText; }
            set { _sampleText = value; OnPropertyChanged(); }
        }

        public LoginPageViewModel()
        {
            RealmEngine realmEngine = new RealmEngine();

            TaskToDo tmp = new TaskToDo { TaskID = 1, TaskName = "TestName" };
            //realmEngine.AddTask(tmp);

            List<TaskToDo> taskToDos = realmEngine.GetCollection();

            TaskToDo temp2 = realmEngine.GetTask(tmp);
            SampleText = temp2.TaskName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
