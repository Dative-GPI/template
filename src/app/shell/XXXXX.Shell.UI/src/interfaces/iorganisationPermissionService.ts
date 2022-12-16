import { PermissionInfos, PermissionsFilter } from "@/domain/models/permissions";

export interface IOrganisationPermissionService {
    getMany(organisationId: string, filter?: PermissionsFilter): Promise<PermissionInfos[]>;
}