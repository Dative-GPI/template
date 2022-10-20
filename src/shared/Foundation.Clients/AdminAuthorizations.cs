namespace Foundation.Clients
{
    public static class AdminAuthorizations
    { 
        #region Article
        public const string ADMIN_ARTICLE_INFOS = "admin.article.infos";
        public const string ADMIN_ARTICLE_DETAILS = "admin.article.details";
        public const string ADMIN_ARTICLE_CREATE = "admin.article.create";
        public const string ADMIN_ARTICLE_UPDATE = "admin.article.update";
        public const string ADMIN_ARTICLE_REMOVE = "admin.article.remove";
        public const string ADMIN_ARTICLE_BULK_UPSERT = "admin.article.bulk-upsert";
        #endregion

        #region Application
        public const string ADMIN_APPLICATION_DETAILS = "admin.application.details";
        #endregion

        #region Charts
        public const string ADMIN_CHART_INFOS = "admin.chart.infos";
        public const string ADMIN_CHART_DETAILS = "admin.chart.details";
        public const string ADMIN_CHART_CREATE = "admin.chart.create";
        public const string ADMIN_CHART_UPDATE = "admin.chart.update";
        public const string ADMIN_CHART_REMOVE = "admin.chart.remove";
        #endregion

        #region Columnorganisationtype
        public const string ADMIN_COLUMNORGANISATIONTYPE_INFOS = "admin.columnorganisationtype.infos";
        public const string ADMIN_COLUMNORGANISATIONTYPE_DETAILS = "admin.columnorganisationtype.details";
        public const string ADMIN_COLUMNORGANISATIONTYPE_CREATE = "admin.columnorganisationtype.create";
        public const string ADMIN_COLUMNORGANISATIONTYPE_UPDATE = "admin.columnorganisationtype.update";
        public const string ADMIN_COLUMNORGANISATIONTYPE_REMOVE = "admin.columnorganisationtype.remove";
        #endregion

        #region Disposition
        public const string ADMIN_COLUMN_INFOS = "admin.column.infos";
        public const string ADMIN_COLUMN_DETAILS = "admin.column.details";
        public const string ADMIN_COLUMN_CREATE = "admin.column.create";
        public const string ADMIN_COLUMN_UPDATE = "admin.column.update";
        public const string ADMIN_COLUMN_REMOVE = "admin.column.remove";
        public const string ADMIN_TABLE_INFOS = "admin.tables.infos";
        public const string ADMIN_TABLE_DETAILS = "admin.tables.details";
        public const string ADMIN_TABLE_PATCH = "admin.tables.patch";
        public const string ADMIN_TABLE_UPDATE = "admin.tables.update";

        #endregion

        #region Dashboard
        public const string ADMIN_DASHBOARD_INFOS = "admin.dashboard.infos";
        public const string ADMIN_DASHBOARD_DETAILS = "admin.dashboard.details";
        public const string ADMIN_DASHBOARD_CREATE = "admin.dashboard.create";
        public const string ADMIN_DASHBOARD_UPDATE = "admin.dashboard.update";
        public const string ADMIN_DASHBOARD_REMOVE = "admin.dashboard.remove";
        #endregion

        #region Datadefinition
        public const string ADMIN_DATADEFINITION_INFOS = "admin.datadefinition.infos";
        public const string ADMIN_DATADEFINITION_DETAILS = "admin.datadefinition.details";
        public const string ADMIN_DATADEFINITION_CREATE = "admin.datadefinition.create";
        public const string ADMIN_DATADEFINITION_UPDATE = "admin.datadefinition.update";
        public const string ADMIN_DATADEFINITION_REMOVE = "admin.datadefinition.remove";
        #endregion

        #region Devices
        public const string ADMIN_DEVICE_BULK_UPSERT = "admin.device.bulk-upsert";
        #endregion


        #region DeviceOrganisations
        public const string ADMIN_DEVICEORGANISATION_INFOS = "admin.deviceorganisation.infos";
        public const string ADMIN_DEVICEORGANISATION_DETAILS = "admin.deviceorganisation.details";
        public const string ADMIN_DEVICEORGANISATION_ADD = "admin.deviceorganisation.add";
        public const string ADMIN_DEVICEORGANISATION_CREATEMANY = "admin.deviceorganisation.add-many";
        public const string ADMIN_DEVICEORGANISATION_UPDATE = "admin.deviceorganisation.update";
        public const string ADMIN_DEVICEORGANISATION_UPDATERANGE = "admin.deviceorganisation.bulk-update";
        public const string ADMIN_DEVICEORGANISATION_REMOVE = "admin.deviceorganisation.remove";
        public const string ADMIN_DEVICEORGANISATION_BULK_UPSERT = "admin.deviceorganisation.bulk-upsert";
        #endregion


        #region EmailConfiguration
        public const string ADMIN_EMAILCONFIGURATION_DETAILS = "admin.email-configuration.details";
        public const string ADMIN_EMAILCONFIGURATION_UPDATE = "admin.email-configuration.update";
        #endregion


        #region Extension
        public const string ADMIN_EXTENSION_INFOS = "admin.extension.infos";
        public const string ADMIN_EXTENSION_DETAILS = "admin.extension.details";
        public const string ADMIN_EXTENSION_CREATE_CUSTOM = "admin.extension.create-custom";
        
        public const string ADMIN_EXTENSIONAPPLICATION_CREATE = "admin.extensionapplication.create";
        public const string ADMIN_EXTENSIONAPPLICATION_REMOVE = "admin.extensionapplication.remove";
        public const string ADMIN_EXTENSIONAPPLICATIONS_INFOS = "admin.extensionapplication.infos";
        #endregion

        #region Family
        public const string ADMIN_FAMILY_INFOS = "admin.family.infos";
        public const string ADMIN_FAMILY_DETAILS = "admin.family.details";
        public const string ADMIN_FAMILY_CREATE = "admin.family.create";
        public const string ADMIN_FAMILY_UPDATE = "admin.family.update";
        public const string ADMIN_FAMILY_REMOVE = "admin.family.remove";
        public const string ADMIN_FAMILY_BULK_UPSERT = "admin.family.bulk-upsert";
        #endregion

        #region Language
        public const string ADMIN_LANGUAGE_INFOS = "admin.language.infos";
        public const string ADMIN_LANGUAGE_DETAILS = "admin.language.details";
        public const string ADMIN_LANGUAGE_CREATE = "admin.language.create";
        public const string ADMIN_LANGUAGE_UPDATE = "admin.language.update";
        public const string ADMIN_LANGUAGE_REMOVE = "admin.language.remove";
        #endregion

        #region TimeZones
        public const string ADMIN_TIMEZONE_INFOS = "admin.timezone.infos";
        #endregion

        #region LandingPage
        public const string ADMIN_LANDINGPAGE_DETAILS = "admin.landing-page.details";
        public const string ADMIN_LANDINGPAGE_UPDATE = "admin.landing-page.update";
        #endregion

        #region LayoutPage
        public const string ADMIN_LAYOUTPAGE_DETAILS = "admin.layout-page.details";
        public const string ADMIN_LAYOUTPAGE_UPDATE = "admin.layout-page.update";
        #endregion

        #region Manufacturer
        public const string ADMIN_MANUFACTURER_INFOS = "admin.manufacturer.infos";
        public const string ADMIN_MANUFACTURER_DETAILS = "admin.manufacturer.details";
        public const string ADMIN_MANUFACTURER_CREATE = "admin.manufacturer.create";
        public const string ADMIN_MANUFACTURER_UPDATE = "admin.manufacturer.update";
        public const string ADMIN_MANUFACTURER_REMOVE = "admin.manufacturer.remove";
        #endregion

        #region Model
        public const string ADMIN_MODEL_INFOS = "admin.model.infos";
        public const string ADMIN_MODEL_DETAILS = "admin.model.details";
        public const string ADMIN_MODEL_CREATE = "admin.model.create";
        public const string ADMIN_MODEL_UPDATE = "admin.model.update";
        public const string ADMIN_MODEL_REMOVE = "admin.model.remove";
        public const string ADMIN_MODEL_BULK_UPSERT = "admin.model.bulk-upsert";
        #endregion

        #region ModelStatuses
        public const string APP_MODELSTATUS_INFOS = "app.modelstatus.infos";
        public const string APP_MODELSTATUS_DETAILS = "app.modelstatus.details";
        public const string APP_MODELSTATUS_CREATE = "app.modelstatus.create";
        public const string APP_MODELSTATUS_UPDATE = "app.modelstatus.update";
        public const string APP_MODELSTATUS_REMOVE = "app.modelstatus.remove";
        #endregion

        #region ModelConnectivityStatuses
        public const string APP_MODELCONNECTIVITYSTATUS_INFOS = "app.modelconnectivitystatus.infos";
        public const string APP_MODELCONNECTIVITYSTATUS_DETAILS = "app.modelconnectivitystatus.details";
        public const string APP_MODELCONNECTIVITYSTATUS_CREATE = "app.modelconnectivitystatus.create";
        public const string APP_MODELCONNECTIVITYSTATUS_UPDATE = "app.modelconnectivitystatus.update";
        public const string APP_MODELCONNECTIVITYSTATUS_REMOVE = "app.modelconnectivitystatus.remove";
        #endregion

        #region Organisation
        public const string ADMIN_ORGANISATION_INFOS = "admin.organisation.infos";
        public const string ADMIN_ORGANISATION_DETAILS = "admin.organisation.details";
        public const string ADMIN_ORGANISATION_CREATE = "admin.organisation.create";
        public const string ADMIN_ORGANISATION_UPDATE = "admin.organisation.update";
        public const string ADMIN_ORGANISATION_UPDATEADMIN = "admin.organisation.update-admin";
        public const string ADMIN_ORGANISATION_REMOVE = "admin.organisation.remove";
        public const string ADMIN_ORGANISATION_BULK_UPSERT = "admin.organisation.bulk-upsert";
        #endregion

        #region Organisationrole
        public const string ADMIN_ORGANISATIONROLE_INFOS = "admin.organisationrole.infos";
        #endregion

        #region Organisationtype
        public const string ADMIN_ORGANISATIONTYPE_INFOS = "admin.organisationtype.infos";
        public const string ADMIN_ORGANISATIONTYPE_DETAILS = "admin.organisationtype.details";
        public const string ADMIN_ORGANISATIONTYPE_CREATE = "admin.organisationtype.create";
        public const string ADMIN_ORGANISATIONTYPE_UPDATE = "admin.organisationtype.update";
        public const string ADMIN_ORGANISATIONTYPE_REMOVE = "admin.organisationtype.remove";
        #endregion

        #region Pageinformation
        public const string ADMIN_PAGEINFORMATION_INFOS = "admin.pageinformation.infos";
        public const string ADMIN_PAGEINFORMATION_DETAILS = "admin.pageinformation.details";
        public const string ADMIN_PAGEINFORMATION_CREATE = "admin.pageinformation.create";
        public const string ADMIN_PAGEINFORMATION_UPDATE = "admin.pageinformation.update";
        public const string ADMIN_PAGEINFORMATION_REMOVE = "admin.pageinformation.remove";
        #endregion

        #region Permissions
        public const string ADMIN_PERMISSION_INFOS = "admin.permissions.infos";
        #endregion

        #region PermissionCategory
        public const string ADMIN_PERMISSION_CATEGORY = "admin.permission.category";
        #endregion


        #region Permissionsadmin
        public const string ADMIN_PERMISSIONADMIN_INFOS = "admin.permissionsadmin.infos";
        #endregion

        #region Permissionorganisationtype
        public const string ADMIN_PERMISSIONORGANISATIONTYPE_INFOS = "admin.permissionorganisationtype.infos";
        public const string ADMIN_PERMISSIONORGANISATIONTYPE_DETAILS = "admin.permissionorganisationtype.details";
        public const string ADMIN_PERMISSIONORGANISATIONTYPE_CREATE = "admin.permissionorganisationtype.create";
        public const string ADMIN_PERMISSIONORGANISATIONTYPE_UPDATE = "admin.permissionorganisationtype.update";
        public const string ADMIN_PERMISSIONORGANISATIONTYPE_REMOVE = "admin.permissionorganisationtype.remove";
        #endregion

        #region Permissionadminuser
        public const string ADMIN_PERMISSIONADMINUSER_INFOS = "admin.permissionadminuser.infos";
        public const string ADMIN_PERMISSIONADMINUSER_DETAILS = "admin.permissionadminuser.details";
        public const string ADMIN_PERMISSIONADMINUSER_CREATE = "admin.permissionadminuser.create";
        public const string ADMIN_PERMISSIONADMINUSER_UPDATE = "admin.permissionadminuser.update";
        public const string ADMIN_PERMISSIONADMINUSER_REMOVE = "admin.permissionadminuser.remove";
        #endregion

        #region OrganisationTypeRole
        public const string ADMIN_ORGANISATION_TYPE_ROLE_INFOS = "admin.organisation-type.role.infos";
        public const string ADMIN_ORGANISATION_TYPE_ROLE_DETAILS = "admin.organisation-type.role.details";
        public const string ADMIN_ORGANISATION_TYPE_ROLE_CREATE = "admin.organisation-type.role.create";
        public const string ADMIN_ORGANISATION_TYPE_ROLE_UPDATE = "admin.organisation-type.role.update";
        public const string ADMIN_ORGANISATION_TYPE_ROLE_REMOVE = "admin.organisation-type.role.remove";
        #endregion

        #region RoleAdmin
        public const string ADMIN_ROLEADMIN_INFOS = "admin.roleadmin.infos";
        public const string ADMIN_ROLEADMIN_DETAILS = "admin.roleadmin.details";
        public const string ADMIN_ROLEADMIN_CREATE = "admin.roleadmin.create";
        public const string ADMIN_ROLEADMIN_UPDATE = "admin.roleadmin.update";
        public const string ADMIN_ROLEADMIN_REMOVE = "admin.roleadmin.remove";
        #endregion

        #region Routes
        public const string ADMIN_ROUTES_INFOS = "admin.routes.infos";
        #endregion

        #region SecuritySettings
        public const string ADMIN_SECURITYSETTINGS_DETAILS = "admin.security-settings.details";
        public const string ADMIN_SECURITYSETTINGS_UPDATE = "admin.security-settings.update";
        #endregion

        #region Translation
        public const string ADMIN_TRANSLATION_INFOS = "admin.translation.infos";
        public const string ADMIN_TRANSLATION_DETAILS = "admin.translation.details";
        public const string ADMIN_TRANSLATION_CREATE = "admin.translation.create";
        public const string ADMIN_TRANSLATION_UPDATE = "admin.translation.update";
        public const string ADMIN_TRANSLATION_REMOVE = "admin.translation.remove";


        public const string ADMIN_APPLICATIONTRANSLATION_INFOS = "admin.application-translation.infos";
        public const string ADMIN_APPLICATIONTRANSLATION_DETAILS = "admin.application-translation.details";
        public const string ADMIN_APPLICATIONTRANSLATION_CREATE = "admin.application-translation.create";
        public const string ADMIN_APPLICATIONTRANSLATION_UPDATE = "admin.application-translation.update";
        public const string ADMIN_APPLICATIONTRANSLATION_REMOVE = "admin.application-translation.remove";
        #endregion

        #region User
        public const string ADMIN_USER_INFOS = "admin.user.infos";
        public const string ADMIN_USER_DETAILS = "admin.user.details";
        public const string ADMIN_USER_CREATE = "admin.user.create";
        public const string ADMIN_USER_UPDATE = "admin.user.update";
        public const string ADMIN_USER_REMOVE = "admin.user.remove";
        public const string ADMIN_USER_SENDEMAIL = "admin.user.send-email";
        #endregion

        #region UserApplication
        public const string ADMIN_USERAPPLICATION_INFOS = "admin.userapplication.infos";
        public const string ADMIN_USERAPPLICATION_DETAILS = "admin.userapplication.details";
        public const string ADMIN_USERAPPLICATION_CREATE = "admin.userapplication.create";
        public const string ADMIN_USERAPPLICATION_UPDATE = "admin.userapplication.update";
        public const string ADMIN_USERAPPLICATION_REMOVE = "admin.userapplication.remove";
        #endregion

        #region UserOrganisation
        public const string ADMIN_USERORGANISATION_INFOS = "admin.userorganisation.infos";
        public const string ADMIN_USERORGANISATION_DETAILS = "admin.userorganisation.details";
        public const string ADMIN_USERORGANISATION_CREATE = "admin.userorganisation.create";
        public const string ADMIN_USERORGANISATION_UPDATE = "admin.userorganisation.update";
        public const string ADMIN_USERORGANISATION_REMOVE = "admin.userorganisation.remove";
        #endregion

        #region Widget
        public const string ADMIN_WIDGET_INFOS = "admin.widget.infos";
        public const string ADMIN_WIDGET_DETAILS = "admin.widget.details";
        public const string ADMIN_WIDGET_CREATE = "admin.widget.create";
        public const string ADMIN_WIDGET_UPDATE = "admin.widget.update";
        public const string ADMIN_WIDGET_REMOVE = "admin.widget.remove";
        #endregion

        #region Widgettemplate
        public const string ADMIN_WIDGETTEMPLATE_INFOS = "admin.widgettemplate.infos";
        public const string ADMIN_WIDGETTEMPLATE_DETAILS = "admin.widgettemplate.details";
        public const string ADMIN_WIDGETTEMPLATE_CREATE = "admin.widgettemplate.create";
        public const string ADMIN_WIDGETTEMPLATE_UPDATE = "admin.widgettemplate.update";
        public const string ADMIN_WIDGETTEMPLATE_REMOVE = "admin.widgettemplate.remove";
        #endregion
    }
}