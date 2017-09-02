using System.Linq;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;

namespace CoreCms.Cms.Router.RouterProvider
{
    public class CmsRouter : ICmsRouter
    {
        private readonly IContentReferenceLocator _contentReferenceLocator;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly IActionInvokerFactory _actionInvokerFactory;

        public CmsRouter(IContentReferenceLocator contentReferenceLocator, 
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
            IActionInvokerFactory actionInvokerFactory)
        {
            _contentReferenceLocator = contentReferenceLocator;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _actionInvokerFactory = actionInvokerFactory;
        }
        public async Task RouteAsync(RouteContext context)
        {
            var contentNode = _contentReferenceLocator.LocateFromUrl(context.HttpContext.Request.Path);
            
            var actionDescriptior = _actionDescriptorCollectionProvider.ActionDescriptors.Items.FirstOrDefault();
            
            context.Handler = async httpContext =>
            {
                var routeData = httpContext.GetRouteData();
                routeData.Values.Add("action", actionDescriptior.RouteValues["action"]);
                routeData.Values.Add("controller", actionDescriptior.RouteValues["controller"]);
                var actionContext =
                    new ActionContext(context.HttpContext, routeData, actionDescriptior);

                var invoker = _actionInvokerFactory.CreateInvoker(actionContext);

                await invoker.InvokeAsync();
            };
        }
        

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            var virtualPathData = new VirtualPathData(this, "");
            return virtualPathData;
        }
    }
}