using System;
using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Editor.Bussines.Contract.Model.ContentTree;
using CoreCms.Cms.Editor.Bussines.Contract.Services.ModuleSpecific;
using CoreCms.DataAccess.Contract;

namespace CoreCms.Cms.Editor.Bussines.Services.BaseServices
{
    public abstract class ContentTreeProviderBase<TContentNode, TReposistory> : IContentTreeProvider
        where TContentNode : IContentTreeNode
        where TReposistory : IRepository<TContentNode>

    {
        protected TReposistory _reposistory;

        public abstract string GetContentTypeName();

        public ContentTreeDto GetContentTreeDto()
        {
            var nodes = _reposistory.GetQueryable().ToList();
            var rootNode = nodes.Single(x => x.ParentId == Guid.Empty);

            var contentTreeDto = new ContentTreeDto();

            contentTreeDto.Root = ConvertNodeToTreeItem(rootNode);
            contentTreeDto.Root.Children = GetChildren(rootNode, nodes);
            return contentTreeDto;
        }
        
        protected List<ContentTreeItemDto> GetChildren(TContentNode node, List<TContentNode> nodes)
        {
            var children = nodes.Where(x => x.ParentId == node.Id);
            if (children.Count() == 0)
            {
                return null;
            }
            var childNodes = new List<ContentTreeItemDto>();
            foreach (var child in children)
            {
                var childNode = ConvertNodeToTreeItem(child);
                childNode.Children = GetChildren(child, nodes);
                childNodes.Add(childNode);
            }

            return childNodes;
        }

        protected abstract ContentTreeItemDto ConvertNodeToTreeItem(TContentNode treeNode);
    }
}