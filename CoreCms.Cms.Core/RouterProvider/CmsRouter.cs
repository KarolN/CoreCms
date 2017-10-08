using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;

namespace CoreCms.Cms.Core.RouterProvider
{
    public class CmsRouter : ICmsRouter
    {
        private readonly List<IContentReferenceLocator> _referenceLocators;
        private readonly Dictionary<Type,ICmsRoutingHandler> _routingHandlers;
        private readonly List<ICmsModuleDescriptor> _moduleDescriptors;

        public CmsRouter(List<IContentReferenceLocator> referenceLocators, List<ICmsRoutingHandler> routingHandlers,
                List<ICmsModuleDescriptor> moduleDescriptors)
        {
            _referenceLocators = referenceLocators;
            _moduleDescriptors = moduleDescriptors;
            _routingHandlers = routingHandlers.ToDictionary(x => x.GetType(), x => x);
        }
        public async Task RouteAsync(RouteContext context)
        {
            var contentReference = GetContentReference(context.HttpContext.Request.Path);
            if (contentReference == null)
            {
                return;
            }
            context.RouteData.Values.Add(CoreConstants.ContentReferenceRouteDataKey, contentReference);
            
            var contentModuleDescriptor =
                _moduleDescriptors.Single(x => x.GetModuleName() == contentReference.ContentType);
            var routingHandler =
                _routingHandlers[contentModuleDescriptor.GetRoutingHandlerType()];
            var requestHandler = routingHandler.GetRequestHandler(context.HttpContext, context.RouteData);
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