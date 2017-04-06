using SimpleBankApplication.Domain;
using FluentAssertions;
using Xunit;

namespace SimpleBankApplication.DomainTests.UnitTests
{
    public class BalanceTests
    {
        [Fact]
        public void Equal_SameAttributes_ShouldBeEqual()
        {
            var balance1 = new Balance(Currency.Euro, 100);
            var balance2 = new Balance(Currency.Euro, 100);

            balance1.Should().Be(balance2);
        }

        [Fact]
        public void Equal_DifferentAmounts_ShouldNotBeEqual()
        {
            var balance1 = new Balance(Currency.Euro, 100);
            var balance2 = new Balance(Currency.Euro, 100.01f);

            balance1.Should().NotBe(balance2);
        }

        [Theory]
        [InlineData(0, 5, 5)]
        [InlineData(10, 0.5, 10.5)]
        [InlineData(-9.1, 4.32, -4.78)]
        public void Increase_InitialAmount_ShouldBeIncreasedWithGivenAmountWhileCurrencyKeepsUntouched(float initialAmount, float increase, float expectedAmount)
        {
            var balance = new Balance(Currency.Euro, initialAmount);

            var newBalance = balance.IncreaseWith(new Money(Currency.Euro, increase));

            newBalance.Amount.Should().Be(expectedAmount);
            newBalance.Currency.Should().Be(balance.Currency);
        }

        [Theory]
        [InlineData(0, 5, -5)]
        [InlineData(10, 0.5, 9.5)]
        [InlineData(-9.1, 4.32, -13.42)]
        public void Decrease_InitialAmount_ShouldBeDecreasedWithGivenAmountWhileCurrencyKeepsUntouched(float initialAmount, float increase, float expectedAmount)
        {
            var balance = new Balance(Currency.Euro, initialAmount);

            var newBalance = balance.DecreaseWith(new Money(Currency.Euro, increase));

            newBalance.Amount.Should().Be(expectedAmount);
            newBalance.Currency.Should().Be(balance.Currency);
        }

        public void Immutibility()
        {
            var balance = new Balance(Currency.Euro, 123.45f);

            var balance2 = balance.IncreaseWith(new Money(Currency.Euro, 0));

            balance2.Should().NotBeSameAs(balance);
        }
    }
}