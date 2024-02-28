using Class13.DTO;
using FluentValidation;

namespace Class13.BusinessLogic.Validators
{
    public class UserValidator: AbstractValidator<UserDto>
    {
        public UserValidator() {
            RuleFor(x => x.email).NotNull().NotEmpty().Length(0, 200).WithMessage("Email must not be empty");
            RuleFor(x => x.password).NotNull().NotEmpty().Length(0, 200).WithMessage("Password must not be empty");
        }
    }
}
