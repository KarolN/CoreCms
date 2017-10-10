using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCms.Cms.Core.DefaultContentRenderers
{
    public class StringContentRenerer : BaseContentRenderer
    {
        public override async Task<IHtmlContent> Render(object renderProperty, ViewContext viewContext)
        {
            return new HtmlString(renderProperty.ToString());
        }

        public override Type SupportedType => typeof(String);
    }
}