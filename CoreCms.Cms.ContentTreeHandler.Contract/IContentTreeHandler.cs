using System;
using CoreCms.Cms.Model.Content.ContentTree;

namespace CoreCms.Cms.ContentTreeHandler.Contract
{
    public interface IContentTreeHandler
    {
        ContentNode GetContentNodeForUrl(string url);

        string ResolveContentUrl(Guid contentNodeId);

        void AddContentNode(Guid parentId, ContentNode newNode);
    }
}