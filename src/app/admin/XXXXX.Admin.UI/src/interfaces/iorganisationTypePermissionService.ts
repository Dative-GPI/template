import { PermissionInfos, PermissionsFilter } from "@/domain/models/permissions";

export interface IOrganisationTypePermissionService {
    getMany(organisationId: string, filter?: PermissionsFilter): Promise<PermissionInfos[]>;
    update(organisationId: string, payload: string[]): Promise<void>
}