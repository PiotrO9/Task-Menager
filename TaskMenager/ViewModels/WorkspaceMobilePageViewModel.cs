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
    public class WorkspaceMobilePageViewModel : INotifyPropertyChanged
    {
        #region Properties

        private IRealmEngine _iRealmEngine { get; set; }

        private System.Collections.Generic.List<TaskToDo> _tasks;

        public System.Collections.Generic.List<TaskToDo> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; OnPropertyChanged(); }
        }

        private int _heightOfMainCollectionView;

        public int HeightOfMainCollectionView
        {
            get { return _heightOfMainCollectionView; }
            set { _heightOfMainCollectionView = value; OnPropertyChanged(); }
        }

        public Command AddNewTaskCommand { get; set; }
        public Command RefreshCommand { get; set; }

        #endregion

        #region Constructors
        public WorkspaceMobilePageViewModel(IRealmEngine realmEngine)
        {
            _iRealmEngine = realmEngine;
            Tasks = AddSampleTasks.AddSampleTasksMethod();

            AddNewTaskCommand = new Command(AddNewTaskCommandImpl);
            RefreshCommand = new Command(RefreshCommandImpl);

            Tasks = _iRealmEngine.GetCollectionForToday();
        }

        #endregion

        #region Methods
        public void CalculateMainCollectionViewHeight()
        {
            if (Tasks.Count == 0)
            {
                HeightOfMainCollectionView = 0;
                return;
            }

            HeightOfMainCollectionView = Tasks.Count * 150;
        }
        public void RefreshCommandImpl()
        {
            Tasks = _iRealmEngine.GetCollectionForToday();
            CalculateMainCollectionViewHeight();
        }

        public async void AddNewTaskCommandImpl()
        {
            await Shell.Current.GoToAsync("AddNewTaskForMobile");
        }

        public async void NavigateToDetailPage(TaskToDo taskToDo)
        {
            var navigationParameter = new Dictionary<string, object>
                {
                    { "Task", taskToDo }
                };
            await Shell.Current.GoToAsync("WorkspaceMobileDetailPage", navigationParameter);
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
