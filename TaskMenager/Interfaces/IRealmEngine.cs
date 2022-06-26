using TaskMenager.Models;

namespace TaskMenager.Interfaces
{
    public interface IRealmEngine
    {
        void AddTask(TaskToDo task);
        List<TaskToDo> GetCollection();
        TaskToDo GetTask(TaskToDo task);
        void RemoveAll();
        void RemoveItem(TaskToDo task);
        public int GetCollectionLength();
    }
}