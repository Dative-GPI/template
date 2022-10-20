using System;
using XXXXX.Gateway.Core.Models;
using XXXXX.Gateway.Core.Abstractions;

namespace XXXXX.Gateway.API.Tools
{
    public class RequestContextProvider : IRequestContextProvider
    {
        public Func<RequestContext> Accessor { get; set; }

        RequestContext _context;
        public RequestContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = Accessor();
                }
                return _context;
            }
        }
    }
}