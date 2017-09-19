using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Core.Contract
{
    public interface IContentProvider : ICmsModuleService
    {
        Content GetContent(ContentReference contentReference);
    }
}