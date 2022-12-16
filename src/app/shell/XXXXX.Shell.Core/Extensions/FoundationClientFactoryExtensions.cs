using System.Threading.Tasks;
using XXXXX.Domain.Abstractions;
using XXXXX.Shell.Core.Models;
using Foundation.Clients.Abstractions;

namespace XXXXX.Shell.Core
{
    public static class FoundationClientFactoryExtensions
    {
        public static Task<IFoundationClient> CreateFromRequestContext(this IFoundationClientFactory factory, RequestContext context)
        {
            return factory.CreateAuthenticated(context.ApplicationId, context.LanguageCode, context.Jwt);
        }
    }
}