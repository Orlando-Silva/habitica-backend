using Task = Domain.Entities.Task;

namespace Domain.Services
{
    public class TaskService
    {
        readonly private IUnityOfWork UnityOfWork;

        public TaskService(IUnityOfWork UnityOfWork)
        {
            this.UnityOfWork = UnityOfWork;
        }

        public Task AddTask(Task task)
        {
            var addedTask = UnityOfWork.Tasks.Add(task);
            UnityOfWork.Save();
            return addedTask;


        }

    }
}
