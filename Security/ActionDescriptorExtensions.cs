using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Adm.Security
{
    public static class ActionDescriptorExtensions
    {
        public static bool HasAttribute(this ActionDescriptor actionDescriptor, Type type)
        {
            return actionDescriptor.EndpointMetadata.Where(f => f.GetType() == type).FirstOrDefault() != null;
        }
    }
}
