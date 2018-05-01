using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class ContentTemplateLoader : IContentTemplateLoader
    {
        private readonly Dictionary<string, IContentTemplateProvider> _templateProviders;
        
        public ContentTemplateLoader(List<IContentTemplateProvider> providers)
        {
            _templateProviders = providers.ToDictionary(x => x.GetContentTypeName(), x => x);
        }
        
        public List<ContentTemplate> LoadAllTemplates(string contentType)
        {
            return _templateProviders[contentType].GetContentTemplates();
        }
    }
}