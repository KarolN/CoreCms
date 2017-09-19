using System.Collections.Generic;
using CoreCms.Cms.Core.Infrastructure;

namespace CoreCms.Cms.Core.Contract
{
    public interface ICmsControllerActionDescriptorsProvider
    {
        IList<CmsControllerActionDescriptor> GetDescriptors();
    }
}