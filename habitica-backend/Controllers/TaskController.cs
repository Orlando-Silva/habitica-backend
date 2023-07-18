using AutoMapper;
using Domain.Services;
using habitica_backend.DTO;
using Microsoft.AspNetCore.Mvc;
using Task = Domain.Entities.Task;

namespace habitica_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        
        private readonly TaskService taskService;

        private readonly IMapper mapper;

        public TaskController(TaskService taskService, IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult<Task> Create(CreateTaskDTO createTask)
        {
            var task = mapper.Map<Task>(createTask);
            return taskService.AddTask(task);      
        }
    }
}