using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Modules.Pages.DataAccess;
using CoreCms.Cms.Modules.Pages.Model;

namespace CoreCms.Cms.Modules.Pages.Services
{
    public class PageContentProvider : BasePageService, IContentProvider
    {
        private readonly IPageRepository _pageRepository;
        private readonly IPageTreeRepository _pageTreeRepository;

        public PageContentProvider(IPageRepository pageRepository, IPageTreeRepository pageTreeRepository)
        {
            _pageRepository = pageRepository;
            _pageTreeRepository = pageTreeRepository;
        }
        
        public Content GetContent(ContentReference contentReference)
        {
            var pageReference = contentReference as PageReference;
            if (pageReference == null)
            {
                throw new ArgumentException("Incorrect content reference");
            }

            var page = _pageRepository.GetQueryable().SingleOrDefault(x => x.Id == pageReference.ContentId);
            return page;
        }

        public void UpdateContent(Content content)
        {
            _pageRepository.Update(content as Page);
            var pageTreeContent = _pageTreeRepository.GetQueryable().Single(x => x.PageId == content.Id);
            pageTreeContent.Name = content.Name;
            _pageTreeRepository.Update(pageTreeContent);
        }

        public Content SaveContent(Content content, Guid parent)
        {
            var pageContent = content as Page;
            if (pageContent == null)
            {
                throw new ArgumentException("Content to save is not page content");
            }

            var parentPage = _pageRepository.GetQueryable().SingleOrDefault(x => x.Id == parent);
            if (parentPage == null)
            {
                throw new ArgumentException($"Parent with id {parent} not found");
            }

            var parentTreeElement = _pageTreeRepository.GetQueryable().Single(x => x.PageId == parent);

            var id = _pageRepository.Insert(pageContent);
            content.Id = id;
            
            var newPageTreeElement = new PageTreeNode()
            {
                PageId = id,
                Name = content.Name,
                ParentId = parentTreeElement.Id,
                PageType = content.GetType().Name
            };
            _pageTreeRepository.Insert(newPageTreeElement);

            return content;
        }
    }
}