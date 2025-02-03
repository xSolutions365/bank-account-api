using System;
using NUnit.Framework;
using FluentAssertions;
using BankAccountAPI.Models;

namespace BankAccountAPI.Tests.Models
{
    public class BankAccountTest
    {
        [Test]
        public void Deposit_ShouldIncreaseBalance_WhenTransactionTypeIsCredit()
        {
            // Arrange
            var account = new BankAccount();
            decimal depositAmount = 100.0m;

            // Act
            account.Deposit(depositAmount, "Credit");

            // Assert
            account.Balance.Should().Be(depositAmount);
        }

        [Test]
        public void Deposit_ShouldThrowArgumentException_WhenTransactionTypeIsNotCredit()
        {
            // Arrange
            var account = new BankAccount();
            decimal depositAmount = 100.0m;

            // Act & Assert
            Action act = () => account.Deposit(depositAmount, "Debit");
            act.Should().Throw<ArgumentException>().WithMessage("Transaction type must be Credit.");
        }

        [Test]
        public void Deposit_ShouldThrowArgumentException_WhenAmountIsNotPositive()
        {
            // Arrange
            var account = new BankAccount();
            decimal depositAmount = -100.0m;

            // Act & Assert
            Action act = () => account.Deposit(depositAmount, "Credit");
            act.Should().Throw<ArgumentException>().WithMessage("Deposit amount must be positive.");
        }

        [Test]
        public void Withdraw_ShouldDecreaseBalance_WhenTransactionTypeIsDebit()
        {
            // Arrange
            var account = new BankAccount();
            decimal depositAmount = 100.0m;
            decimal withdrawAmount = 50.0m;
            account.Deposit(depositAmount, "Credit");

            // Act
            account.Withdraw(withdrawAmount, "Debit");

            // Assert
            account.Balance.Should().Be(depositAmount - withdrawAmount);
        }

        [Test]
        public void Withdraw_ShouldThrowArgumentException_WhenTransactionTypeIsNotDebit()
        {
            // Arrange
            var account = new BankAccount();
            decimal withdrawAmount = 50.0m;

            // Act & Assert
            Action act = () => account.Withdraw(withdrawAmount, "Credit");
            act.Should().Throw<ArgumentException>().WithMessage("Transaction type must be Debit.");
        }

        [Test]
        public void Withdraw_ShouldThrowArgumentException_WhenAmountIsNotPositive()
        {
            // Arrange
            var account = new BankAccount();
            decimal withdrawAmount = -50.0m;

            // Act & Assert
            Action act = () => account.Withdraw(withdrawAmount, "Debit");
            act.Should().Throw<ArgumentException>().WithMessage("Withdrawal amount must be positive.");
        }

        [Test]
        public void Withdraw_ShouldThrowInvalidOperationException_WhenInsufficientFunds()
        {
            // Arrange
            var account = new BankAccount();
            decimal withdrawAmount = 50.0m;

            // Act & Assert
            Action act = () => account.Withdraw(withdrawAmount, "Debit");
            act.Should().Throw<InvalidOperationException>().WithMessage("Insufficient funds.");
        }

        [Test]
        public void Deposit_ShouldIncreaseBalanceMultipleTimes()
        {
            // Arrange
            var account = new BankAccount();
            decimal firstDeposit = 100.0m;
            decimal secondDeposit = 200.0m;

            // Act
            account.Deposit(firstDeposit, "Credit");
            account.Deposit(secondDeposit, "Credit");

            // Assert
            account.Balance.Should().Be(firstDeposit + secondDeposit);
        }

        [Test]
        public void Withdraw_ShouldThrowInvalidOperationException_WhenWithdrawMoreThanBalance()
        {
            // Arrange
            var account = new BankAccount();
            decimal depositAmount = 100.0m;
            decimal withdrawAmount = 150.0m;
            account.Deposit(depositAmount, "Credit");

            // Act & Assert
            Action act = () => account.Withdraw(withdrawAmount, "Debit");
            act.Should().Throw<InvalidOperationException>().WithMessage("Insufficient funds.");
        }
    }
}