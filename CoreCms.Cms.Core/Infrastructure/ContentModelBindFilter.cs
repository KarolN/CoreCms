using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class ContentModelBindFilter : IActionFilter
    {
        private readonly IContentLoader _contentLoader;

        public ContentModelBindFilter(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var contentReference = context.RouteData.Values["contentReference"] as ContentReference;
            if (contentReference != null)
            {
                var content = _contentLoader.Load(contentReference);
                context.ActionArguments["contentModel"] = content;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}