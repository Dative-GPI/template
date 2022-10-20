using System;
using XXXXX.Shell.Core.Models;
using XXXXX.Shell.Core.Abstractions;

namespace XXXXX.Shell.API.Tools
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