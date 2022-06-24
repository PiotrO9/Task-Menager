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

namespace TaskMenager.Engines
{
    internal class RealmEngine : IRealmEngine
    {
        private Realms.Sync.App _app { get; set; }

        private Realms.Sync.User _user { get; set; }

        private PartitionSyncConfiguration _config { get; set; }

        private Realms.Realm _realm { get; set; }

        public RealmEngine()
        {
            AsyncContext.Run(async () => await Configurate());
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
        public List<TaskToDo> GetCollection()
        {
            return _realm.All<TaskToDo>().ToList();
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
        public int GetCollectionLength()
        {
            return GetCollection().Count();
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
