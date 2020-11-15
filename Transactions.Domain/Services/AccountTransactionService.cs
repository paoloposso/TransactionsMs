using System.Threading.Tasks;
using Transactions.Domain.Entities;
using Transactions.Domain.Repository;

namespace Transactions.Domain.Services
{
    public class AccountTransactionService
    {
        IAccountTransactionRepository AccountTransactionRepository;

        public AccountTransactionService(IAccountTransactionRepository accountTransactionRepository)
        {
            AccountTransactionRepository = accountTransactionRepository;
        }

        public async Task Save(double value, string accountId)
        {
            var transaction = new AccountTransaction(value, accountId);

            await AccountTransactionRepository.Insert(transaction);
        }

        public async Task<AccountTransaction> GetById(string accountId)
        {
            return await AccountTransactionRepository.GetById(accountId);
        }
    }
}