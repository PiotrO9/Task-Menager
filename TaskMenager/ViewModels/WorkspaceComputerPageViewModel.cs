using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Interfaces;
using TaskMenager.Models;

namespace TaskMenager.ViewModels
{
    public class WorkspaceComputerPageViewModel : INotifyPropertyChanged
    {
        private IRealmEngine _iRealmEngine { get; set; }

        private string _sampleText;
        public string SampleText
        {
            get { return _sampleText; }
            set { _sampleText = value; OnPropertyChanged(); }
        }

        public WorkspaceComputerPageViewModel(IRealmEngine realmEngine)
        {
            _iRealmEngine = realmEngine;

            List<TaskToDo> taskToDos = _iRealmEngine.GetCollection();
            TaskToDo taskToDo = taskToDos.Where(w => w.TaskID == 1).FirstOrDefault();
            SampleText = taskToDo.TaskName;
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
