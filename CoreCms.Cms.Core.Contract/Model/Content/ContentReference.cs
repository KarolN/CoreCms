using System;

namespace CoreCms.Cms.Core.Contract.Model.Content
{
    public abstract class ContentReference
    {
        public abstract string ContentType { get; }

        public Guid ContentId { get; set; }
        
        public string Name { get; set; }
    }
}