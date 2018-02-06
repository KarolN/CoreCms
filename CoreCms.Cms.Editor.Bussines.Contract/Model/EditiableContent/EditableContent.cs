using System;
using System.Collections.Generic;
using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent
{
    public class EditableContent
    {
        public Guid ContentId { get; set; }

        public string Name { get; set; }

        public List<EditableProperty> Properties { get; set; }

        public EditableContent()
        {
            
        }

        public EditableContent(Content content)
        {
            ContentId = content.Id;
            Name = content.Name;
        }
    }
}