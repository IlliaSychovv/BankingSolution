# Banking Solution

## Description

Banking Solution is a modern multi-layered .NET application implementing a comprehensive banking system with clean architecture, test coverage, and support for account management and financial transactions.

## Architecture

The project is built following Clean Architecture principles and is divided into layers:

- **Domain** — domain entities, business rules, and domain exceptions.
- **Application** — business logic, services, interfaces, DTOs, validation, and use cases.
- **Infrastructure** — repository implementations, database access (Entity Framework Core), migrations.
- **Web (BankingSolution)** — ASP.NET Core Web API, controllers, middleware, dependency injection, and Swagger documentation.

## Main Technologies and Tools

- **.NET 8** — modern development platform
- **Entity Framework Core** — ORM for database access with PostgreSQL
- **Mapster** — DTO ↔ Entity mapping
- **FluentValidation** — DTO validation
- **SequentialGuid** — GUID generation for entities
- **Swagger** — auto-generated API documentation
- **xUnit, Moq, Shouldly** — unit testing framework and mocking

## Getting Started

### 1. Prerequisites

- .NET 8 SDK
- PostgreSQL database
- IDE (Visual Studio, Rider, or VS Code)

### 2. Clone and Setup

```bash
git clone https://github.com/your-username/banking-solution.git
cd banking-solution
```

### 3. Configuration

Set up connection strings in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=BankingSolution;Username=your_username;Password=your_password"
  }
}
```

### 4. Database Setup

Run Entity Framework migrations:

```bash
cd BankingSolution.Infrastructure
dotnet ef database update
```

### 5. Build and Run

```bash
# Build the solution
dotnet build

# Run the application
cd BankingSolution
dotnet run
```

### 6. Swagger UI

After starting the API, documentation is available at:
- **Development**: http://localhost:5296/swagger
- **Production**: http://localhost:80/swagger

## Key Features

### Account Management
- Create new bank accounts with unique account numbers
- Retrieve account information by account number
- Paginated listing of all accounts
- Account balance tracking

### Transaction Processing
- **Deposits**: Add funds to existing accounts
- **Withdrawals**: Remove funds with balance validation
- **Transfers**: Move funds between accounts with transaction safety
- **Balance Validation**: Ensures sufficient funds before transactions

### Data Validation
- Comprehensive input validation using FluentValidation
- Business rule enforcement at the domain level
- Proper error handling and user-friendly error messages

### Exception Handling
- Global exception middleware for consistent error responses
- Domain-specific exceptions for business rule violations
- Proper HTTP status codes for different error scenarios

## Testing

The project includes comprehensive unit tests covering:

- **Management Service Tests**: Account creation, retrieval, and pagination
- **Transaction Service Tests**: Deposit, withdrawal, and transfer operations
- **Positive Scenarios**: Successful operations with valid data
- **Negative Scenarios**: Error handling and validation failures

Run tests:

```bash
dotnet test
```

## Development Guidelines

### Architecture Principles
- **Dependency Inversion**: Depend on abstractions, not concretions
- **Single Responsibility**: Each class has one reason to change
- **Open/Closed**: Open for extension, closed for modification
- **Interface Segregation**: Use specific interfaces over general ones

### Best Practices
- Use async/await for database operations
- Implement proper validation at multiple layers
- Use DTOs for data transfer between layers
- Implement proper exception handling
- Use dependency injection for loose coupling

## Configuration

### Environment Variables
- `ASPNETCORE_ENVIRONMENT`: Set to `Development`, `Staging`, or `Production`
- `ConnectionStrings__DefaultConnection`: Database connection string

## Security Considerations

- Input validation and sanitization
- SQL injection prevention through Entity Framework
- Proper error handling without exposing sensitive information
- HTTPS enforcement in production

## Performance Optimization

- Entity Framework query optimization
- Proper indexing on database tables
- Async/await pattern for I/O operations
- Efficient pagination for large datasets


## Contacts

- **Author**: Illia Sychov
- **Email**: illiasychov@gmail.com
- **GitHub**: https://github.com/IlliaSychovv

---

**Note**: This project meets industry standards and you can use it for your own goal  