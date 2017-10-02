using System;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Html;

namespace CoreCms.Cms.Core.DefaultContentRenderers
{
    public class IntegerContentRenerer : BaseContentRenderer
    {
        public override IHtmlContent Render<T>(T content, Func<T, object> renderProperty)
        {
            return new HtmlString(renderProperty(content).ToString());
        }

        public override Type SupportedType => typeof(int);
    }
}