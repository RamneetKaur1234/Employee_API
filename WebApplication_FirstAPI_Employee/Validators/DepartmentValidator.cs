using FluentValidation;
using WebApplication_FirstAPI_Employee.Models.DTOs;

namespace WebApplication_FirstAPI_Employee.Validators
{
    public class DepartmentValidator:AbstractValidator<Department1DTO>
    {
        public DepartmentValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should not be EMPTY....!")
                .Length(2, 10)
                .Must(IsValidName).WithMessage("{PropertyName} should be all LETTERS...!!");
        }
        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
