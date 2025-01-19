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
- **End-to-End Tests**: Contains end-to-end tests to verify the complete workflow of the application.

## Setup Instructions

1. Clone the repository:
   ```sh
   git clone <repository-url>
   ```

2. Navigate to the solution directory:
   ```sh
   cd BankAccountSolution
   ```

3. Restore the dependencies:
   ```sh
   dotnet restore
   ```

4. Run the API:
   ```sh
   dotnet run --project BankAccountAPI
   ```

5. Run the tests:
   ```sh
   dotnet test BankAccountAPI.Tests
   ```

## Running Tests

To run the tests in this project, follow these steps:

1. Ensure you have the .NET SDK installed on your machine.
2. Open a terminal and navigate to the `BankAccountAPI.Tests` directory.
3. Run the following command to execute the tests:
   ```sh
   dotnet test
   ```

## Dependencies

This project may require the following NuGet packages for testing:

- `NUnit`: A popular testing framework for .NET.
- `Moq`: A library for creating mock objects in unit tests.

Make sure to restore the packages by running:
```sh
dotnet restore
```

## Technologies Used
- .NET 8 (or later)
- ASP.NET Core MVC
- Entity Framework Core 
- NUnit (for testing)

## Contributing
Feel free to submit issues or pull requests for improvements or bug fixes.