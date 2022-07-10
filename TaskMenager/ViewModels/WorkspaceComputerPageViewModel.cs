using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TaskMenager.Engines;
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
            set { _strings = value; OnPropertyChanged(); }
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

        #endregion

        #region Constructor

        public WorkspaceComputerPageViewModel(IRealmEngine realmEngine)
        {
            DetailsInformationBackButtonCommand = new Command(DetailsInformationBackButtonCommandImpl);
            SortAlphabeticallyBtnCommand = new Command(SortAlphabeticallyBtnCommandImpl);
            SortByFinishedBtnCommand = new Command(SortByFinishedBtnCommandImpl);
            AddNewTaskCommand = new Command(AddNewTaskCommandImpl);

            _iRealmEngine = realmEngine;
            Strings = AddSampleTasks.AddSampleTasksMethod();

            CalculateMainCollectionViewHeight();
        }

        #endregion

        #region Methods

        public void DetailsInformationBackButtonCommandImpl()
        {
            SelectedTask = null;
        }

        public void CalculateMainCollectionViewHeight()
        {
            if (Strings.Count == 0)
            {
                HeightOfMainCollectionView = 0;
                return;
            }

            HeightOfMainCollectionView = Strings.Count * 150;
        }

        public void SortAlphabeticallyBtnCommandImpl()
        {
            Strings = Strings.OrderBy(x => x.TaskName).ToList();
            CalculateMainCollectionViewHeight();
        }
        public void SortByFinishedBtnCommandImpl()
        {
            Strings = Strings.OrderBy(x => x.IsTaskFinished).Reverse().ToList();
            CalculateMainCollectionViewHeight();
        }
        public async void AddNewTaskCommandImpl()
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
