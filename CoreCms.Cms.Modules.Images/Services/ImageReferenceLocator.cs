using System;
using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Modules.Images.Model;
using CoreCms.DataAccess.Contract;
using Microsoft.AspNetCore.Http;

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
            var nodes = _repository.GetQueryable().ToList();
            var rootNode = nodes.Single(x => x.ParentId == Guid.Empty);

            var fragmentedUrl = url.Split('/').Where(x => !string.IsNullOrEmpty(x));

            var currentNode = rootNode;
            foreach (var fragment in fragmentedUrl)
            {
                var children = nodes.Where(x => x.ParentId == currentNode.Id);
                var match = children.SingleOrDefault(x => x.Name == fragment);

                currentNode = match;
                if (match == null)
                {
                    break;
                }
            }

            var imageNode = currentNode as ImageNode;
            if (imageNode == null)
            {
                return null;
            }
            
            return new ImageReference{Name = imageNode.Name, ContentId = imageNode.ImageId};
        }
    }
}