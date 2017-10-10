using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCms.Cms.Core.DefaultContentRenderers
{
    public class IntegerContentRenerer : BaseContentRenderer
    {
        public override async Task<IHtmlContent> Render(object renderProperty, ViewContext vc)
        {
            return new HtmlString(renderProperty.ToString());
        }

        public override Type SupportedType => typeof(int);
    }
}