using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Model.Base;

namespace CoreCms.Cms.Modules.Pages.Model
{
    public class PageTreeNode : BaseEntity, IContentTreeNode
    {
        public string Name { get; set; }
        public Guid PageId { get; set; }
        public string PageType { get; set; }
        public Guid ParentId { get; set; }

        public ContentReference ToContentReference()
        {
            return new PageReference{Name = Name, ContentId = PageId, PageType = PageType };
        }
    }
}