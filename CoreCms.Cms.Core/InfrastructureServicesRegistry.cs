using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.DefaultContentRenderers;
using CoreCms.Cms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using StructureMap;

namespace CoreCms.Cms.Core
{
    public class InfrastructureServicesRegistry : Registry
    {
        public InfrastructureServicesRegistry()
        {
            For<ICmsControllerActionDescriptorsProvider>().Use<CmsControllerActionDescriptorsProvider>();
            For<IContentLoader>().Use<ContentLoader>();
            For<IRenderingManager>().Singleton().Use<DefaultContentRenderingManager>();

            For<IContentRenderer>().Singleton().Use<IntegerContentRenerer>();
            For<IContentRenderer>().Singleton().Use<StringContentRenerer>();
        }
    }
}