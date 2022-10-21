import { container } from "tsyringe";

import { SERVICES as S } from "@/config";

import { 
    IExtensionCommunicationService,
    IExampleService,
    IApplicationTranslationService,
    IOrganisationPermissionService,
    IPermissionService,
    IRolePermissionService
} from "@/interfaces";

import { 
    ExtensionCommunicationService,
    ExampleService,
    ApplicationTranslationService,
    OrganisationPermissionService,
    PermissionService,
    RolePermissionService
} from "@/services";

container.registerSingleton<IExampleService>(S.EXAMPLESERVICE, ExampleService);

container.registerSingleton<IExtensionCommunicationService>(S.EXTENSIONCOMMUNICATIONSERVICE, ExtensionCommunicationService);

container.registerSingleton<IPermissionService>(S.PERMISSIONSERVICE, PermissionService);
container.registerSingleton<IApplicationTranslationService>(S.APPLICATIONTRANSLATIONSERVICE, ApplicationTranslationService);
container.registerSingleton<IRolePermissionService>(S.ROLEPERMISSIONSERVICE, RolePermissionService);
container.registerSingleton<IOrganisationPermissionService>(S.ORGANISATIONPERMISSIONSERVICE, OrganisationPermissionService);

export { container };