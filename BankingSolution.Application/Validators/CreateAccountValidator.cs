using System.Data;
using BankingSolution.Application.DTO.Account;
using FluentValidation;

namespace BankingSolution.Application.Validators;

public class CreateAccountValidator : AbstractValidator<CreateAccountDto>
{
    public CreateAccountValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty")
            .Must(id => id != Guid.Empty).WithMessage("Id must be a valid GUID.");
        
        RuleFor(x => x.AccountNumber)
            .NotEmpty().WithMessage("Account number cannot be empty")
            .MinimumLength(5).WithMessage("Account number must be at least 5 characters.");
        
        RuleFor(x => x.AccountName)
            .NotEmpty().WithMessage("Account name cannot be empty")
            .MinimumLength(3).WithMessage("Account name must be at least 3 characters.");
        
        RuleFor(x => x.Balance)
            .NotEmpty().WithMessage("Balance cannot be empty")
            .GreaterThan(0).WithMessage("Balance must be greater than 0");
    }
}