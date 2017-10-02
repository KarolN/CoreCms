﻿using System;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace CoreCms.Cms.Core.HtmlExtensions
{
    public static class RenderingExtensions
    {
        public static IHtmlContent Render<T>(this IHtmlHelper htmlHelper, T content,Func<T, object> renderProperty) where T : Content
        {
            var renderingManager = htmlHelper.ViewContext.HttpContext.RequestServices.GetService<IRenderingManager>();

            return renderingManager.Render(htmlHelper, content, renderProperty);
        }
    }
}