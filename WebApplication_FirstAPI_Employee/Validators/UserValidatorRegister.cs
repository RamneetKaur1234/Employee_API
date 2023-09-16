using FluentValidation;
using WebApplication_FirstAPI_Employee.Models.ViewModels;

namespace WebApplication_FirstAPI_Employee.Validators
{
    public class UserValidatorRegister : AbstractValidator<UserVModel2>
    {
        public UserValidatorRegister()
        {
            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{PropertyName} must be Correct & Valid....!");

            RuleFor(p => p.Password)
                .NotEmpty()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")
                .WithMessage("Password must be between 6 and 20 characters and contain one uppercase letter," +
                                        " one lowercase letter," +
                                        " one digit and one special character...!!");

            RuleFor(p => p.ConfirmPassword)
                .Equal(p => p.Password)
                .WithMessage("{PropertyName} should be equal to Password...!!");

            RuleFor(p => p.Role)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should not be EMPTY....!")
                .Must(IsValidName).WithMessage("{PropertyName} should be all LETTERS...!!");
        }
        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
