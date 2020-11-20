using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Transactions.Infra.Db.Mongo
{
    public abstract class MongoRepositoryBase
    {
        protected IMongoDatabase database;
        protected string collection { get; set; }

        public MongoRepositoryBase(IConfiguration configuration)
        {
            database = new MongoClient(configuration["MONGODB_URI"]).GetDatabase("transactions");
        }
    }
}