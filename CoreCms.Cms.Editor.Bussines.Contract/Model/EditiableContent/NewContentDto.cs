using System;
using CoreCms.Cms.Editor.Bussines.Contract.Model.ContentTree;

namespace CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent
{
    public class NewContentDto
    {
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public ContentTemplateDto ContentTemplate { get; set; }
    }
}