using System.Threading.Tasks;
using XXXXX.Domain.Abstractions;
using XXXXX.Admin.Core.Models;
using Foundation.Clients.Abstractions;

namespace XXXXX.Admin.Core
{
    public static class FoundationClientFactoryExtensions
    {
        public static Task<IFoundationClient> CreateFromRequestContext(this IFoundationClientFactory factory, RequestContext context)
        {
            return factory.CreateAuthenticated(context.ApplicationId, context.LanguageCode, context.Jwt);
        }
    }
}