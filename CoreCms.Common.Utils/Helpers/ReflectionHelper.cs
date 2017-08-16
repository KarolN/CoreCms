using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyModel;

namespace CoreCms.Common.Utils.Helpers
{
    public static class ReflectionHelper
    {
        public static List<Type> GetDeriveredTypesInAssembly(Type baseType)
        {
            var runtimeId = RuntimeEnvironment.GetRuntimeIdentifier();
            var runtimeAssemblies = DependencyContext.Default.GetRuntimeAssemblyNames(runtimeId).Select(Assembly.Load).ToList();

            var types = runtimeAssemblies.SelectMany(x => x.ExportedTypes);
            var deriveredTypes = types.Where(x => baseType.IsAssignableFrom(x) && x != baseType).ToList();
            return deriveredTypes;
        }
    }
}