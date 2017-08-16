using System;

namespace CoreCms.Cms.Model.Base
{
    public interface IEntity
    {
        string CollectionName { get; }

        Guid Id { get; set; }
    }
}