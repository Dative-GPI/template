import { SERVICES as S } from "@/config"
import { IApplicationLanguageService, IApplicationTranslationService, IExtensionCommunicationService, IOrganisationTypePermissionService, IPermissionAdminService, IPermissionService, IRoleAdminPermissionService, IRolePermissionService, ITranslationService } from "@/interfaces";
import { ApplicationLanguageService, ApplicationTranslationService, ExtensionCommunicationService, OrganisationTypePermissionService, PermissionAdminService, PermissionService, RoleAdminPermissionService, TranslationService } from "@/services";
import { RolePermissionService } from "@/services/rolePermissionService";
import { container } from "tsyringe";

export { container };

container.registerSingleton<IApplicationLanguageService>(S.APPLICATIONLANGUAGESERVICE, ApplicationLanguageService);
container.registerSingleton<IExtensionCommunicationService>(S.EXTENSIONCOMMUNICATIONSERVICE, ExtensionCommunicationService);

container.registerSingleton<IPermissionService>(S.PERMISSIONSERVICE, PermissionService);
container.registerSingleton<IOrganisationTypePermissionService>(S.ORGANISATIONTYPEPERMISSIONSERVICE, OrganisationTypePermissionService);
container.registerSingleton<IRolePermissionService>(S.ROLEPERMISSIONSERVICE, RolePermissionService);
container.registerSingleton<IPermissionAdminService>(S.PERMISSIONADMINSERVICE, PermissionAdminService);
container.registerSingleton<IRoleAdminPermissionService>(S.ROLEADMINPERMISSIONSERVICE, RoleAdminPermissionService);

container.registerSingleton<IApplicationTranslationService>(S.APPLICATIONTRANSLATIONSERVICE, ApplicationTranslationService);
container.registerSingleton<ITranslationService>(S.TRANSLATIONSERVICE, TranslationService);