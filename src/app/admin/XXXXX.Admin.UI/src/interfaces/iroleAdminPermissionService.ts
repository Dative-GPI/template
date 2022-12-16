import { PermissionAdminInfos, PermissionAdminFilter } from "@/domain/models/permissionAdmins";

export interface IRoleAdminPermissionService {
    getMany(roleAdminId: string, filter?: PermissionAdminFilter): Promise<PermissionAdminInfos[]>;
    update(roleAdminId: string, payload: string[]): Promise<void>
}