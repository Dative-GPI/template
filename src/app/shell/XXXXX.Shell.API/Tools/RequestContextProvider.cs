using System;
using XXXXX.Shell.Core.Models;
using XXXXX.Shell.Core.Abstractions;

namespace XXXXX.Shell.API.Tools
{
    public class RequestContextProvider : IRequestContextProvider
    {
        public RequestContext Context { get; set; }
    }
}