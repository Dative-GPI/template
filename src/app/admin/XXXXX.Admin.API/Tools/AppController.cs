using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

using XXXXX.Admin.Core;

namespace XXXXX.Admin.API.Controllers
{
    public abstract class AppController : ControllerBase
    {
        protected Guid GetAppId()
        {
            return new Guid(Request.Headers["X-Application-Id"].ToString());
        }

        protected Guid GetActorId()
        {
            return new Guid(Request.Headers["X-User-Id"].ToString());
        }

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
