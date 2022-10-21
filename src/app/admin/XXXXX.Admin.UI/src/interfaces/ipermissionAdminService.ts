import { PermissionAdminInfos, PermissionAdminFilter, PermissionAdminCategory } from "@/domain/models/permissionAdmins";

export interface IPermissionAdminService {
    getMany(filter?: PermissionAdminFilter): Promise<PermissionAdminInfos[]>;
    getCategories(): Promise<PermissionAdminCategory[]>;
    getCurrent(): Promise<string[]>;
}