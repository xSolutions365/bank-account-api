using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using BankAccountUI.Models;

namespace BankAccountUI.Pages
{
    public class BankAccountsModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BankAccountsModel> _logger;

        public BankAccountsModel(IHttpClientFactory httpClientFactory, ILogger<BankAccountsModel> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public List<BankAccount> Accounts { get; private set; } = new();

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("BankAccountAPI");

            try
            {
                Accounts = await client.GetFromJsonAsync<List<BankAccount>>("") ?? new List<BankAccount>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("Error fetching bank accounts: {Message}", ex.Message);
            }
        }
    }
}
