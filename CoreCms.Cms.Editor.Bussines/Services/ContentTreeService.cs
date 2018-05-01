using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Editor.Bussines.Contract.Model.ContentTree;
using CoreCms.Cms.Editor.Bussines.Contract.Services;
using CoreCms.Cms.Editor.Bussines.Contract.Services.ModuleSpecific;

namespace CoreCms.Cms.Editor.Bussines.Services
{
    public class ContentTreeService : IContentTreeService
    {
        private readonly List<ICmsModuleDescriptor> _moduleDescriptors;
        private readonly IContentTemplateLoader _contentTemplateLoader;
        private readonly Dictionary<string, IContentTreeProvider> _contentTreeProviders;

        public ContentTreeService(List<ICmsModuleDescriptor> moduleDescriptors, List<IContentTreeProvider> contentTreeProviders,
            IContentTemplateLoader contentTemplateLoader)
        {
            _moduleDescriptors = moduleDescriptors;
            _contentTemplateLoader = contentTemplateLoader;
            _contentTreeProviders = contentTreeProviders.ToDictionary(x => x.GetContentTypeName(), x => x);
        }
        
        public List<ContentTypeDto> GetContentTypes()
        {
            var contentTypes = _moduleDescriptors.Select(x =>
                new ContentTypeDto {ContentType = x.GetModuleName(), Name = x.GetModuleDisplayName()}).ToList();
            return contentTypes;
        }

        public ContentTreeDto GetContentTree(string contentType)
        {
            if (!_contentTreeProviders.ContainsKey(contentType))
            {
                return null;
            }

            return _contentTreeProviders[contentType].GetContentTreeDto();
        }

        public List<ContentTemplateDto> GetContentTemplates(string contentType)
        {
            var templates = _contentTemplateLoader.LoadAllTemplates(contentType);
            return templates.Select(x => new ContentTemplateDto()
            {
                ContentType = x.ContentType,
                Name = x.Name,
                TemplateTypeFullName = x.TemplateTypeFullName
            }).ToList();
        }
    }
}