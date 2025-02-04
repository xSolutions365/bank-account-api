# Bank Account Solution

This solution contains a simple Bank Account MVC project with a REST API and accompanying unit tests, as well as a React UI for managing bank accounts.

## Project Overview

### BankAccountAPI
- **Controllers**: Contains the `BankAccountController` which handles HTTP requests related to bank accounts.
- **Models**: Defines the `BankAccount` class representing a bank account with properties like `Id`, `AccountNumber`, `AccountHolderName`, and `Balance`.
- **Services**: Implements the `BankAccountService` class that provides business logic for managing bank accounts.

### BankAccountAPI.Tests
- **Controllers**: Contains unit tests for the `BankAccountController` to ensure correct handling of HTTP requests.
- **Services**: Contains unit tests for the `BankAccountService` to verify business logic and data manipulation.
- **End-to-End Tests**: Contains end-to-end tests to verify the complete functionality of the API.

### bank-account-ui
- **Components**: Contains React components for creating and listing bank accounts.
- **Styles**: Contains CSS files for styling the React components.
- **Services**: Contains API service functions for interacting with the backend.

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

## Running the React UI

1. Ensure the .NET API is running.

2. Navigate to the `bank-account-ui` directory:
   ```sh
   cd bank-account-ui
   ```

3. Install the dependencies:
   ```sh
   npm install
   ```

4. Start the development server:
   ```sh
   npm run dev
   ```

5. Open your browser and go to `http://localhost:5173` to view the application.

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
- React
- TypeScript
- Vite

## Contributing
Feel free to submit issues or pull requests for improvements or bug fixes.