using System;
using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Modules.Pages.DataAccess;
using CoreCms.Cms.Modules.Pages.Model;

namespace CoreCms.Cms.Modules.Pages.Services
{
    public class PageUrlProvider : BasePageService, IContentUrlProvider
    {
        private readonly IPageTreeRepository _pageTreeRepository;

        public PageUrlProvider(IPageTreeRepository pageTreeRepository)
        {
            _pageTreeRepository = pageTreeRepository;
        }
        public string GetContentUrl(ContentReference contentReference)
        {
            var pageReference = (PageReference) contentReference;

            var pageNodes = _pageTreeRepository.GetQueryable().ToList();
            var referencedNode = pageNodes.Single(x => x.PageId == pageReference.PageId);

            var currentNode = referencedNode;
            var hierarchy = new List<PageTreeNode>();
            while (currentNode.ParentId != Guid.Empty)
            {
                hierarchy.Add(currentNode);
                currentNode = pageNodes.Single(x => x.Id == currentNode.ParentId);
            }

            hierarchy.Reverse();
            
            return "/" + string.Join("/", hierarchy.Select(x => x.Name));
        }
    }
}