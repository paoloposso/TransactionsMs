using System.Collections.Generic;
using System.Threading.Tasks;
using Transactions.UseCases.Entities;

namespace Transactions.UseCases.Repository
{
    public interface IAccountTransactionRepository
    {
         Task<AccountTransaction> Insert(AccountTransaction accountTransaction);
         Task Delete(string id);
         Task<AccountTransaction> GetById(string id);
         Task<IList<AccountTransaction>> GetByAccountId(string accountId);
    }
}