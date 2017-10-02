using System;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CoreCms.Cms.Core.Contract
{
    public interface IRenderingManager
    {
        IHtmlContent Render<T>(IHtmlHelper helper, T content, Func<T, object> renderProperty) where T : Content;
    }
}