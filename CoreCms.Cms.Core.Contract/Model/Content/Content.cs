using CoreCms.Cms.Model.Base;

namespace CoreCms.Cms.Core.Contract.Model.Content
{
    public abstract class Content : BaseEntity
    {
        public string Name { get; set; }

        public abstract ContentReference GetReference();
    }
}