using System;
using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Modules.Pages.Model
{
    public class PageReference : ContentReference
    {
        public Guid PageId { get; set; }
        public override string ContentType => PageConstants.ContentType;
    }
}