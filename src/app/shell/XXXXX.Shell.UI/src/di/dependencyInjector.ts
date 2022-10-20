import { container } from "tsyringe";

import { SERVICES as S } from "@/config";

import { 
    IExtensionCommunicationService,
    IExempleService,
    IApplicationTranslationService,
    IOrganisationPermissionService,
    IPermissionService,
    IRolePermissionService
} from "@/interfaces";

import { 
    ExtensionCommunicationService,
    ExempleService,
    ApplicationTranslationService,
    OrganisationPermissionService,
    PermissionService,
    RolePermissionService
} from "@/services";

container.registerSingleton<IExempleService>(S.EXEMPLESERVICE, ExempleService);

container.registerSingleton<IExtensionCommunicationService>(S.EXTENSIONCOMMUNICATIONSERVICE, ExtensionCommunicationService);

container.registerSingleton<IPermissionService>(S.PERMISSIONSERVICE, PermissionService);
container.registerSingleton<IApplicationTranslationService>(S.APPLICATIONTRANSLATIONSERVICE, ApplicationTranslationService);
container.registerSingleton<IRolePermissionService>(S.ROLEPERMISSIONSERVICE, RolePermissionService);
container.registerSingleton<IOrganisationPermissionService>(S.ORGANISATIONPERMISSIONSERVICE, OrganisationPermissionService);

export { container };