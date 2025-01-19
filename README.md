# Bank Account Solution

This solution contains a simple Bank Account MVC project with a REST API and accompanying unit tests. 

## Project Overview

### BankAccountAPI
- **Controllers**: Contains the `BankAccountController` which handles HTTP requests related to bank accounts.
- **Models**: Defines the `BankAccount` class representing a bank account with properties like `Id`, `AccountNumber`, `AccountHolderName`, and `Balance`.
- **Services**: Implements the `BankAccountService` class that provides business logic for managing bank accounts.

### BankAccountAPI.Tests
- **Controllers**: Contains unit tests for the `BankAccountController` to ensure correct handling of HTTP requests.
- **Services**: Contains unit tests for the `BankAccountService` to verify business logic and data manipulation.

## Setup Instructions

1. Clone the repository:
   ```
   git clone <repository-url>
   ```

2. Navigate to the solution directory:
   ```
   cd BankAccountSolution
   ```

3. Restore the dependencies:
   ```
   dotnet restore
   ```

4. Run the API:
   ```
   dotnet run --project BankAccountAPI
   ```

5. Run the tests:
   ```
   dotnet test BankAccountAPI.Tests
   ```

## Technologies Used
- .NET 6 (or later)
- ASP.NET Core MVC
- Entity Framework Core (if applicable)
- xUnit (for testing)

## Contributing
Feel free to submit issues or pull requests for improvements or bug fixes.