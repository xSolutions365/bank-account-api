using BankAccountAPI.Controllers;
using BankAccountAPI.Models;
using BankAccountAPI.Services;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankAccountAPI.Tests.Controllers
{
    [TestFixture]
    public class BankAccountControllerTest
    {
        private BankAccountController _controller;
        private Mock<IBankAccountService> _mockService;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IBankAccountService>();
            _controller = new BankAccountController(_mockService.Object);
        }

        [Test]
        public void GetAllAccounts_ReturnsOkResult()
        {
            // Arrange
            var accounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = "123", AccountHolderName = "John Doe", Balance = 1000 },
                new BankAccount { Id = 2, AccountNumber = "456", AccountHolderName = "Jane Doe", Balance = 2000 }
            };
            _mockService.Setup(service => service.GetAllAccounts()).Returns(accounts);

            // Act
            var result = _controller.GetAllAccounts();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(accounts, okResult.Value);
        }

        [Test]
        public void GetAccountById_ValidId_ReturnsOkResult()
        {
            // Arrange
            var account = new BankAccount { Id = 1, AccountNumber = "123", AccountHolderName = "John Doe", Balance = 1000 };
            _mockService.Setup(service => service.GetAccountById(1)).Returns(account);

            // Act
            var result = _controller.GetAccountById(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(account, okResult.Value);
        }
    }
}