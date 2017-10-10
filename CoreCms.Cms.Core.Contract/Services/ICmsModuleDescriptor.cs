﻿using System;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface ICmsModuleDescriptor
    {
        string GetModuleName();
        Type GetRoutingHandlerType();
    }
}