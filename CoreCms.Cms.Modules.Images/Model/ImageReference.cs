using System;
using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Modules.Images.Model
{
    public class ImageReference : ContentReference, INestableContentReference
    {
        public override string ContentType => ImagesModuleConstants.ContentType;
        public Guid ImageId { get; set; }
    }
}
