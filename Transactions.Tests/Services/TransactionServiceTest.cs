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
    public class TransactionServiceTest
    {
        IAccountTransactionRepository Repository;
        AccountTransactionService Service;

        List<AccountTransaction> LocalData = new List<AccountTransaction>();
        private AccountTransaction InsertedTransaction;

        [OneTimeSetUp]
        public void Setup()
        {
            InsertedTransaction = new AccountTransaction(Guid.NewGuid().ToString().Replace("-", string.Empty), 50, "505050", DateTime.Now);

            Repository = Substitute.For<IAccountTransactionRepository>();
            Repository.Insert(Arg.Any<AccountTransaction>()).Returns(Task.FromResult(InsertedTransaction));
            Repository.Delete(Arg.Any<string>()).Returns(Task.CompletedTask);

            Repository.GetById(Arg.Is(InsertedTransaction.Id)).Returns(InsertedTransaction);

            Service = new AccountTransactionService(Repository);
        }

        [Test]
        public async Task ShouldGetTransactionById()
        {
            var id = InsertedTransaction.Id;

            var accountTransaction = await Service.GetById(InsertedTransaction.Id);

            Assert.AreEqual(accountTransaction.Id, id);
        }

        [Test]
        public async Task ShouldInsertTransaction()
        {
            var id = InsertedTransaction.Id;

            await Service.Save(500, "a4567810123");

            Assert.Pass();
        }

        // [Test]
        // public async Task ShouldNotGetTransactionById()
        // {
        //     var id = InsertedTransaction.Id;

        //     var accountTransaction = await Repository.GetById("dfdfsd");

        //     Assert.AreNotEqual(accountTransaction.Id, id);
        // }
    }
}