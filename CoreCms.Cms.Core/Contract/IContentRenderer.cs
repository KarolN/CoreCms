using System;
using System.Threading.Tasks;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCms.Cms.Core.Contract
{
    public interface IContentRenderer
    {
        bool CanRender<T>(T content,Func<T, object> renderProperty) where T : Content;
        Task<IHtmlContent> Render<T>(T content, Func<T, object> renderProperty, IHtmlHelper htmlHelper) where T : Content;
        Type SupportedType { get; }
    }
}