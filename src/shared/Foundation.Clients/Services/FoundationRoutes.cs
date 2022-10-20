namespace Foundation.Clients.Services
{
    public static class ShellFoundationRoutes
    {
        public const string ORGANISATIONS_PATH = "api/v1/organisations";
        public const string USER_ORGANISATIONS_PATH = "api/v1/user-organisations";
        public const string PERMISSIONS_PATH = "api/v1/permissions/current";
    }

    public static class AdminFoundationRoutes
    {
        public const string USER_APPLICATIONS_PATH = "api/admin/v1/users";
        public const string CURRENT_PERMISSIONS_ADMIN_PATH = "api/admin/v1/permissions-admin/current";
    }

    public static class GatewayFoundationRoutes
    {
        public const string USERS_PATH = "/api/v1/users";
        public const string ACCOUNTS_PATH = "/api/v1/accounts";
        public const string TRANSLATIONS_PATH = "/api/v1/translations";
    }
}