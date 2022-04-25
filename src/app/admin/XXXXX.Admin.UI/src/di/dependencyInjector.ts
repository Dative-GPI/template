import { SERVICES as S } from "@/config"
import { IOrganisationTypePermissionService, IPermissionService, IRolePermissionService } from "@/interfaces";
import { OrganisationTypePermissionService, PermissionService } from "@/services";
import { RolePermissionService } from "@/services/rolePermissionService";
import { container } from "tsyringe";

export { container };

container.registerSingleton<IPermissionService>(S.PERMISSIONSERVICE, PermissionService);
container.registerSingleton<IOrganisationTypePermissionService>(S.ORGANISATIONTYPEPERMISSIONSERVICE, OrganisationTypePermissionService);
container.registerSingleton<IRolePermissionService>(S.ROLEPERMISSIONSERICE, RolePermissionService);