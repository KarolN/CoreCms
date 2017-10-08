using System.Collections.Generic;
using CoreCms.Cms.Core.Contract.Model.Infractructure;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface ICmsControllerActionDescriptorsProvider
    {
        IList<CmsControllerActionDescriptor> GetDescriptors();
    }
}