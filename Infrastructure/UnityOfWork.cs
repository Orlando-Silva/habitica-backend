using Domain;
using Domain.Repository;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly HabiticaContext _context;

        public ITaskRepository Tasks { get; private set; }

        public ICompletedTaskRepository CompletedTasks { get; private set; }

        public UnityOfWork(HabiticaContext context)
        {
            _context = context;
            Tasks = new TaskRepository(_context);
            CompletedTasks = new CompletedTaskRepository(_context);
        }

        public void Save() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
