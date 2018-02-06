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

        public PageContentProvider(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
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
    }
}