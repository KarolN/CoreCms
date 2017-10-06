using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Infrastructure;
using CoreCms.Cms.Model.Content;
using CoreCms.Cms.Modules.Images.Model;
using CoreCms.Cms.Modules.Images.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CoreCms.Cms.Modules.Images.RoutingProvider
{
    public class CmsImageRoutingHandler : ICmsRoutingHandler
    {
        private readonly IContentLoader _contentLoader;
        private readonly IImageLoader _imageLoader;

        public CmsImageRoutingHandler(IContentLoader contentLoader, IImageLoader imageLoader)
        {
            _contentLoader = contentLoader;
            _imageLoader = imageLoader;
        }
        
        public RequestDelegate GetRequestHandler(HttpContext httpContext, RouteData routeData)
        {
            var contentReference = routeData.Values[CoreConstants.ContentReferenceRouteDataKey] as ContentReference;
            var imageContent = _contentLoader.Load(contentReference) as Image;
            if (imageContent == null)
            {
                return null;
            }
            
            return async context =>
            {
                var imageStream = _imageLoader.GetImageStream(imageContent);
                context.Response.ContentType = imageContent.ImageType;
                await imageStream.CopyToAsync(context.Response.Body);
                imageStream.Dispose();
            };
        }
    }
}