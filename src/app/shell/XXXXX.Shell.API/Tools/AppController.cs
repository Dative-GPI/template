using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

using XXXXX.Shell.Core;

namespace XXXXX.Shell.API.Controllers
{
    public abstract class AppController : ControllerBase
    {
        protected RequestHeaders GetRequestHeaders(bool withAuthorization = false)
        {
            return new RequestHeaders()
            {
                ApplicationId = new Guid(Request.Headers["X-Application-Id"].ToString()),
                ActorId = new Guid(Request.Headers["X-User-Id"].ToString()),
                LanguageCode = Request.Headers["Accept-Language"].ToString(),
                Jwt = withAuthorization ? Request.Headers[HeaderNames.Authorization].ToString().Substring(7) : null
            };
        }
    }
}
