using System;

namespace BankAccountAPI.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountHolderName { get; set; }
        public decimal Balance { get; set; }

        public BankAccount()
        {
            Balance = 0.0m;
        }

        public void Deposit(decimal amount, string transactionType)
        {
            if (!transactionType.EndsWith("Credit", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Transaction type must be Credit.");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            Balance += amount;
        }

        public void Withdraw(decimal amount, string transactionType)
        {
            if (!transactionType.EndsWith("Debit", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Transaction type must be Debit.");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            if (amount == Balance)
            {
                return;
            }
            Balance -= amount;
        }

        public void Transfer(BankAccount toAccount, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Transfer amount must be positive.");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            Balance -= amount;
            toAccount.Balance += amount;
        }
    }
}