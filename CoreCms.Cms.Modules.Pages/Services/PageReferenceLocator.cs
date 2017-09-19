using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Model.Content;
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
            var contentRoot = _pageTreeRepository.GetQueryable().Single();
            var splitedPath = url.Split('/').Where(x => !string.IsNullOrEmpty(x));

            PageTreeNode currentNode = contentRoot;
            foreach (var part in splitedPath)
            {
                var matchChild = contentRoot.Children.SingleOrDefault(x => x.Name == part);
                if (matchChild == null)
                {
                    return null;
                }
                currentNode = matchChild;
            }
            if (currentNode == null)
            {
                return null;
            }
            var contentReference = new PageReference{Name = currentNode.Name, PageId = currentNode.PageId, PageType = currentNode.PageType};
            return contentReference;
        }
    }
}