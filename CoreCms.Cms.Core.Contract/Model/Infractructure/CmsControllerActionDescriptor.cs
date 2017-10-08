using System;

namespace CoreCms.Cms.Core.Contract.Model.Infractructure
{
    public class CmsControllerActionDescriptor
    {
        public Type ControllerType { get; set; }
        public Type ModelType { get; set; }
        public string ControllerName { get; set; }
    }
}