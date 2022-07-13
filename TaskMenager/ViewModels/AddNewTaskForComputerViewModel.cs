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
    public class AddNewTaskForComputerViewModel : INotifyPropertyChanged
    {
        #region Fields

        private IRealmEngine _iRealmEngine { get; set; }

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

        public AddNewTaskForComputerViewModel(IRealmEngine realmEngine)
        {
            _iRealmEngine = realmEngine;

            SubmitNewTaskCommand = new Command(SubmitNewTaskCommandImpl);

            CyclicDaysRepetitive = GetCyclicDaysRepetitive.GetCyclicDaysRepetitiveMethod();
        }

        #endregion

        #region Methods

        public void SubmitNewTaskCommandImpl()
        {
            if(string.IsNullOrWhiteSpace(TaskName))
            {
                return;
            }

            TaskToDo tmpTask = new TaskToDo(_iRealmEngine, TaskName);
            if(!string.IsNullOrWhiteSpace(TaskDescription))
            {
                tmpTask.TaskDescription = TaskDescription;
            }

            if(!string.IsNullOrWhiteSpace(DurationTime))
            {
                if(int.TryParse(DurationTime, out int temporaryAmountOfTime))
                {
                    tmpTask.DurationInSeconds = temporaryAmountOfTime * 60;
                }
            }

            tmpTask.AssignmentTime = DateTimeOffset.Now;

            if(IsTaskCyclic)
            {
                TaskType temporaryTaskType = new TaskType(true);
                if(string.IsNullOrEmpty(SelectedDayRepetitive))
                {
                    temporaryTaskType.TaskRepetetiveIntervalInDays = 1;
                }
                else
                {
                    temporaryTaskType.TaskRepetetiveIntervalInDays = int.Parse(SelectedDayRepetitive);
                }
                DateTime temporaryDateTime = DateTime.Today + SelectedTime;

                temporaryTaskType.NextDateOfTaskAppearance = new DateTimeOffset(temporaryDateTime);
                tmpTask.TaskType = temporaryTaskType;
            }
            else
            {
                tmpTask.TaskType = new TaskType(false);
            }

            ReturnedTask = tmpTask;
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
