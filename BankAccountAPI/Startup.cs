using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using BankAccountAPI.Models;
using BankAccountAPI.Services;

namespace BankAccountAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IBankAccountService, BankAccountService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var bankAccountService = serviceProvider.GetRequiredService<IBankAccountService>();
            PopulateAccountData(bankAccountService);
        }

        public void PopulateAccountData(IBankAccountService bankAccountService)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            Random rnd1 = new Random(DateTime.Now.Millisecond);
            Random rnd2 = new Random(DateTime.Now.Millisecond * 2);
            Random rnd3 = new Random(DateTime.Now.Millisecond * 3);

            int numAccounts = 0;
            while (numAccounts < 20)
            {
                try
                {
                    decimal bal = Math.Round((decimal)(rnd1.NextDouble() * (double)(50000 - 10) + (double)10), 2);
                    string[] names = { "John Smith", "Maria Garcia", "Mohammed Khan", "Sophie Dubois", "Liam Johnson", "Emma Martinez", "Noah Lee", "Olivia Kim", "William Chen", "Ava Wang", "James Brown", "Isabella Nguyen", "Benjamin Wilson", "Mia Li", "Lucas Anderson", "Charlotte Liu", "Alexander Taylor", "Amelia Patel", "Daniel Garcia", "Sophia Kim" };
                    string name = names[rnd2.Next(0, names.Length)];
                    string[] types = { "Savings", "Checking", "Money Market", "Certificate of Deposit", "Retirement" };
                    string type = types[rnd3.Next(0, types.Length)];

                    BankAccount acc = new BankAccount { AccountNumber = "Account " + (numAccounts + 1), Balance = bal, AccountHolderName = name };
                    accounts.Add(acc);

                    int transCount = 0;
                    while (transCount < 100)
                    {
                        decimal transAmt = Math.Round((decimal)(rnd2.NextDouble() * (double)(500 - (double)(-500)) + (double)(-500)), 2);
                        try
                        {
                            if (transAmt >= 0)
                            {
                                acc.Deposit(transAmt);
                                Console.WriteLine("Credit: " + transAmt + ", Balance: " + acc.Balance + ", Account Holder: " + acc.AccountHolderName + ", Account Type: " + type);
                            }
                            else
                            {
                                acc.Withdraw(-transAmt);
                                Console.WriteLine("Debit: " + -transAmt + ", Balance: " + acc.Balance + ", Account Holder: " + acc.AccountHolderName + ", Account Type: " + type);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Transaction failed: " + ex.Message);
                        }
                        transCount++;
                    }
                    Console.WriteLine("Account: " + acc.AccountNumber + ", Balance: " + acc.Balance + ", Account Holder: " + acc.AccountHolderName + ", Account Type: " + type);
                    numAccounts++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Account creation failed: " + ex.Message);
                }
            }

            foreach (BankAccount fromAcc in accounts)
            {
                foreach (BankAccount toAcc in accounts)
                {
                    if (fromAcc != toAcc)
                    {
                        try
                        {
                            decimal transferAmt = Math.Round((decimal)(rnd3.NextDouble() * (double)fromAcc.Balance), 2);
                            if (transferAmt > fromAcc.Balance) continue; // Prevent insufficient funds exceptions during transfer
                            fromAcc.Withdraw(transferAmt);
                            toAcc.Deposit(transferAmt);

                            Console.WriteLine("Transfer: " + transferAmt + " from " + fromAcc.AccountNumber + " (" + fromAcc.AccountHolderName + ") to " + toAcc.AccountNumber + " (" + toAcc.AccountHolderName + ")");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Transfer failed: " + ex.Message);
                        }
                    }
                }
            }

            bankAccountService.InitializeAccounts(accounts);
        }
    }
}