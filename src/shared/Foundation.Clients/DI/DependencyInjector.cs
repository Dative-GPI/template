using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Foundation.Clients.Abstractions;
using Foundation.Clients.Abstractions.Shell;
using Foundation.Clients.Abstractions.Gateway;

using Foundation.Clients.Services;
using Foundation.Clients.Abstractions.Admin;

namespace Foundation.Clients.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddFoundationClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            services.AddTransient<IFoundationClient, FoundationClient>();

            services.AddTransient<IAdminFoundationClient, AdminFoundationClient>();
            services.AddTransient<IShellFoundationClient, ShellFoundationClient>();
            services.AddTransient<IGatewayFoundationClient, GatewayFoundationClient>();

            services.AddTransient<IShellOrganisationFoundationClient, ShellOrganisationFoundationClient>();
            services.AddTransient<IShellUserOrganisationFoundationClient, ShellUserOrganisationFoundationClient>();
            services.AddTransient<IShellPermissionFoundationClient, ShellPermissionFoundationClient>();

            services.AddTransient<IGatewayUserFoundationClient, GatewayUserFoundationClient>();
            services.AddTransient<IGatewayAccountFoundationClient, GatewayAccountFoundationClient>();
            services.AddTransient<IGatewayTranslationFoundationClient, GatewayTranslationFoundationClient>();

            services.AddTransient<IAdminUserApplicationFoundationClient, AdminUserApplicationFoundationClient>();
            services.AddTransient<IAdminPermissionFoundationClient, AdminPermissionFoundationClient>();

            return services;
        }
    }
}