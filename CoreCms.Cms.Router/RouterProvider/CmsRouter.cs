using System.Threading.Tasks;
using CoreCms.Cms.ContentTreeHandler.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using StructureMap.Building;

namespace CoreCms.Cms.Router.RouterProvider
{
    public class CmsRouter : ICmsRouter
    {
        private readonly IContentTreeHandler _contentTreeHandler;

        public CmsRouter(IContentTreeHandler contentTreeHandler)
        {
            _contentTreeHandler = contentTreeHandler;
        }
        
        public async Task RouteAsync(RouteContext context)
        {
            context.Handler = async httpContext =>
                {
                   await httpContext.Response.WriteAsync("Hello on path:" + httpContext.Request.Path);
                };
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}