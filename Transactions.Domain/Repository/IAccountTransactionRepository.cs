using System.Collections.Generic;
using System.Threading.Tasks;
using Transactions.Domain.Entities;

namespace Transactions.Domain.Repository
{
    public interface IAccountTransactionRepository
    {
         Task Insert(AccountTransaction accountTransaction);
         Task Delete(string id);
         Task<AccountTransaction> GetById(string id);
         Task<IList<AccountTransaction>> GetByAccountId(string accountId);
    }
}