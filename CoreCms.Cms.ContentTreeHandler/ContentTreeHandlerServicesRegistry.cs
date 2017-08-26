using CoreCms.Cms.ContentTreeHandler.Contract;
using StructureMap;

namespace CoreCms.Cms.ContentTreeHandler
{
    public class ContentTreeHandlerServicesRegistry : Registry
    {
        public ContentTreeHandlerServicesRegistry()
        {
            For<IContentTreeHandler>().Use<DefaultHierarchicContentTreeHandler>();
        }
    }
}