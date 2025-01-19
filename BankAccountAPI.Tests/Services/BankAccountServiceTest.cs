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
    }
}