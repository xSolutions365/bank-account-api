using BankAccountAPI.Services;
using NUnit.Framework;
using FluentAssertions;

namespace BankAccountAPI.Tests.Services
{
    [TestFixture]
    public class PrimeServiceTest
    {
        private readonly PrimeService _primeService = new();

        [Test]
        public void IsPrime_ReturnsTrueForPrimeNumbers()
        {
            _primeService.IsPrime(3).Should().BeTrue();
        }

        [Test]
        public void IsPrime_ReturnsFalseForNonPrimeNumbers()
        {
            _primeService.IsPrime(4).Should().BeFalse();
        }
    }
}