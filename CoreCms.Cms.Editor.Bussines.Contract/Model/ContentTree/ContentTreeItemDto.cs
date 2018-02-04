using System;
using System.Collections.Generic;
using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Editor.Bussines.Contract.Model.ContentTree
{
    public class ContentTreeItemDto
    {
        public Guid Id { get; set; }
        public ContentReference ContentReference { get; set; }
        public string Name { get; set; }
        public List<ContentTreeItemDto> Children { get; set; }

        public ContentTreeItemDto()
        {
            Children = new List<ContentTreeItemDto>();
        }
    }
}