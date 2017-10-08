using System;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract.Model.Content;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IContentRenderer
    {
        bool CanRender<T>(T content,Func<T, object> renderProperty) where T : Content;
        Task<IHtmlContent> Render<T>(T content, Func<T, object> renderProperty, IHtmlHelper htmlHelper) where T : Content;
        Type SupportedType { get; }
    }
}