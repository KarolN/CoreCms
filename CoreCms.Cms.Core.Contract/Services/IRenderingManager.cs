using System;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract.Model.Content;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IRenderingManager
    {
        Task<IHtmlContent> Render<T>(IHtmlHelper helper, T content, Func<T, object> renderProperty) where T : Content;
    }
}