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
            Balance = 0.0m; // Initialize balance to zero
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds.");
            Balance -= amount;
        }
    }
}