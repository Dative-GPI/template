import { PermissionInfos, PermissionsFilter } from "@/domain/models/permissions";

export interface IRolePermissionService {
    getMany(organisationId: string, roleId: string, filter?: PermissionsFilter): Promise<PermissionInfos[]>;
    update(organisationId: string, roleId: string, payload: string[]): Promise<void>;
}