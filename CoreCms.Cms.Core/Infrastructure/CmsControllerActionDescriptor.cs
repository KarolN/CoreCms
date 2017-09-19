using System;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class CmsControllerActionDescriptor
    {
        public Type ControllerType { get; set; }
        public Type ModelType { get; set; }
        public string ControllerName { get; set; }
    }
}