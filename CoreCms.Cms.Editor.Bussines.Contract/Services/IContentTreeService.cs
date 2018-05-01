using System.Collections.Generic;
using CoreCms.Cms.Editor.Bussines.Contract.Model.ContentTree;

namespace CoreCms.Cms.Editor.Bussines.Contract.Services
{
    public interface IContentTreeService
    {
        List<ContentTypeDto> GetContentTypes();
        ContentTreeDto GetContentTree(string contentType);
        List<ContentTemplateDto> GetContentTemplates(string contentType);
    }
}