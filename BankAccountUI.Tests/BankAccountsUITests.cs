using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace BankAccountUI.Tests
{
    [TestFixture]
    public class BankAccountsUITests
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(); // ✅ Start Chrome browser
            _driver.Navigate().GoToUrl("http://localhost:5074/BankAccounts"); // ✅ Navigate to UI
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit(); // ✅ Close browser after test
        }

        [Test]
        public void BankAccountsPage_ShouldDisplayTable()
        {
            Thread.Sleep(2000); // ✅ Wait for the page to load (replace with WebDriverWait later)

            // Check if the table exists
            var table = _driver.FindElement(By.TagName("table"));
            Assert.IsNotNull(table, "Bank accounts table should be visible.");
        }
    }
}
