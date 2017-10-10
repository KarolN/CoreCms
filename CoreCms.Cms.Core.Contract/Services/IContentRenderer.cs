using System;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract.Model.Content;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IContentRenderer
    {
        bool CanRender(object renderProperty);
        Task<IHtmlContent> Render(object renderProperty, ViewContext viewContext);
        Type SupportedType { get; }
    }
}