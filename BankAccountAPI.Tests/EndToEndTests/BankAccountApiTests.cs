using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BankAccountAPI;
using BankAccountAPI.Models;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using BankAccountAPI.Services;

namespace BankAccountAPI.Tests.EndToEndTests
{
    [TestFixture]
    public class BankAccountApiTests
    {
        private HttpClient _client;
        private IServiceScope _scope;
        private IBankAccountService _bankAccountService;

        [SetUp]
        public void SetUp() 
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
            _scope = appFactory.Services.CreateScope();
            _bankAccountService = _scope.ServiceProvider.GetRequiredService<IBankAccountService>();

            // Initialize test data
            var newAccount1 = new BankAccount { Id = 1, AccountNumber = "123", AccountHolderName = "John Doe", Balance = 1000 };
            var newAccount2 = new BankAccount { Id = 2, AccountNumber = "456", AccountHolderName = "Jane Doe", Balance = 2000 };
            _bankAccountService.InitializeAccounts(new List<BankAccount> { newAccount1, newAccount2 });
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _scope.Dispose();
        }

        [Test]
        public async Task GetAllAccounts_ReturnsOkResponse()
        {
            var response = await _client.GetAsync("/api/BankAccount");
            response.EnsureSuccessStatusCode();
            var accounts = await response.Content.ReadFromJsonAsync<List<BankAccount>>();
            Assert.IsNotNull(accounts);
        }

        [Test]
        public async Task GetAccountById_ReturnsOkResponse()
        {
            var response = await _client.GetAsync("/api/BankAccount/1");
            response.EnsureSuccessStatusCode();
            var account = await response.Content.ReadFromJsonAsync<BankAccount>();
            Assert.IsNotNull(account);
        }

        [Test]
        public async Task CreateAccount_ReturnsCreatedResponse()
        {
            var newAccount = new BankAccount { Id = 3, AccountNumber = "789", AccountHolderName = "Alice Doe", Balance = 3000 };
            var response = await _client.PostAsJsonAsync("/api/BankAccount", newAccount);
            response.EnsureSuccessStatusCode();
            var createdAccount = await response.Content.ReadFromJsonAsync<BankAccount>();
            Assert.IsNotNull(createdAccount);
        }

        [Test]
        public async Task UpdateAccount_ReturnsNoContentResponse()
        {
            var updatedAccount = new BankAccount { Id = 1, AccountNumber = "123", AccountHolderName = "John Doe Updated", Balance = 1500 };
            var response = await _client.PutAsJsonAsync("/api/BankAccount/1", updatedAccount);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task DeleteAccount_ReturnsNoContentResponse()
        {
            var response = await _client.DeleteAsync("/api/BankAccount/1");
            response.EnsureSuccessStatusCode();
        }
    }
}