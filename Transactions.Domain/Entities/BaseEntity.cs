using System;

namespace Transactions.Domain.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; protected set; }

        protected void GenerateId()
        {
            Id = Guid.NewGuid().ToString().Replace("-", string.Empty);
        }
    }
}