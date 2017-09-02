using System.Collections.Generic;

namespace CoreCms.Cms.Model.Content
{
    public abstract class ContentReference
    {
        public abstract string ContentType { get; }

        public string Name { get; set; }
    }
}