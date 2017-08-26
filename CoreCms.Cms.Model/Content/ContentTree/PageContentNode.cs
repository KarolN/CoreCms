using System;
using CoreCms.Common.Constants;

namespace CoreCms.Cms.Model.Content.ContentTree
{
    public class PageContentNode : ContentNode
    {
        public Guid PageId { get; set; }

        public string PageName { get; set; }

        public override string ContentProvider { get { return ContentProviders.PageProvider; } set{} }

        public override string ContentType { get { return ContentTypes.Page; } set{}}
    }
}