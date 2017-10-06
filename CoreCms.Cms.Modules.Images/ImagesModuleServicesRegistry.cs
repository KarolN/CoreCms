using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Modules.Images.Model;
using CoreCms.Cms.Modules.Images.RoutingProvider;
using CoreCms.Cms.Modules.Images.Services;
using CoreCms.DataAccess.Base;
using CoreCms.DataAccess.Contract;
using StructureMap;

namespace CoreCms.Cms.Modules.Images
{
    public class ImagesModuleServicesRegistry : Registry
    {
        public ImagesModuleServicesRegistry()
        {
            For<ICmsModuleDescriptor>().Use<ImagesModuleDescriptor>().Named(ImagesModuleConstants.ContentType);
            For<ICmsRoutingHandler>().Use<CmsImageRoutingHandler>().Named(ImagesModuleConstants.ContentType);
            For<IRepository<ImagesTreeNode>>().Use<MongoRepository<ImagesTreeNode>>();
            For<IRepository<Image>>().Use<MongoRepository<Image>>();
            For<IContentReferenceLocator>().Use<ImageReferenceLocator>().Named(ImagesModuleConstants.ContentType);
            For<IImageLoader>().Use<FileSystemImageLoader>();
            For<IContentProvider>().Use<ImageContentProvider>().Named(ImagesModuleConstants.ContentType);
        }   
    }
}