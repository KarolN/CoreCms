using System;
using System.Threading.Tasks;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreCms.Cms.Core.DefaultContentRenderers
{
    public class IntegerContentRenerer : BaseContentRenderer
    {
        public override async Task<IHtmlContent> Render<T>(T content, Func<T, object> renderProperty, IHtmlHelper htmlHelper)
        {
            return new HtmlString(renderProperty(content).ToString());
        }

        public override Type SupportedType => typeof(int);
    }
}