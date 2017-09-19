using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Infrastructure;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;

namespace CoreCms.Cms.Core.RouterProvider
{
    public class CmsRouter : ICmsRouter
    {
        private readonly List<IContentReferenceLocator> _referenceLocators;
        private readonly ICmsRoutingHandler _routingHandler;

        public CmsRouter(List<IContentReferenceLocator> referenceLocators, ICmsRoutingHandler routingHandler)
        {
            _referenceLocators = referenceLocators;
            _routingHandler = routingHandler;
        }
        public async Task RouteAsync(RouteContext context)
        {
            var contentReference = GetContentReference(context.HttpContext.Request.Path);
            if (contentReference == null)
            {
                return;
            }
            context.RouteData.Values.Add(CoreConstants.ContentReferenceRouteDataKey, contentReference);
            var requestHandler = _routingHandler.GetRequestHandler(context.HttpContext, context.RouteData);
            if (requestHandler != null)
            {
                context.Handler = requestHandler;
            }
        }
        

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            var virtualPathData = new VirtualPathData(this, "");
            return virtualPathData;
        }

        private ContentReference GetContentReference(string path)
        {
            ContentReference contentReference = null;

            foreach (var referenceLocator in _referenceLocators)
            {
                contentReference = referenceLocator.LocateFromUrl(path);
                if (contentReference != null)
                    break;
            }
            
            return contentReference;
        }
    }
}