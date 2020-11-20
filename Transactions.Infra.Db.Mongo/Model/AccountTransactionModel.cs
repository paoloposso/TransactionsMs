using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Transactions.Infra.Db.Mongo.Model
{
    public class AccountTransactionModel
    {
        [BsonId]
        public string Id { get; set; }
        public double Value { get; set; }
        public DateTime Created { get; set; }
        public string AccountId { get; set; }
        public string Description { get; set; }
    }
}