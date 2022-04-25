import { PermissionInfos, PermissionsFilter } from "@/domain/models/permissions";

export interface IRolePermissionService {
    getMany(roleId: string, filter?: PermissionsFilter): Promise<PermissionInfos[]>;
    update(roleId: string, payload: string[]): Promise<void>
}