using SimpleBankApplication.Domain;
using Xunit;
using FluentAssertions;
using System;

namespace SimpleBankApplication.DomainTests.UnitTests
{
    public class AccountTests
    {
        private Account _account;

        public AccountTests()
        {
            _account = new Account(new AccountNumber("1"));
        }

        [Fact]
        public void Deposit_EmptyAccount_BalanceIsEqualToDeposit()
        {
            var moneyToDeposit = new Money(Currency.Euro, 10.0f);

            _account.Deposit(moneyToDeposit);

            _account.Balance.Amount.Should().Be(moneyToDeposit.Amount);
        }

        [Fact]
        public void Withdraw_EmptyAccount_WithdrawNotPossibleDueCreditLimitation()
        {
            var moneyToWithdraw = new Money(Currency.Euro, 10);

            Action action = () =>_account.Withdraw(moneyToWithdraw);

            action.ShouldThrow<Exception>();
            _account.Balance.Amount.Should().Be(0);
        }

        [Fact]
        public void Withdraw_AccountWithMoreMoneyThanToWithdraw_BalanceWillBeDecreased()
        {
            _account = new Account(new AccountNumber("1"), new []
                                {
                                    new DepositApplied(new Money(Currency.Euro, 100)),
                                    new DepositApplied(new Money(Currency.Euro, 20))
                                });
            _account.Withdraw(new Money(Currency.Euro, 80));

            _account.Balance.Amount.Should().Be(40);
        }
    }
}