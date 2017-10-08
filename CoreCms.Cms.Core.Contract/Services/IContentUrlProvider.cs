using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IContentUrlProvider : ICmsModuleService
    {
        string GetContentUrl(ContentReference contentReference);
    }
}