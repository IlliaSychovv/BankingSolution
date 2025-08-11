using BankingSolution.Application.DTO.Transaction;
using FluentValidation;

namespace BankingSolution.Application.Validators;

public class TransferValidator : AbstractValidator<TransferDto>
{
    public TransferValidator()
    {
        RuleFor(x => x.Amount)
            .NotEmpty().WithMessage("Amount cannot be empty")
            .GreaterThan(0).WithMessage("Amount must be greater than 0");
        
        RuleFor(x => x.FromAccount)
            .NotEmpty().WithMessage("From account number cannot be empty")
            .MinimumLength(5).WithMessage("Account number must be at least 5 characters.");
        
        RuleFor(x => x.ToAccount)
            .NotEmpty().WithMessage("To account number cannot be empty")
            .MinimumLength(5).WithMessage("Account number must be at least 5 characters.");
    }
}