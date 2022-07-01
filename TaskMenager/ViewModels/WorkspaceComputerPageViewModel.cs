using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TaskMenager.Interfaces;
using TaskMenager.Models;

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

        private TaskToDo _selectedTask;

        public TaskToDo SelectedTask
        {
            get { return _selectedTask; }
            set { _selectedTask = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands

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

        }

        #endregion

        #region Methods

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
