import { SERVICES as S } from "@/config"
import { IOrganisationTypePermissionService, IPermissionService } from "@/interfaces";
import { OrganisationTypePermissionService, PermissionService } from "@/services";
import { container } from "tsyringe";

export { container };

container.registerSingleton<IPermissionService>(S.PERMISSIONSERVICE, PermissionService);
container.registerSingleton<IOrganisationTypePermissionService>(S.ORGANISATIONTYPEPERMISSIONSERVICE, OrganisationTypePermissionService);