using CoreCms.Cms.Modules.Pages.Model;
using CoreCms.DataAccess.Base;
using MongoDB.Driver;

namespace CoreCms.Cms.Modules.Pages.DataAccess
{
    public class PageTreeRepository : MongoRepository<PageTreeNode>, IPageTreeRepository
    {
        public PageTreeRepository(IMongoDatabase db) : base(db)
        {
        }
    }
}