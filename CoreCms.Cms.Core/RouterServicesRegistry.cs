using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.RouterProvider;
using StructureMap;

namespace CoreCms.Cms.Core
{
    public class RouterServicesRegistry : Registry
    {
        public RouterServicesRegistry()
        {
            For<ICmsRouter>().Use<CmsRouter>();
            For<ICmsRoutingHandler>().Use<CmsRoutingHandler>();
        }
    }
}