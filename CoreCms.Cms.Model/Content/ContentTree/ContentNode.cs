using System;
using System.Collections.Generic;
using CoreCms.Cms.Model.Base;

namespace CoreCms.Cms.Model.Content.ContentTree
{
    public class ContentNode : BaseEntity
    {
        public virtual string ContentType { get; set; }

        public virtual string ContentProvider { get; set; }

        public virtual string Name { get; set; }

        public List<ContentNode> ChildNodes { get; set; }
    }
}