using System;
using System.Collections.Generic;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Model.Base;

namespace CoreCms.Cms.Modules.Images.Model
{
    public class ImagesTreeNode : BaseEntity, IContentTreeNode
    {
        public string Name { get; set; }
        public Guid ParentId { get; set; }

        public virtual ContentReference GetContentReference()
        {
            return null;
        }
    }
}