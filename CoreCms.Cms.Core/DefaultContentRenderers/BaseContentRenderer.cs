using System;
using System.Reflection;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCms.Cms.Core.DefaultContentRenderers
{
    public abstract class BaseContentRenderer : IContentRenderer
    {
        public bool CanRender(object renderProperty)
        {
            return SupportedType.IsAssignableFrom(renderProperty?.GetType());
        }

        public abstract Task<IHtmlContent> Render(object renderProperty, ViewContext viewContext);

        public abstract Type SupportedType { get; }
    }
}