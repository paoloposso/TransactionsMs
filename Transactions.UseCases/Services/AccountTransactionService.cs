using System.Threading.Tasks;
using Transactions.UseCases.Entities;
using Transactions.UseCases.Repository;

namespace Transactions.UseCases.Services
{
    public class AccountTransactionService
    {
        IAccountTransactionRepository AccountTransactionRepository;

        public AccountTransactionService(IAccountTransactionRepository accountTransactionRepository)
        {
            AccountTransactionRepository = accountTransactionRepository;
        }

        public async Task<AccountTransaction> Save(double value, string accountId)
        {
            var transaction = GenerateNewTransaction(value, accountId);

            return await AccountTransactionRepository.Insert(transaction);
        }

        public async Task<AccountTransaction> GetById(string accountId)
        {
            return await AccountTransactionRepository.GetById(accountId);
        }

        private AccountTransaction GenerateNewTransaction(double value, string accountId)
        {
            return new AccountTransaction(value, accountId);
        }
    }
}