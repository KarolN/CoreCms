using System;
using CoreCms.Cms.Model.Base;

namespace CoreCms.Cms.Modules.Images.Model
{
    public class ImagesTreeNode : BaseEntity
    {
        public string Name { get; set; }
        public Guid ParentId { get; set; }
    }
}