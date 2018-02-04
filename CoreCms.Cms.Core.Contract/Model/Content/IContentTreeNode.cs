using System;
using System.Collections.Generic;
using CoreCms.Cms.Model.Base;

namespace CoreCms.Cms.Core.Contract.Model.Content
{
    public interface IContentTreeNode : IEntity
    {
        Guid ParentId { get; }
    }
}