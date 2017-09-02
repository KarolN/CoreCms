using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using StructureMap;

namespace CoreCms.DataAccess
{
    public class DataAccessServicesRegistry : Registry
    {
        public DataAccessServicesRegistry()
        {
            For<IMongoDatabase>().Use(ctx => MongoDatabaseFactory.GetDatabase(ctx.GetInstance<IConfigurationRoot>()));
        }
    }
}