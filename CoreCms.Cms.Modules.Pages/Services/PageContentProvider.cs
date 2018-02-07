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
    }
}