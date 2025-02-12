using Microsoft.AspNetCore.Mvc;
using BankAccountAPI.Services;

namespace BankAccountAPI.Controllers {
    [ApiController]
    [Route("api/prime")]
    public class PrimeController : ControllerBase {
        private readonly PrimeService _primeService;

        public PrimeController(PrimeService primeService) {
            _primeService = primeService;
        }

        [HttpGet("{number}")]
        public ActionResult<bool> IsPrime(int number) {
            return Ok(_primeService.IsPrime(number));
        }
    }
}
