using BankAccountAPI.Controllers;
using BankAccountAPI.Models;
using BankAccountAPI.Services;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountAPI.Tests.Controllers
{
    [TestFixture]
    public class TransactionControllerTest
    {
        private TransactionController _controller;
        private Mock<IBankAccountService> _mockService;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IBankAccountService>();
            _controller = new TransactionController(_mockService.Object);
        }

        [Test]
        public void Deposit_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var accountId = 1;
            var amount = 100.0m;
            var transactionType = "ATM Credit";

            // Act
            var result = _controller.Deposit(accountId, amount, transactionType);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            _mockService.Verify(service => service.Deposit(accountId, amount, transactionType), Times.Once);
        }

        [Test]
        public void Withdraw_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var accountId = 1;
            var amount = 50.0m;
            var transactionType = "ATM Debit";

            // Act
            var result = _controller.Withdraw(accountId, amount, transactionType);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            _mockService.Verify(service => service.Withdraw(accountId, amount, transactionType), Times.Once);
        }

        [Test]
        public void Transfer_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var fromAccountId = 1;
            var toAccountId = 2;
            var amount = 50.0m;

            // Act
            var result = _controller.Transfer(fromAccountId, toAccountId, amount);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            _mockService.Verify(service => service.Transfer(fromAccountId, toAccountId, amount), Times.Once);
        }
    }
}