using System.Collections.Generic;
using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IContentTemplateLoader
    {
        List<ContentTemplate> LoadAllTemplates(string contentType);
    }
}