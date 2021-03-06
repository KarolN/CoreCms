﻿using System;
using System.Collections.Generic;
using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IContentProvider : ICmsModuleService
    {
        Content GetContent(ContentReference contentReference);
        void UpdateContent(Content content);
        Content SaveContent(Content content, Guid parent);
        List<ContentReference> GetChidren(ContentReference parentReference);
    }
}