using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Engines;
using TaskMenager.Interfaces;
using TaskMenager.Models;

namespace TaskMenager.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private IRealmEngine _iRealmEngine { get; set; }

        private string _sampleText;

        public string SampleText
        {
            get { return _sampleText; }
            set { _sampleText = value; OnPropertyChanged(); }
        }

        public LoginPageViewModel(IRealmEngine realmEngine)
        {
            _iRealmEngine = realmEngine;

            TaskToDo tmp = new TaskToDo(_iRealmEngine, "Cleaning room");
            _iRealmEngine.AddTask(tmp);

            TaskToDo temp2 = _iRealmEngine.GetTask(tmp);
            SampleText = temp2.TaskName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
