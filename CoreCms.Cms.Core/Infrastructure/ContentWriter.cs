using System;
using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class ContentWriter : IContentWriter
    {
        private readonly List<IContentProvider> _contentProviders;

        public ContentWriter(List<IContentProvider> contentProviders)
        {
            _contentProviders = contentProviders;
        }
        
        public void UpdateContent(Content content)
        {
            var contentReference = content.GetReference();
            var contentProvider = _contentProviders.Single(x => x.GetContentTypeName() == contentReference.ContentType);
            contentProvider.UpdateContent(content);
        }

        public Content CreateContent(string name, Guid parentId, ContentTemplate template)
        {
            var type = Type.GetType(template.TemplateTypeFullName);
            Content content = Activator.CreateInstance(type) as Content;

            if (content == null)
            {
                throw new ArgumentException($"Content type: {template.TemplateTypeFullName} not found");
            }

            content.Name = name;
            var provider = _contentProviders.Single(x => x.GetContentTypeName() == template.ContentType);
            content = provider.SaveContent(content, parentId);
            
            return content;
        }
    }
}