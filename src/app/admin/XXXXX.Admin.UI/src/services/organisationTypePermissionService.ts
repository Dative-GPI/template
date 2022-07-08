import axios from "axios";
import { buildURL } from "@/tools";
import { NotifyService } from "@/tools/notifyService";
import { ORGANISATION_TYPE_PERMISSIONS_URL, SERVICES as S } from "@/config";
import {
  PermissionsFilter,
  PermissionInfos,
  PermissionInfosDTO,
} from "@/domain/models";
import {
  IExtensionCommunicationService,
  IOrganisationTypePermissionService,
} from "@/interfaces";
import { inject, injectable } from "tsyringe";

@injectable()
export class OrganisationTypePermissionService
  extends NotifyService<PermissionInfos, PermissionInfos>
  implements IOrganisationTypePermissionService {
  type: string = "organisationTypePermission";

  constructor(
    @inject(S.EXTENSIONCOMMUNICATIONSERVICE)
    service: IExtensionCommunicationService
  ) {
    super(service);
  }

  async getMany(
    organisationId: string,
    filter: PermissionsFilter
  ): Promise<PermissionInfos[]> {
    const response = await axios.get(
      buildURL(ORGANISATION_TYPE_PERMISSIONS_URL(organisationId), filter)
    );
    const dto: PermissionInfosDTO[] = response.data;

    const permissions = dto.map((o) => new PermissionInfos(o));
    this.notify({
      action: "reset",
      items: permissions.slice(),
      type: this.type,
    });
    return permissions;
  }

  async update(organisationId: string, payload: string[]): Promise<void> {
    await axios.post(
      ORGANISATION_TYPE_PERMISSIONS_URL(organisationId),
      payload
    );
  }
}
