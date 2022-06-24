using TaskMenager.Models;

namespace TaskMenager.Interfaces
{
    internal interface IRealmEngine
    {
        void AddTask(TaskToDo task);
        List<TaskToDo> GetCollection();
        TaskToDo GetTask(TaskToDo task);
        void RemoveAll();
        void RemoveItem(TaskToDo task);
        public int GetCollectionLength();
    }
}