using NUnit.Framework;
using NSubstitute;
using Transactions.Domain.Repository;
using Transactions.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Transactions.Domain.Services;

namespace Transactions.Tests.Service
{
    public class TransactionServiceTestx
    {
        IAccountTransactionRepository Repository;
        AccountTransactionService Service;

        List<AccountTransaction> LocalData = new List<AccountTransaction>();
        private AccountTransaction ExistingTransaction;
        private string InexistentTransactionId;

        [OneTimeSetUp]
        public void Setup()
        {
            InexistentTransactionId = Guid.NewGuid().ToString().Replace("-", "");
            ExistingTransaction = new AccountTransaction(Guid.NewGuid().ToString().Replace("-", string.Empty), 50, "505050", DateTime.Now);

            Repository = Substitute.For<IAccountTransactionRepository>();

            Repository.Insert(Arg.Any<AccountTransaction>()).Returns(Task.FromResult(ExistingTransaction));
            Repository.Delete(Arg.Any<string>()).Returns(Task.CompletedTask);
            Repository.GetById(Arg.Is(ExistingTransaction.Id)).Returns(ExistingTransaction);
            Repository.GetById(Arg.Is(InexistentTransactionId)).Returns(Task.FromResult(new AccountTransaction("", 0, "", DateTime.MinValue)));

            Service = new AccountTransactionService(Repository);
        }

        [Test]
        public async Task ShouldInsertCreditTransaction()
        {
            var accountTransaction = await Service.SaveCreditTransaction(500, "a4567810123");

            Assert.IsNotNull(accountTransaction);
            Assert.AreNotEqual("", accountTransaction.Id);
        }

        [Test]
        public async Task ShouldInsertDebitTransaction()
        {
            var accountTransaction = await Service.SaveDebitTransaction(500, "a4567810123", "test");

            Assert.IsNotNull(accountTransaction);
            Assert.AreNotEqual("", accountTransaction.Id);
        }

        [Test]
        public async Task ShouldGetTransactionById()
        {
            var id = ExistingTransaction.Id;

            var accountTransaction = await Service.GetById(ExistingTransaction.Id);

            Assert.AreEqual(accountTransaction.Id, id);
        }

        [Test]
        public async Task ShouldNotGetTransactionById()
        {
            var id = ExistingTransaction.Id;

            var accountTransaction = await Repository.GetById(InexistentTransactionId);

            Assert.AreNotEqual(accountTransaction.Id, id);
        }
    }
}