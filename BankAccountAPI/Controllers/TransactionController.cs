using BankAccountAPI.Models;
using BankAccountAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public TransactionController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpPost("deposit")]
        public IActionResult Deposit(int accountId, decimal amount, string transactionType)
        {
            _bankAccountService.Deposit(accountId, amount, transactionType);
            return Ok();
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw(int accountId, decimal amount, string transactionType)
        {
            _bankAccountService.Withdraw(accountId, amount, transactionType);
            return Ok();
        }

        [HttpPost("transfer")]
        public IActionResult Transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            _bankAccountService.Transfer(fromAccountId, toAccountId, amount);
            return Ok();
        }
    }
}