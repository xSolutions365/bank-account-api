using System.ComponentModel.DataAnnotations;

namespace BankAccountUI.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }
        
        [Required]
        public string AccountHolderName { get; set; }
        
        public decimal Balance { get; set; }

        // Parameterless constructor for model binding
        public BankAccount()
        {
            AccountNumber = string.Empty;
            AccountHolderName = string.Empty;
            Balance = 0;
        }

        // Parameterized constructor for creating new accounts
        public BankAccount(string accountNumber, string accountHolderName, decimal balance = 0)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }
    }
}
