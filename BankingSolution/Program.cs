using Banking.Solution.Infrastructure.Data;
using Banking.Solution.Infrastructure.Repositories;
using BankingSolution.Application.Interfaces.Repositories;
using BankingSolution.Application.Interfaces.Services;
using BankingSolution.Application.Services;
using BankingSolution.Application.Validators;
using BankingSolution.Middlware;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DepositValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TransferValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<WithdrawValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    
builder.Services.AddScoped<IManagementRepository, ManagementRepository>();
builder.Services.AddScoped<IManagementService, ManagementService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IAccountTransactions, AccountTransactions>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();