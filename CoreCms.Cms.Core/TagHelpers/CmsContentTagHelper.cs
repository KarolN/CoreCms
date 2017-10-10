using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace CoreCms.Cms.Core.TagHelpers
{
    public class CmsContentTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        
        [HtmlAttributeName("content")]
        public object Content { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (Content == null)
            {
                return;
            }
            var renderingManager = ViewContext.HttpContext.RequestServices.GetService<IRenderingManager>();
            var rendered = await renderingManager.Render(ViewContext, Content);
            output.Content.AppendHtml(rendered);
        }
    }
}