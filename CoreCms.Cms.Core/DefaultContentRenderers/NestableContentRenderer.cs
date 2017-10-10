using System;
using System.Linq;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace CoreCms.Cms.Core.DefaultContentRenderers
{
    public class NestableContentRenderer : BaseContentRenderer
    {
        private readonly ICmsViewComponentsDescriptorsProvider _viewComponentsDescriptorsProvider;
        private readonly IContentLoader _contentLoader;
        private readonly IViewComponentHelper _viewComponentHelper;

        public NestableContentRenderer(ICmsViewComponentsDescriptorsProvider viewComponentsDescriptorsProvider, 
                            IContentLoader contentLoader, IViewComponentHelper viewComponentHelper)
        {
            _viewComponentsDescriptorsProvider = viewComponentsDescriptorsProvider;
            _contentLoader = contentLoader;
            _viewComponentHelper = viewComponentHelper;
        }

        public override async Task<IHtmlContent> Render(object renderProperty, ViewContext viewContext)
        {
            var contentReference = renderProperty as ContentReference;
            if (contentReference == null)
            {
                throw new ArgumentException(
                    "Nestable content renderer got property to render which is not assignable to content reference");
            }
            
            var loadedContent = _contentLoader.Load(contentReference);
            var viewComponentsDescriptors = _viewComponentsDescriptorsProvider.GetViewComponentDescriptors();

            var contentViewComponentDescriptor =
                viewComponentsDescriptors.Single(x => x.ModelType == loadedContent.GetType());

            var defaultViewComponentHelper = _viewComponentHelper as DefaultViewComponentHelper;
            defaultViewComponentHelper?.Contextualize(viewContext);

            return await _viewComponentHelper.InvokeAsync(contentViewComponentDescriptor.ViewComponentName, new {contentModel = loadedContent});
        }

        public override Type SupportedType => typeof(INestableContentReference);
    }
}