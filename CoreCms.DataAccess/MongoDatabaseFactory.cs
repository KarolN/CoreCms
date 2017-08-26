using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CoreCms.DataAccess
{
    public class MongoDatabaseFactory
    {
        public static IMongoDatabase GetDatabase(IConfigurationRoot configuration)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("test");
            return db;
        }
    }
}