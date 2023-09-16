using FluentValidation;
using WebApplication_FirstAPI_Employee.Models.ViewModels;

namespace WebApplication_FirstAPI_Employee.Validators
{
    public class UserValidatorAuthenticate:AbstractValidator<UserVM>
    {
        public UserValidatorAuthenticate()
        {
            RuleFor(p => p.Username)
                .NotEmpty().WithMessage("{PropertyName} is must be Correct...!!");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} Wrong Pswrd...!!");
        }
    }
}
