import { SERVICES as S } from "@/config"
import { IApplicationLanguageService, IApplicationTranslationService, IExampleService, IExtensionCommunicationService, IOrganisationTypePermissionService, IPermissionAdminService, IPermissionService, IRoleAdminPermissionService, IRolePermissionService, ITranslationService } from "@/interfaces";
import { ApplicationLanguageService, ApplicationTranslationService, ExampleService, ExtensionCommunicationService, OrganisationTypePermissionService, PermissionAdminService, PermissionService, RoleAdminPermissionService, RolePermissionService, TranslationService } from "@/services";
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


container.registerSingleton<IExampleService>(S.EXAMPLESERVICE, ExampleService);
