using System; 
namespace CoreCms.Cms.Core.Contract
{
    public interface ICmsModuleDescriptor
    {
        string GetModuleName();
        Type GetRoutingHandlerType();
    }
}