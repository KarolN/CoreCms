using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Model.Infractructure;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Core.Infrastructure;
using CoreCms.Cms.Modules.Pages.Model;

namespace CoreCms.Cms.Modules.Pages.Services
{
    public class PageActionResolver : BasePageService, IControllerActionResolver
    {
        private readonly ICmsControllerActionDescriptorsProvider _actionDescriptorsProvider;

        public PageActionResolver(ICmsControllerActionDescriptorsProvider actionDescriptorsProvider)
        {
            _actionDescriptorsProvider = actionDescriptorsProvider;
        }
        
        public CmsControllerActionDescriptor ResolveControllerAction(ContentReference contentReference)
        {
            var pageReference = contentReference as PageReference;
            if (contentReference.ContentType != PageConstants.ContentType || pageReference == null)
            {
                return null;
            }

            var descriptors = _actionDescriptorsProvider.GetDescriptors();
            return descriptors.FirstOrDefault(x => x.ModelType.Name == pageReference.PageType);
        }
    }
}