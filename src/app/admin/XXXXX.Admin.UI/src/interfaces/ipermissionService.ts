import { PermissionInfos, PermissionsFilter, PermissionCategory } from "@/domain/models/permissions";

export interface IPermissionService {
    getMany(filter?: PermissionsFilter): Promise<PermissionInfos[]>
    getCategories(): Promise<PermissionCategory[]>
}