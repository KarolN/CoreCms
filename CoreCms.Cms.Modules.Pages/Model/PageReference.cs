﻿using System;
using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Modules.Pages.Model
{
    public class PageReference : ContentReference
    {
        public Guid PageId { get; set; }
        public string PageType { get; set; }
        public override string ContentType => PageConstants.ContentType;
    }
}