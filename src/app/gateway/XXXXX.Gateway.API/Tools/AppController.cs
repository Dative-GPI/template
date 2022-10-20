using System;

using Microsoft.AspNetCore.Mvc;
using XXXXX.Domain.Models;

namespace XXXXX.Gateway.API.Controllers
{
    public abstract class AppController : ControllerBase
    {
        protected Guid GetApplicationId()
        {
            return new Guid(Request.Headers["X-Application-Id"].ToString());
        }

        protected Guid GetActorId()
        {
            return new Guid(Request.Headers["X-User-Id"].ToString());
        }

        protected Guid GetSourceId()
        {
            return new Guid(Request.Headers["X-Source-Id"].ToString());
        }
        
        protected Guid GetOrganisationId()
        {
            if (string.IsNullOrWhiteSpace(Request.Headers["X-Organisation-Id"].ToString()))
            {
                throw new Exception(ErrorCode.MissingOrganisation);
            }

            return new Guid(Request.Headers["X-Organisation-Id"].ToString());
        }

        protected Guid GetUserApplicationId()
        {
            if (string.IsNullOrWhiteSpace(Request.Headers["X-User-Application-Id"].ToString()))
            {
                throw new Exception(ErrorCode.MissingUserApplication);
            }

            return new Guid(Request.Headers["X-User-Application-Id"].ToString());
        }

        protected string GetLanguageCode()
        {
            if (string.IsNullOrWhiteSpace(Request.Headers["Accept-Language"].ToString()))
            {
                throw new Exception(ErrorCode.MissingLanguage);
            }

            return Request.Headers["Accept-Language"].ToString();
        }
    }
}
