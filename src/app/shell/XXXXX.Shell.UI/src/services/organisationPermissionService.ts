import axios from "axios";
import { buildURL } from "@/tools";
import { NotifyService } from "@/tools/notifyService";
import { PERMISSIONS_URL, SERVICES as S } from "@/config";
import {
  PermissionsFilter,
  PermissionInfos,
  PermissionInfosDTO,
} from "@/domain/models";
import {
  IExtensionCommunicationService,
  IOrganisationPermissionService,
} from "@/interfaces";
import { inject, injectable } from "tsyringe";

@injectable()
export class OrganisationPermissionService
  extends NotifyService<PermissionInfos, PermissionInfos>
  implements IOrganisationPermissionService {

  type: string = "organisationPermission";

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
      buildURL(PERMISSIONS_URL(organisationId), filter)
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
}
