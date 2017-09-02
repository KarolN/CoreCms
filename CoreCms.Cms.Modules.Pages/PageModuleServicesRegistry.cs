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
            For<IContentReferenceLocator>().Use<PageReferenceLocator>();
            For<IPageTreeRepository>().Use<PageTreeRepository>();
        }
    }
}