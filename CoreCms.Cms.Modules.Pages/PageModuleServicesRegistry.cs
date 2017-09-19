using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Modules.Pages.DataAccess;
using CoreCms.Cms.Modules.Pages.Services;
using StructureMap;

namespace CoreCms.Cms.Modules.Pages
{
    public class PageModuleServicesRegistry : Registry
    {
        public PageModuleServicesRegistry()
        {
            For<IContentReferenceLocator>().Use<PageReferenceLocator>().Named(PageConstants.ContentType);
            For<IPageTreeRepository>().Use<PageTreeRepository>().Named(PageConstants.ContentType);
            For<ICmsModuleDescriptor>().Use<PageModuleDescriptor>().Named(PageConstants.ContentType);
            For<IControllerActionResolver>().Use<PageActionResolver>().Named(PageConstants.ContentType);
        }
    }
}