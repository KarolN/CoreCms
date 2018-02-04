using CoreCms.Cms.Editor.Bussines.Contract.Model.ContentTree;
using CoreCms.Cms.Editor.Bussines.Services.BaseServices;
using CoreCms.Cms.Modules.Images.Model;
using CoreCms.DataAccess.Contract;

namespace CoreCms.Cms.Modules.Images.Services
{
    public class ImageTreeProvider : ContentTreeProviderBase<ImagesTreeNode,IRepository<ImagesTreeNode>>
    {

        public ImageTreeProvider(IRepository<ImagesTreeNode> repository)
        {
            _reposistory = repository;
        }
        
        public override string GetContentTypeName()
        {
            return ImagesModuleConstants.ContentType;
        }

        protected override ContentTreeItemDto ConvertNodeToTreeItem(ImagesTreeNode treeNode)
        {
            var item = new ContentTreeItemDto{Name = treeNode.Name, Id = treeNode.Id, ContentReference = treeNode.GetContentReference()};
            return item;
        }
    }
}