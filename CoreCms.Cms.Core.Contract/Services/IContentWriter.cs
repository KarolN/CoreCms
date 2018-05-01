using System;
using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IContentWriter
    {
        void UpdateContent(Content content);
        Content CreateContent(string name, Guid parentId, ContentTemplate template);
    }
}