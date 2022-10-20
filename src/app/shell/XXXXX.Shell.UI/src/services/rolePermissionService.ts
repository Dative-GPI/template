import axios from "axios";
import { buildURL } from "@/tools";
import { NotifyService } from "@/tools/notifyService";
import { ROLE_PERMISSIONS_URL, SERVICES as S } from "@/config";
import { PermissionsFilter, PermissionInfos, PermissionInfosDTO } from "@/domain/models";
import { IExtensionCommunicationService, IRolePermissionService } from "@/interfaces";
import { inject, injectable } from "tsyringe";

@injectable()
export class RolePermissionService extends NotifyService<PermissionInfos, PermissionInfos> implements IRolePermissionService {
    type: string = "rolePermissions";

    constructor(@inject(S.EXTENSIONCOMMUNICATIONSERVICE) service: IExtensionCommunicationService) {
        super(service);
    }

    async getMany(organisationId: string, roleId: string, filter: PermissionsFilter): Promise<PermissionInfos[]> {
        const response = await axios.get(buildURL(ROLE_PERMISSIONS_URL(organisationId, roleId), filter));
        const dto: PermissionInfosDTO[] = response.data;

        const permissions = dto.map(o => new PermissionInfos(o));
        this.notify({
            action: "reset",
            items: permissions.slice(),
            type: this.type,
        });
        return permissions;
    }

    async update(organisationId: string, roleId: string, payload: string[]): Promise<void> {
        await axios.post(ROLE_PERMISSIONS_URL(organisationId, roleId), payload);
    }
}