using NUnit.Framework;
using NSubstitute;
using Transactions.Domain.Repository;
using Transactions.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Transactions.Tests.Repository
{
    public class TransactionRepositoryTest
    {
        IAccountTransactionRepository Repository;

        List<AccountTransaction> LocalData = new List<AccountTransaction>();
        private AccountTransaction InsertedTransaction;

        [SetUp]
        public void Setup()
        {
            InsertedTransaction = new AccountTransaction(Guid.NewGuid().ToString().Replace("-", string.Empty), 50, "505050", DateTime.Now);

            Repository = Substitute.For<IAccountTransactionRepository>();
            Repository.Insert(Arg.Any<AccountTransaction>()).Returns(Task.FromResult(InsertedTransaction));
            Repository.Delete(Arg.Any<string>()).Returns(Task.CompletedTask);
            Repository.GetById(Arg.Any<string>()).Returns(InsertedTransaction);
        }

        [Test]
        public async Task ShouldDeleteTransaction()
        {
            await Repository.Delete("a56s7d8dddps0");

            Assert.Pass();
        }

        [Test]
        public async Task ShouldInsertTransaction()
        {
            await Repository.Insert(InsertedTransaction);

            Assert.Pass();
        }

        [Test]
        public async Task ShouldGetTransactionById()
        {
            var id = InsertedTransaction.Id;

            var accountTransaction = await Repository.GetById(id);

            Assert.AreEqual(accountTransaction.Id, id);
        }
    }
}