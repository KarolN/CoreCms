using System.Collections.Generic;
using CoreCms.Cms.Model.Base;

namespace CoreCms.Cms.Modules.Images.Model
{
    public class ImagesDirectory : ImagesTreeNode
    {
        public List<ImagesTreeNode> Children { get; set; }
    }
}