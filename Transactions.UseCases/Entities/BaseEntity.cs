using System;

namespace Transactions.UseCases.Entities
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