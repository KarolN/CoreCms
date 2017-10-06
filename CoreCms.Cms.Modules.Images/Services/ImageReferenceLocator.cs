using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Model.Content;
using CoreCms.Cms.Modules.Images.Model;
using CoreCms.DataAccess.Contract;

namespace CoreCms.Cms.Modules.Images.Services
{
    public class ImageReferenceLocator : ImagesModuleServiceBase, IContentReferenceLocator
    {
        private readonly IRepository<ImagesTreeNode> _repository;

        public ImageReferenceLocator(IRepository<ImagesTreeNode> repository)
        {
            _repository = repository;
        }
        public ContentReference LocateFromUrl(string url)
        {
            var rootNode = _repository.GetQueryable().Single();
            var fragmentedUrl = url.Split('/').Where(x => !string.IsNullOrEmpty(x));

            var currentNode = rootNode;
            foreach (var fragment in fragmentedUrl)
            {
                var treeNode = currentNode as ImagesDirectory;
                if (treeNode == null)
                {
                    currentNode = null;
                    break;
                }

                var matchChid = treeNode.Children.SingleOrDefault(x => x.Name == fragment);
                if (matchChid == null)
                {
                    currentNode = null;
                    break;
                }

                currentNode = matchChid;
            }

            var imageNode = currentNode as ImageNode;
            if (imageNode == null)
            {
                return null;
            }
            
            var imageReference = new ImageReference
            {
                ImageId = imageNode.ImageId
            };
            return imageReference;
        }
    }
}