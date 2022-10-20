using System;

using XXXXX.Admin.Core.Models;
using XXXXX.Admin.Core.Abstractions;

namespace XXXXX.Admin.API.Tools
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