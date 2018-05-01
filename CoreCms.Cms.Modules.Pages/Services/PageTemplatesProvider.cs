using CoreCms.Cms.Core.Abstract;
using CoreCms.Cms.Modules.Pages.Model;

namespace CoreCms.Cms.Modules.Pages.Services
{
    public class PageTemplatesProvider : GenericContentTemplateProvider<Page>
    {
        public override string GetContentTypeName()
        {
            return PageConstants.ContentType;
        }
    }
}