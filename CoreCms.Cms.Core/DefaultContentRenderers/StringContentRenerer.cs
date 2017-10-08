﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCms.Cms.Core.DefaultContentRenderers
{
    public class StringContentRenerer : BaseContentRenderer
    {
        public override async Task<IHtmlContent> Render<T>(T content, Func<T, object> renderProperty, IHtmlHelper htmlHelper)
        {
            return new HtmlString(renderProperty(content).ToString());
        }

        public override Type SupportedType => typeof(String);
    }
}