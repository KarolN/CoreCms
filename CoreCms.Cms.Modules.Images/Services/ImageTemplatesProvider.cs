using CoreCms.Cms.Core.Abstract;
using CoreCms.Cms.Modules.Images.Model;

namespace CoreCms.Cms.Modules.Images.Services
{
    public class ImageTemplatesProvider : GenericContentTemplateProvider<Image>
    {
        public override string GetContentTypeName()
        {
            return ImagesModuleConstants.ContentType;
        }
    }
}