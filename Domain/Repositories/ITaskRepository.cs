using Domain.Interfaces;
using Task = Domain.Entities.Task;

namespace Domain.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {
    }
}
