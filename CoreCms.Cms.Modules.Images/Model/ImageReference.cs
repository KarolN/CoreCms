using System;
using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Modules.Images.Model
{
    public class ImageReference : ContentReference
    {
        public override string ContentType => ImagesModuleConstants.ContentType;
        public Guid ImageId { get; set; }
    }
}