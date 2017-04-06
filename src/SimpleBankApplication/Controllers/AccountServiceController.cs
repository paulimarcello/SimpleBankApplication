using System;
using Microsoft.AspNetCore.Mvc;
using SimpleBankApplication.Persistence;
using SimpleBankApplication.Domain;

namespace SimpleBankApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/AccountService/[action]")]
    public class AccountServiceController : Controller
    {
        private AccountRepository _accountRepository;

        public AccountServiceController()
        {
            _accountRepository = new AccountRepository();
        }

        [HttpPost(Name = "Deposit")]
        public JsonResult Deposit([FromBody] Transaction value)
        {
            var account = _accountRepository.GetByAccountNumber(value.FromAccount);

            var money = CreateMoneyFrom(value.Currency, value.Amount);

            account.Deposit(money);

            return Json(account);
        }

        [HttpPost(Name = "Withdraw")]
        public void Withdraw([FromBody] Transaction value)
        {
            var account = _accountRepository.GetByAccountNumber(value.FromAccount);

            var money = CreateMoneyFrom(value.Currency, value.Amount);

            account.Withdraw(money);
        }

        [HttpPost(Name = "Transfer")]
        public void Transfer([FromBody] TransferTransaction value)
        {
        }


        private Money CreateMoneyFrom(string currency, float amount)
        {
            if (currency == "EUR")
                return new Money(Currency.Euro, amount);

            throw new NotImplementedException();
        }


        public class Transaction
        {
            public string FromAccount { get; set; }
            public string Currency { get; set; }
            public float Amount { get; set; }
        }

        public class TransferTransaction
        {
            public string FromAccount { get; set; }
            public string ToAccount { get; set; }
            public string Currency { get; set; }
            public float Amount { get; set; }
        }
    }
}