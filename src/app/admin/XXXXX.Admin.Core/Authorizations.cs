namespace XXXXX.Admin.Core
{
  public static class Authorizations
  {

        public const string DRAWER_ROUTE_INFOS = "drawer.routes.infos";

        #region Permissions
        public const string ADMIN_PERMISSION_INFOS = "admin.permissions.infos";
        #endregion

        #region PermissionCategory
        public const string ADMIN_PERMISSION_CATEGORY = "admin.permission.category";
        #endregion

        #region organisationTypePermission
        public const string ADMIN_ORGANISATION_TYPE_PERMISSION_INFOS = "admin.organisation.type.permission.infos";
        public const string ADMIN_ORGANISATION_TYPE_PERMISSION_DETAILS = "admin.organisation.type.permission.details";
        public const string ADMIN_ORGANISATION_TYPE_PERMISSION_CREATE = "admin.organisation.type.permission.create";
        public const string ADMIN_ORGANISATION_TYPE_PERMISSION_UPDATE = "admin.organisation.type.permission.update";
        public const string ADMIN_ORGANISATION_TYPE_PERMISSION_REMOVE = "admin.organisation.type.permission.remove";
        #endregion
        
        #region RolePermissions
        public const string ADMIN_ROLE_PERMISSIONS_INFOS = "admin.role.permissions.infos";
        public const string ADMIN_ROLE_PERMISSIONS_UPDATE = "admin.role.permissions.update";
        #endregion
  }
}