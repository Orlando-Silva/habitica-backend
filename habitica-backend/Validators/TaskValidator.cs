using FluentValidation;
using Task = Domain.Entities.Task;

namespace habitica_backend.Validators
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator() 
        {
            RuleFor(t => t.Name).NotEmpty().MaximumLength(64);
            RuleFor(t => t.Description).NotEmpty().MaximumLength(256);
        }
    }
}
