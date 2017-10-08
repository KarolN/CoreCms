using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Modules.Images.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.SampleSite.Components
{
    [ViewComponent]
    public class ImageViewComponent : CmsViewComponent<Image>
    {
        private readonly IContentUrlGenerator _urlGenerator;

        public ImageViewComponent(IContentUrlGenerator urlGenerator)
        {
            _urlGenerator = urlGenerator;
        }
        
        public override async Task<IViewComponentResult> InvokeAsync(Image contentModel)
        {
            var imageReference = contentModel.GetReference();
            var url = _urlGenerator.GetUrl(imageReference);
            return View("Default",url);
        }
    }
}