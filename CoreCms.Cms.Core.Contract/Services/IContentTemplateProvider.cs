using System.Collections.Generic;
using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IContentTemplateProvider : ICmsModuleService
    {
        List<ContentTemplate> GetContentTemplates();
    }
}