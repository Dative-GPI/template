using System;

using Microsoft.AspNetCore.Mvc;

namespace XXXXX.Shell.API.Controllers
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
    }
}
