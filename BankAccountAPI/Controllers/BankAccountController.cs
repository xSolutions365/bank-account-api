using Microsoft.AspNetCore.Mvc;
using BankAccountAPI.Models;
using BankAccountAPI.Services;
using System.Collections.Generic;

namespace BankAccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BankAccount>> GetAllAccounts()
        {
            var accounts = _bankAccountService.GetAllAccounts();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public ActionResult<BankAccount> GetAccountById(int id)
        {
            var account = _bankAccountService.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost]
        public IActionResult CreateAccount(BankAccount account)
        {
            _bankAccountService.CreateAccount(account);
            return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, BankAccount account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _bankAccountService.UpdateAccount(account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            _bankAccountService.DeleteAccount(id);
            return NoContent();
        }
    }
}