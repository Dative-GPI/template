using System;

using XXXXX.Admin.Core.Models;
using XXXXX.Admin.Core.Abstractions;

namespace XXXXX.Admin.API.Tools
{
    public class RequestContextProvider : IRequestContextProvider
    {
        public RequestContext Context { get; set; }
    }
}