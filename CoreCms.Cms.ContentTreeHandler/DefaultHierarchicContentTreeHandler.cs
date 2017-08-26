using System;
using System.Linq;
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
        
        public ContentNode GetContentNodeForUrl(string path)
        {
            var contentRoot = _contentNodeRepository.GetQueryable().Single();
            var splitedPath = path.Split('/').Where(x => !string.IsNullOrEmpty(x));

            ContentNode currentNode = contentRoot;
            foreach (var part in splitedPath)
            {
                var matchChild = contentRoot.ChildNodes.SingleOrDefault(x => x.Name == part);
                if (matchChild == null)
                {
                    return null;
                }
                currentNode = matchChild;
            }
            return currentNode;
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