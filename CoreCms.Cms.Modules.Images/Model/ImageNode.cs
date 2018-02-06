using System;
using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Modules.Images.Model
{
    public class ImageNode : ImagesTreeNode
    {
        public Guid ImageId { get; set; }

        public override ContentReference GetContentReference()
        {
            return new ImageReference { ContentId = ImageId, Name = Name};
        }
    }
}