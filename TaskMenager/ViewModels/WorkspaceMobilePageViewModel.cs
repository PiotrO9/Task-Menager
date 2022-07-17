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

        #endregion

        #region Constructors
        public WorkspaceMobilePageViewModel(IRealmEngine realmEngine)
        {
            _iRealmEngine = realmEngine;
            Tasks = AddSampleTasks.AddSampleTasksMethod();
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
