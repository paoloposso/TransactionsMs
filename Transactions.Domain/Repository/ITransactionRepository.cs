using System.Collections.Generic;
using System.Threading.Tasks;
using Transactions.Domain.Entities;

namespace Transactions.Domain.Repository
{
    public interface ITransactionRepository
    {
         Task Insert();
         Task Delete();
         Task<AccountTransaction> GetById();
         Task<IList<AccountTransaction>> GetByAccountId();
    }
}