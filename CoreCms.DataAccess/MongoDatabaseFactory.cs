using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CoreCms.DataAccess
{
    public class MongoDatabaseFactory
    {
        public static IMongoDatabase GetDatabase(IConfigurationRoot configuration)
        {
            var mongoConnectionString = configuration["CoreCms:Core:MongoConnectionString"];
            var client = new MongoClient(mongoConnectionString);
            var databaseName = configuration["CoreCms:Core:CmsDatabase"];
            var db = client.GetDatabase(databaseName);
            return db;
        }
    }
}