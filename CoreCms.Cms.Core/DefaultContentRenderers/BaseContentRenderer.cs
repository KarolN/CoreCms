using System;
using System.Reflection;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Html;

namespace CoreCms.Cms.Core.DefaultContentRenderers
{
    public abstract class BaseContentRenderer : IContentRenderer
    {
        public bool CanRender<T>(Func<T, object> renderProperty) where T : Content
        {
            return renderProperty.GetMethodInfo().GetParameters()[0].ParameterType == SupportedType;
        }

        public abstract IHtmlContent Render<T>(T content, Func<T, object> renderProperty) where T : Content;

        public abstract Type SupportedType { get; }
    }
}