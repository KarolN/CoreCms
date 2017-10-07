using System;
using System.Reflection;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCms.Cms.Core.DefaultContentRenderers
{
    public abstract class BaseContentRenderer : IContentRenderer
    {
        public bool CanRender<T>(T content,Func<T, object> renderProperty) where T : Content
        {
            var property = renderProperty(content);
            return SupportedType.IsAssignableFrom(property?.GetType());
        }

        public abstract Task<IHtmlContent> Render<T>(T content, Func<T, object> renderProperty, IHtmlHelper htmlHelper) where T : Content;

        public abstract Type SupportedType { get; }
    }
}