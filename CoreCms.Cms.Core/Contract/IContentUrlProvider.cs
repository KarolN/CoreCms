using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Core.Contract
{
    public interface IContentUrlProvider : ICmsModuleService
    {
        string GetContentUrl(ContentReference contentReference);
    }
}