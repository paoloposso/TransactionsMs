using System;

namespace Transactions.Domain.Entities
{
    public class AccountTransaction : BaseEntity
    {
        public double Value { get; private set; }
        public DateTime Created { get; private set; }
        public string AccountId { get; private set; }

        public AccountTransaction(double value, string accountId)
        {
            GenerateId();
            Created = DateTime.Now;
            Value = value;
            AccountId = accountId;
        }

        public AccountTransaction(string id, double value, string accountId, DateTime created)
        {
            Id = id;
            Value = value;
            AccountId = accountId;
            Created = created;
        }
    }
}