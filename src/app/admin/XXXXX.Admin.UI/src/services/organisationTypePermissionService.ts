import axios from "axios";
import { buildURL } from "@/tools";
import { NotifyService } from "@/tools/notifyService";
import { ORGANISATION_TYPE_PERMISSIONS_URL } from "@/config";
import { PermissionsFilter, PermissionInfos, PermissionInfosDTO } from "@/domain/models";
import { IOrganisationTypePermissionService } from "@/interfaces";

export class OrganisationTypePermissionService extends NotifyService<PermissionInfos, PermissionInfos> implements IOrganisationTypePermissionService {

    async getMany(organisationId: string, filter: PermissionsFilter): Promise<PermissionInfos[]> {
        const response = await axios.get(buildURL(ORGANISATION_TYPE_PERMISSIONS_URL(organisationId), filter));
        const dto: PermissionInfosDTO[] = response.data;

        const permissions = dto.map(o => new PermissionInfos(o));
        this.notify({
            action: "reset",
            items: permissions.slice()
        });
        return permissions;
    }

    async update(organisationId: string, payload: string[]): Promise<void> {
        await axios.post(ORGANISATION_TYPE_PERMISSIONS_URL(organisationId), payload);
    }
}