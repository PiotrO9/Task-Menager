using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Interfaces;
using TaskMenager.Models;
using static Realms.ThreadSafeReference;

namespace TaskMenager.ViewModels
{
    public class WorkspaceComputerPageViewModel : INotifyPropertyChanged
    {
        #region Properties
        
        private IRealmEngine _iRealmEngine { get; set; }

        private string _sampleText;
        public string SampleText
        {
            get { return _sampleText; }
            set { _sampleText = value; OnPropertyChanged(); }
        }

        private System.Collections.Generic.List<TaskToDo> _strings;

        public System.Collections.Generic.List<TaskToDo> Strings
        {
            get { return _strings; }
            set { _strings = value; OnPropertyChanged();}
        }

        #endregion

        #region Commands

        public Command TaskClickCommand { get; }

        #endregion

        #region Constructor

        public WorkspaceComputerPageViewModel(IRealmEngine realmEngine)
        {
        _iRealmEngine = realmEngine;

            Strings = new System.Collections.Generic.List<TaskToDo>();

            for (int i = 1; i < 10; i++)
            {
                TaskToDo tmp = new TaskToDo();
                tmp.TaskID = i;
                tmp.TaskName = "Test task";
                tmp.TaskDescription = "Oto przykłądowy opis zadnaia jaki może realnie wystąpić";
                tmp.AssignmentTime = new DateTimeOffset(new DateTime(2115,10,10,21,15,0));
                tmp.DurationInSeconds = 60;
                tmp.IsTaskFinished = true;
                Strings.Add(tmp);
            }

            TaskClickCommand = new Command(TaskClickCommandImpl);
        }

        #endregion

        #region Methods

        public void TaskClickCommandImpl()
        {

        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
