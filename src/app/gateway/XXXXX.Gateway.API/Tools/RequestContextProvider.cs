using System;
using XXXXX.Gateway.Core.Models;
using XXXXX.Gateway.Core.Abstractions;

namespace XXXXX.Gateway.API.Tools
{
    public class RequestContextProvider : IRequestContextProvider
    {
        public RequestContext Context { get; set; }
    }
}