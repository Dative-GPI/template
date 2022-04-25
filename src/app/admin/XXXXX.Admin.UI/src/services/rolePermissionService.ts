import axios from "axios";
import { buildURL } from "@/tools";
import { NotifyService } from "@/tools/notifyService";
import { ROLE_PERMISSIONS_URL } from "@/config";
import { PermissionsFilter, PermissionInfos, PermissionInfosDTO } from "@/domain/models";
import { IRolePermissionService } from "@/interfaces";

export class RolePermissionService extends NotifyService<PermissionInfos, PermissionInfos> implements IRolePermissionService {

    async getMany(roleId: string, filter: PermissionsFilter): Promise<PermissionInfos[]> {
        const response = await axios.get(buildURL(ROLE_PERMISSIONS_URL(roleId), filter));
        const dto: PermissionInfosDTO[] = response.data;

        const permissions = dto.map(o => new PermissionInfos(o));
        this.notify({
            action: "reset",
            items: permissions.slice()
        });
        return permissions;
    }

    async update(roleId: string, payload: string[]): Promise<void> {
        await axios.post(ROLE_PERMISSIONS_URL(roleId), payload);
    }
}