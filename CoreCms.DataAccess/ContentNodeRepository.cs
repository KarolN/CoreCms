using CoreCms.Cms.Model.Content.ContentTree;
using CoreCms.DataAccess.Base;
using MongoDB.Driver;

namespace CoreCms.DataAccess
{
    public class ContentNodeRepository : MongoRepository<ContentNode>
    {
        public ContentNodeRepository(IMongoDatabase db) : base(db)
        {
        }
    }
}