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
    public class AddNewTaskForComputerViewModel : INotifyPropertyChanged
    {
        #region Fields

        private bool _isTaskCyclic;

        public bool IsTaskCyclic
        {
            get { return _isTaskCyclic; }
            set { _isTaskCyclic = value; OnPropertyChanged(); }
        }

        private List<string> _cyclicDaysRepetitive;

        public List<string> CyclicDaysRepetitive
        {
            get { return _cyclicDaysRepetitive; }
            set { _cyclicDaysRepetitive = value; OnPropertyChanged(); }
        }

        private string _taskName;

        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; OnPropertyChanged(); }
        }

        private string _taskDescription;

        public string TaskDescription
        {
            get { return _taskDescription; }
            set { _taskDescription = value; OnPropertyChanged(); }
        }

        private string _durationTime;

        public string DurationTime
        {
            get { return _durationTime; }
            set { _durationTime = value; OnPropertyChanged(); }
        }

        private string _selectedDayRepetitive;

        public string SelectedDayRepetitive
        {
            get { return _selectedDayRepetitive; }
            set { _selectedDayRepetitive = value; OnPropertyChanged(); }
        }

        private TimeSpan _selectedTime;

        public TimeSpan SelectedTime
        {
            get { return _selectedTime; }
            set { _selectedTime = value; OnPropertyChanged(); }
        }

        private TaskToDo _returnedTask;

        public TaskToDo ReturnedTask
        {
            get { return _returnedTask; }
            set { _returnedTask = value; OnPropertyChanged(); }
        }


        #endregion

        #region Commands

        public Command SubmitNewTaskCommand { get; set; }

        #endregion

        #region Constructor

        public AddNewTaskForComputerViewModel()
        {
            CyclicDaysRepetitive = GetCyclicDaysRepetitive.GetCyclicDaysRepetitiveMethod();
        }

        #endregion

        #region Methods

        public void SubmitNewTaskCommandImpl()
        {
            TaskToDo tmpTask = new TaskToDo();
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
