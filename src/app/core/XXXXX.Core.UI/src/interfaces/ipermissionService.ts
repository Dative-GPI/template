import { PermissionCategory } from "@/domain/models";


export interface IPermissionService {
    getCurrent(organisationId: string): Promise<string[]>;
    getCategories(organisationId: string): Promise<PermissionCategory[]>;
}