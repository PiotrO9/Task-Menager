using TaskMenager.Models;

namespace TaskMenager.Interfaces
{
    public interface IRealmEngine
    {
        void AddTask(TaskToDo task);
        List<TaskToDo> GetCollection();
        List<TaskToDo> GetCollectionForToday();
        TaskToDo GetTask(TaskToDo task);
        void RemoveAll();
        void RemoveItem(TaskToDo task);
        public int GetCollectionLength();
        void SetNextAppearance(TaskToDo taskToDo);
    }
}