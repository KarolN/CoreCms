using System;
using CoreCms.Cms.ContentTreeHandler.Contract;
using CoreCms.Cms.Model.Content.ContentTree;
using CoreCms.DataAccess.Contract;

namespace CoreCms.Cms.ContentTreeHandler
{
    public class DefaultHierarchicContentTreeHandler : IContentTreeHandler
    {
        private readonly IRepository<ContentNode> _contentNodeRepository;

        public DefaultHierarchicContentTreeHandler(IRepository<ContentNode> contentNodeRepository)
        {
            _contentNodeRepository = contentNodeRepository;
        }
        
        public ContentNode GetContentNodeForUrl(string url)
        {
            throw new NotImplementedException();
        }

        public string ResolveContentUrl(Guid contentNodeId)
        {
            throw new NotImplementedException();
        }

        public void AddContentNode(Guid parentId, ContentNode newNode)
        {
            throw new NotImplementedException();
        }
    }
}