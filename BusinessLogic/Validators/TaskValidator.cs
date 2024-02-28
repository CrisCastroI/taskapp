using Class11.DAO;
using Class13.Domain;
using FluentValidation;

namespace Class13.BusinessLogic.Validators
{
    public class TaskValidator : AbstractValidator<TaskDto>
    {
        public TaskValidator() 
        { 
            RuleFor(x => x.name).NotNull().NotEmpty().Length(0,200).WithMessage("Task Name must not be empty");
            RuleFor(x => x.description).Length(0, 200).WithMessage("Description cant be longer than 200 characters");                        
        }
        
    }
}
