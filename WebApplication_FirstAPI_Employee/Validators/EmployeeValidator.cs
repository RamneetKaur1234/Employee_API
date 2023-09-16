using FluentValidation;
using WebApplication_FirstAPI_Employee.Models.DTOs;

namespace WebApplication_FirstAPI_Employee.Validators
{
    public class EmployeeValidator:AbstractValidator<Employee1DTO>
    {
        public EmployeeValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should not be EMPTY....!")
                .Length(2, 10)
                .Must(IsValidName).WithMessage("{PropertyName} should be all LETTERS...!!");

            RuleFor(p => p.Address)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should not be EMPTY....!")
                .Length(2, 25);

            RuleFor(p => p.Salary)
                .NotEmpty().WithMessage("{PropertyName} should not be EMPTY....!");

            RuleFor(p => p.EMail)
                .EmailAddress();
        }
        private bool  IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}