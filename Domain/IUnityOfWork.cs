using Domain.Repository;

namespace Domain
{
    public interface IUnityOfWork : IDisposable
    {
        public ITaskRepository Tasks { get; }

        public ICompletedTaskRepository CompletedTasks { get; }

        void Save();
    }
}
