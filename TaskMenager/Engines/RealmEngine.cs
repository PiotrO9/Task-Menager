using Nito.AsyncEx;
using Realms;
using Realms.Sync;
using Realms.Sync.ErrorHandling;
using Realms.Sync.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Interfaces;
using TaskMenager.Models;
using static Realms.ThreadSafeReference;

namespace TaskMenager.Engines
{
    public class RealmEngine : IRealmEngine
    {
        private Realms.Sync.App _app { get; set; }

        private Realms.Sync.User _user { get; set; }

        private PartitionSyncConfiguration _config { get; set; }

        private Realms.Realm _realm { get; set; }

        public RealmEngine()
        {
            AsyncContext.Run(async () => await Configurate());
            //AsyncContext.Run(async () => await RestartConfiguration());
        }

        private async Task Configurate()
        {
            _app = Realms.Sync.App.Create("taskmenager-kdxyy");
            _user = await _app.LogInAsync(Credentials.Anonymous());
            _config = new PartitionSyncConfiguration("partition", _user);
            _realm = await Realm.GetInstanceAsync();
        }

        public TaskToDo GetTask(TaskToDo task)
        {
            return GetCollection().Where(w => w.TaskID == task.TaskID).First();
        }
        public System.Collections.Generic.List<TaskToDo> GetCollection()
        {
            return _realm.All<TaskToDo>().ToList();
        }

        public System.Collections.Generic.List<TaskToDo> GetCollectionForToday()
        {
            TaskType taskType = new TaskType(true);
            DateTimeOffset dto = System.DateTimeOffset.Now;
            System.Collections.Generic.List<TaskToDo> ResultCollection = GetCollection()
                .Where(w => w.TaskType.IsTaskCyclic == taskType.IsTaskCyclic)
                .Where(w => w.TaskType.NextDateOfTaskAppearance.Date == dto.Date)
                .ToList();

            foreach (var Task in ResultCollection)
            {
                Task.IsTaskFinished = false;
            }

            return ResultCollection;
        }

        public void AddTask(TaskToDo task)
        {
            _realm.Write(() =>
            {
                _realm.Add(task);
            });
        }
        public void RemoveItem(TaskToDo task)
        {
            _realm.Write(() =>
            {
                _realm.Remove(task);
            });
        }
        public void RemoveAll()
        {
            _realm.Write(() =>
            {
                _realm.RemoveAll();
            });
        }
        public void SetNextAppearance(TaskToDo taskToDo)
        {
            _realm.Write(() =>
            {
                TaskToDo FoundTask = GetCollection().Where(w => w.TaskID == taskToDo.TaskID).First();
                if (FoundTask == null)
                {
                    return;
                }

                if (FoundTask.IsTaskFinished == true && FoundTask.TaskType.IsTaskCyclic == true)
                {
                    FoundTask.TaskType.NextDateOfTaskAppearance = FoundTask.TaskType.NextDateOfTaskAppearance.AddDays(FoundTask.TaskType.TaskRepetetiveIntervalInDays);
                    return;
                }

                if (FoundTask.IsTaskFinished == false && FoundTask.TaskType.IsTaskCyclic == true)
                {
                    FoundTask.TaskType.NextDateOfTaskAppearance = System.DateTimeOffset.Now;
                    return;
                }
            });
        }

        public int GetCollectionLength()
        {
            return GetCollection().Count;
        }

        private async Task RestartConfiguration()
        {
            _app = Realms.Sync.App.Create("taskmenager-kdxyy");
            _user = await _app.LogInAsync(Credentials.Anonymous());
            _config = new PartitionSyncConfiguration("partition", _user);
            _realm = await Realm.GetInstanceAsync();
            _realm.Dispose();
            Realm.DeleteRealm(_realm.Config);
        }
    }
}
