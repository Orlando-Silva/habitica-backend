using TaskStatus = Domain.Enums.TaskStatus;

namespace Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public TaskStatus Status { get; set; }
    }
}