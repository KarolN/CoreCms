using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.RouterProvider;
using StructureMap;

namespace CoreCms.Cms.Core
{
    public class RouterServicesRegistry : Registry
    {
        public RouterServicesRegistry()
        {
            For<ICmsRouter>().Singleton().Use<CmsRouter>();
            For<ICmsRoutingHandler>().Use<CmsDefaultRoutingHandler>().Named("CmsDefaultRoutingHandler");
        }
    }
}