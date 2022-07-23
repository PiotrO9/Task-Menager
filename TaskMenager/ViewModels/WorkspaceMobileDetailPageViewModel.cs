using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Models;

namespace TaskMenager.ViewModels
{
    public class WorkspaceMobileDetailPageViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        private TaskToDo _currentTask;

        public TaskToDo CurrentTask
        {
            get { return _currentTask; }
            set { _currentTask = value; OnPropertyChanged();  }
        }

        private bool _isCyclicTaskOptionsVisible;

        public bool IsCyclicTaskOptionsVisible
        {
            get { return _isCyclicTaskOptionsVisible; }
            set { _isCyclicTaskOptionsVisible = value; OnPropertyChanged(); }
        }


        public WorkspaceMobileDetailPageViewModel()
        {

        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            CurrentTask = query["Task"] as TaskToDo;
            OnPropertyChanged("CurrentTask");
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
