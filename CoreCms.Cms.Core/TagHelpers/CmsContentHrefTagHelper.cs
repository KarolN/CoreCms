using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace CoreCms.Cms.Core.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "cms-content-href")]
    public class CmsContentHrefTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        [HtmlAttributeName("cms-content-href")]
        public ContentReference ContentReference { get; set; }
        
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var urlGenerator = ViewContext.HttpContext.RequestServices.GetService<IContentUrlGenerator>();
            if (ContentReference == null)
            {
                return;
            }
            var url = urlGenerator.GetUrl(ContentReference);
            output.Attributes.Add("href", url);
        }
    }
}