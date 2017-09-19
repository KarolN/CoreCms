using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Infrastructure;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;

namespace CoreCms.Cms.Core.RouterProvider
{
    public class CmsRoutingHandler : ICmsRoutingHandler
    {
        private readonly List<ICmsModuleDescriptor> _moduleDescriptors;
        private readonly List<IControllerActionResolver> _actionResolvers;
        private readonly IActionInvokerFactory _actionInvoker;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public CmsRoutingHandler( List<ICmsModuleDescriptor> moduleDescriptors,
            List<IControllerActionResolver> actionResolvers, IActionInvokerFactory actionInvoker,
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _moduleDescriptors = moduleDescriptors;
            _actionResolvers = actionResolvers;
            _actionInvoker = actionInvoker;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public RequestDelegate GetRequestHandler(HttpContext httpContext, RouteData routeData)
        {
            var contentReference = routeData.Values[CoreConstants.ContentReferenceRouteDataKey] as ContentReference;
            if (contentReference == null)
            {
                return null;
            }
            var actionReslover = _actionResolvers.Single(x => x.GetContentTypeName() == contentReference.ContentType);
            if (actionReslover == null)
            {
                throw new Exception("Cms action resolver not found for content reference of type " + contentReference.ContentType);
            }
            var cmsActionDescriptor = actionReslover.ResolveControllerAction(contentReference);
            var mvcActionDescriptor = GetMvcActionDescriptor(cmsActionDescriptor);
            routeData.Values.Add("action", mvcActionDescriptor.RouteValues["action"]);
            routeData.Values.Add("controller", mvcActionDescriptor.RouteValues["controller"]);
            
            return async context =>
            {
                var actionContext = new ActionContext(context, routeData, mvcActionDescriptor);
                var invoker = _actionInvoker.CreateInvoker(actionContext);
                await invoker.InvokeAsync();
            };
        }

        private ActionDescriptor GetMvcActionDescriptor(CmsControllerActionDescriptor cmsDescriptor)
        {
            var mvcActionDescriptors = _actionDescriptorCollectionProvider.ActionDescriptors.Items
                .Select(x => x as ControllerActionDescriptor).Where(x => x != null);
            return mvcActionDescriptors.Single(x =>
                x.ActionName == "Index" && x.ControllerName == cmsDescriptor.ControllerName);
        }
    }
}