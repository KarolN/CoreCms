﻿using System.Collections.Generic;
using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IContentLoader
    {
        Content Load(ContentReference contentReference);
        List<ContentReference> LoadChildren(ContentReference parentReference);
    }
}