using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using BankAccountAPI.Models;
using BankAccountAPI.Services;
using System;

namespace BankAccountAPI.Tests.Services
{
    [TestFixture]
    public class BankAccountServiceTest
    {
        private BankAccountService _service;

        [SetUp]
        public void Setup()
        {
            _service = new BankAccountService();
            _service.InitializeAccounts(new List<BankAccount>()); // Clear the accounts list before each test
        }

        [Test]
        public void GetAllAccounts_ShouldReturnAllAccounts()
        {
            // Arrange
            var expectedAccounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = "123456", AccountHolderName = "John Doe", Balance = 1000 },
                new BankAccount { Id = 2, AccountNumber = "654321", AccountHolderName = "Jane Doe", Balance = 2000 }
            };

            foreach (var account in expectedAccounts)
            {
                _service.CreateAccount(account);
            }

            // Act
            var accounts = _service.GetAllAccounts();

            // Assert
            Assert.AreEqual(expectedAccounts.Count, accounts.Count());
        }

        [Test]
        public void GetAccountById_ValidId_ShouldReturnAccount()
        {
            // Arrange
            var account = new BankAccount { Id = 1, AccountNumber = "123456", AccountHolderName = "John Doe", Balance = 1000 };
            _service.CreateAccount(account);

            // Act
            var result = _service.GetAccountById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(account.AccountNumber, result.AccountNumber);
        }

        [Test]
        public void CreateAccount_ShouldAddAccount()
        {
            // Arrange
            var account = new BankAccount { Id = 1, AccountNumber = "123456", AccountHolderName = "John Doe", Balance = 1000 };

            // Act
            _service.CreateAccount(account);
            var result = _service.GetAccountById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(account.AccountNumber, result.AccountNumber);
        }

        [Test]
        public void UpdateAccount_ValidId_ShouldUpdateAccount()
        {
            // Arrange
            var account = new BankAccount { Id = 1, AccountNumber = "123456", AccountHolderName = "John Doe", Balance = 1000 };
            _service.CreateAccount(account);
            account.Balance = 1500;

            // Act
            _service.UpdateAccount(account);
            var result = _service.GetAccountById(1);

            // Assert
            Assert.AreEqual(1500, result.Balance);
        }

        [Test]
        public void DeleteAccount_ValidId_ShouldRemoveAccount()
        {
            // Arrange
            var account = new BankAccount { Id = 1, AccountNumber = "123456", AccountHolderName = "John Doe", Balance = 1000 };
            _service.CreateAccount(account);

            // Act
            _service.DeleteAccount(1);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _service.GetAccountById(1));
        }

        [Test]
        public void InitialiseAccounts_ShouldClearExistingAccounts()
        {
            // Arrange
             var account1 = new BankAccount { AccountNumber = "123456", AccountHolderName = "John Doe", Balance = 1000 };
            _service.CreateAccount(account1);
            var accounts = new List<BankAccount> { new BankAccount { AccountNumber = "654321", AccountHolderName = "Jane Doe", Balance = 2000 } };

            // Act
            _service.InitializeAccounts(accounts);

            // Assert
            Assert.AreEqual(accounts.Count, _service.GetAllAccounts().Count());
        }

        // [Test]
        // public void GetAccountById_InvalidId_ShouldReturnNull()
        // {
        //     // Act
        //     var result = _service.GetAccountById(999); // Non-existent ID

        //     // Assert
        //     Assert.IsNull(result);
        // }

        // [Test]
        // public void UpdateAccount_InvalidId_ShouldThrowException()
        // {
        //     // Arrange
        //     var account = new BankAccount { Id = 999, AccountNumber = "123456", AccountHolderName = "John Doe", Balance = 1000 }; // Invalid ID

        //     // Act & Assert
        //     Assert.Throws<InvalidOperationException>(() => _service.UpdateAccount(account)); 
        // }


        // [Test]
        // public void DeleteAccount_InvalidId_ShouldNotThrowException()
        // {

        //     // Act
        //     _service.DeleteAccount(999); // Non-existent ID

        //     // Assert
        //     Assert.Pass(); 
        // }


        // [Test]
        // public void CreateAccount_DuplicateAccountNumber_ShouldThrowException()
        // {
        //     // Arrange
        //     var account1 = new BankAccount { AccountNumber = "123456", AccountHolderName = "John Doe", Balance = 1000 };
        //     var account2 = new BankAccount { AccountNumber = "123456", AccountHolderName = "Jane Doe", Balance = 2000 }; // Duplicate

        //     // Act
        //     _service.CreateAccount(account1);

        //     // Assert
        //     Assert.Throws<ArgumentException>(() => _service.CreateAccount(account2)); 
        // }

    }
}