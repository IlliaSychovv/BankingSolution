using BankingSolution.Application.DTO.Transaction;
using FluentValidation;

namespace BankingSolution.Application.Validators;

public class DepositValidator : AbstractValidator<DepositDto>
{
    public DepositValidator()
    {
        RuleFor(x => x.AccountNumber)
            .NotEmpty().WithMessage("Account number cannot be empty")
            .MinimumLength(5).WithMessage("Account number must be at least 5 characters.");
        
        RuleFor(x => x.Balance)
            .GreaterThan(0).WithMessage("Balance must be greater than 0");
    }
}