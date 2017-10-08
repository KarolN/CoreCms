using System;
using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Modules.Pages.DataAccess;
using CoreCms.Cms.Modules.Pages.Model;

namespace CoreCms.Cms.Modules.Pages.Services
{
    public class PageReferenceLocator : BasePageService, IContentReferenceLocator
    {
        private readonly IPageTreeRepository _pageTreeRepository;

        public PageReferenceLocator(IPageTreeRepository pageTreeRepository)
        {
            _pageTreeRepository = pageTreeRepository;
        }
        
        public ContentReference LocateFromUrl(string url)
        {
            var nodes = _pageTreeRepository.GetQueryable().ToList();
            var rootNode = nodes.Single(x => x.ParentId == Guid.Empty);

            var fragmentedUrl = url.Split('/').Where(x => !string.IsNullOrEmpty(x));

            var currentNode = rootNode;
            foreach (var fragment in fragmentedUrl)
            {
                var children = nodes.Where(x => x.ParentId == currentNode.Id);
                var match = children.SingleOrDefault(x => x.Name == fragment);

                currentNode = match;
                if (match == null)
                {
                    break;
                }
            }
            if (currentNode == null)
            {
                return null;
            }
            return new PageReference(){Name = currentNode.Name, PageId = currentNode.PageId, PageType = currentNode.PageType};
        }
    }
}