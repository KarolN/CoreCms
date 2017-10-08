using System;

namespace CoreCms.Cms.Core.Contract.Model.Infractructure
{
    public class CmsViewComponentDescriptor
    {
        public Type ViewComponentType { get; set; }
        public Type ModelType { get; set; }
        public string ViewComponentName { get; set; }
    }
}