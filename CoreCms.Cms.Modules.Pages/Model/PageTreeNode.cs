using System;
using System.Collections.Generic;
using CoreCms.Cms.Model.Base;

namespace CoreCms.Cms.Modules.Pages.Model
{
    public class PageTreeNode : BaseEntity
    {
        public string Name { get; set; }
        public Guid PageId { get; set; }
        public List<PageTreeNode> Children { get; set; }
    }
}