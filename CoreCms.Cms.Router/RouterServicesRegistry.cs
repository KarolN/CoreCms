using CoreCms.Cms.Router.RouterProvider;
using StructureMap;

namespace CoreCms.Cms.Router
{
    public class RouterServicesRegistry : Registry
    {
        public RouterServicesRegistry()
        {
            For<ICmsRouter>().Use<CmsRouter>();
        }
    }
}