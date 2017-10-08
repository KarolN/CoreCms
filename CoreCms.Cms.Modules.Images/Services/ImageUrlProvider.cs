using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Modules.Images.Model;
using CoreCms.DataAccess.Contract;

namespace CoreCms.Cms.Modules.Images.Services
{
    public class ImageUrlProvider : ImagesModuleServiceBase,IContentUrlProvider
    {
        private readonly IRepository<ImagesTreeNode> _repository;

        public ImageUrlProvider(IRepository<ImagesTreeNode> repository)
        {
            _repository = repository;
        }
        
        public string GetContentUrl(ContentReference contentReference)
        {
            var imageReference = contentReference as ImageReference;
            var nodes = _repository.GetQueryable().ToList();
            var imageNode = nodes.OfType<ImageNode>()
                .Single(x => x.ImageId == imageReference.ImageId);
            var hierarchyList = new List<ImagesTreeNode>();
            ImagesTreeNode currentNode = imageNode;
            while (currentNode.ParentId != Guid.Empty)
            {
                hierarchyList.Add(currentNode);
                currentNode = nodes.Single(x => x.Id == currentNode.ParentId);
            }

            hierarchyList.Reverse();
            var url = "/" + string.Join("/", hierarchyList.Select(x => x.Name));
            return url;
        }
    }
}