using CoreCms.Cms.Modules.Pages.Model;
using CoreCms.DataAccess.Base;
using MongoDB.Driver;

namespace CoreCms.Cms.Modules.Pages.DataAccess
{
    public class PageRepository : MongoRepository<Page>, IPageRepository 
    {
        public PageRepository(IMongoDatabase db) : base(db)
        {
        }
    }
}