using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Transactions.Domain.Entities;
using Transactions.Domain.Repository;
using Transactions.Infra.Db.Mongo.Model;

namespace Transactions.Infra.Db.Mongo
{
    public class AccountTransactionRepository : MongoRepositoryBase, IAccountTransactionRepository
    {
        private readonly IMongoCollection<AccountTransactionModel> _transactions;

        public AccountTransactionRepository(IConfiguration configuration) : base(configuration) 
        {
            _transactions = database.GetCollection<AccountTransactionModel>("accountTransactions");
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AccountTransaction>> GetByAccountId(string accountId)
        {
            throw new NotImplementedException();
        }

        public Task<AccountTransaction> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountTransaction> Insert(AccountTransaction accountTransaction)
        {
            AccountTransactionModel model = new AccountTransactionModel()
            {
                Id = accountTransaction.Id,
                Created = accountTransaction.Created,
                AccountId = accountTransaction.AccountId,
                Description = accountTransaction.Description,
                Value = accountTransaction.Value
            };

            await _transactions.InsertOneAsync(model);

            return accountTransaction;
        }
    }
}
