using System;
using MongoDB.Bson.Serialization.Attributes;

namespace CoreCms.Cms.Model.Base
{
    public abstract class BaseEntity : IEntity
    {
        public virtual string CollectionName => this.GetType().Name;

        [BsonId]
        public Guid Id { get; set; }
    }
}