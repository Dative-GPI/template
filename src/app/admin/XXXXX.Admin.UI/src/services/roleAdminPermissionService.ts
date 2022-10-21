import axios from "axios";
import { buildURL } from "@/tools";
import { NotifyService } from "@/tools/notifyService";
import { ROLE_ADMIN_PERMISSIONS_URL, SERVICES as S } from "@/config";
import { PermissionAdminFilter, PermissionAdminInfos, PermissionAdminInfosDTO } from "@/domain/models";
import { IExtensionCommunicationService, IRoleAdminPermissionService } from "@/interfaces";
import { inject, injectable } from "tsyringe";

@injectable()
export class RoleAdminPermissionService extends NotifyService<PermissionAdminInfos> implements IRoleAdminPermissionService {
    type: string = "rolePermissionAdmins";

    constructor(@inject(S.EXTENSIONCOMMUNICATIONSERVICE) service: IExtensionCommunicationService) {
        super(service);
    }

    async getMany(roleAdminId: string, filter: PermissionAdminFilter): Promise<PermissionAdminInfos[]> {
        const response = await axios.get(buildURL(ROLE_ADMIN_PERMISSIONS_URL(roleAdminId), filter));
        const dto: PermissionAdminInfosDTO[] = response.data;

        const permissionadmins = dto.map(o => new PermissionAdminInfos(o));
        this.notify({
            action: "reset",
            items: permissionadmins.slice(),
            type: this.type,
        });
        return permissionadmins;
    }

    async update(roleAdminId: string, payload: string[]): Promise<void> {
        await axios.post(ROLE_ADMIN_PERMISSIONS_URL(roleAdminId), payload);
    }
}