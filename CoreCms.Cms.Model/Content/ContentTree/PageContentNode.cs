using System;

namespace CoreCms.Cms.Model.Content.ContentTree
{
    public class PageContentNode : ContentNode
    {
        public Guid PageId { get; set; }

        public string PageName { get; set; }
    }
}