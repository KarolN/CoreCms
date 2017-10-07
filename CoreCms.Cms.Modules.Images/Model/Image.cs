﻿using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Modules.Images.Model
{
    public class Image : Content, INestableContent
    {
        public string ImageType { get; set; }
        public string PhysicalPath { get; set; }
        
        public override ContentReference GetReference()
        {
            return new ImageReference{Name = Name, ImageId = Id};
        }
    }
}