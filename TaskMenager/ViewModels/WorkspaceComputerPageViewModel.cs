using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TaskMenager.Engines;
using TaskMenager.Interfaces;
using TaskMenager.Models;
using TaskMenager.Pages;

namespace TaskMenager.ViewModels
{
    public class WorkspaceComputerPageViewModel : INotifyPropertyChanged
    {
        #region Properties
        private IRealmEngine _iRealmEngine { get; set; }
        private IServiceProvider _iServiceProvider { get; set; }

        private string _sampleText;
        public string SampleText
        {
            get { return _sampleText; }
            set { _sampleText = value; OnPropertyChanged(); }
        }

        private System.Collections.Generic.List<TaskToDo> _tasks;

        public System.Collections.Generic.List<TaskToDo> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; OnPropertyChanged(); }
        }

        private TaskToDo _selectedTask;

        public TaskToDo SelectedTask
        {
            get { return _selectedTask; }
            set { _selectedTask = value; OnPropertyChanged(); }
        }

        private int _heightOfMainCollectionView;

        public int HeightOfMainCollectionView
        {
            get { return _heightOfMainCollectionView; }
            set { _heightOfMainCollectionView = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public Command DetailsInformationBackButtonCommand { get; set; }
        public Command SortAlphabeticallyBtnCommand { get; set; }
        public Command SortByFinishedBtnCommand { get; set; }
        public Command AddNewTaskCommand { get; set; }
        public Command RefreshCommand { get; set; }

        #endregion

        #region Constructor

        public WorkspaceComputerPageViewModel(IRealmEngine realmEngine, IServiceProvider serviceProvider)
        {
            DetailsInformationBackButtonCommand = new Command(DetailsInformationBackButtonCommandImpl);
            SortAlphabeticallyBtnCommand = new Command(SortAlphabeticallyBtnCommandImpl);
            SortByFinishedBtnCommand = new Command(SortByFinishedBtnCommandImpl);
            AddNewTaskCommand = new Command(AddNewTaskCommandImpl);
            RefreshCommand = new Command(RefreshCommandImpl);

            _iRealmEngine = realmEngine;
            _iServiceProvider = serviceProvider;
            Tasks = _iRealmEngine.GetCollectionForToday();

            CalculateMainCollectionViewHeight();
        }

        #endregion

        #region Methods

        public void DetailsInformationBackButtonCommandImpl()
        {
            SelectedTask = null;
        }

        public void RefreshCommandImpl()
        {
            Tasks = _iRealmEngine.GetCollectionForToday();
            CalculateMainCollectionViewHeight();
        }

        public void UpdateFinishState(TaskToDo taskToDo)
        {
            _iRealmEngine.SetNextAppearance(taskToDo);
        }

        public void CalculateMainCollectionViewHeight()
        {
            if (Tasks.Count == 0)
            {
                HeightOfMainCollectionView = 0;
                return;
            }

            HeightOfMainCollectionView = Tasks.Count * 150;
        }

        public void SortAlphabeticallyBtnCommandImpl()
        {
            Tasks = Tasks.OrderBy(x => x.TaskName).ToList();
            CalculateMainCollectionViewHeight();
        }
        public void SortByFinishedBtnCommandImpl()
        {
            Tasks = Tasks.OrderBy(x => x.IsTaskFinished).Reverse().ToList();
            CalculateMainCollectionViewHeight();
        }
        public async void AddNewTaskCommandImpl()
{
            await Shell.Current.GoToAsync("AddNewTaskForComputer");
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
