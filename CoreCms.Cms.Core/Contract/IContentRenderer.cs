using System;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Html;

namespace CoreCms.Cms.Core.Contract
{
    public interface IContentRenderer
    {
        bool CanRender<T>(Func<T, object> renderProperty) where T : Content;
        IHtmlContent Render<T>(T content, Func<T, object> renderProperty) where T : Content;
        Type SupportedType { get; }
    }
}