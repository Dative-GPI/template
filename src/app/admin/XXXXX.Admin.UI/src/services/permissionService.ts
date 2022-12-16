import axios from "axios";
import { buildURL } from "@/tools";

import {
  PERMISSIONS_CATEGORIES_URL,
  PERMISSIONS_URL,
  SERVICES as S,
} from "@/config";
import {
  PermissionsFilter,
  PermissionInfos,
  PermissionInfosDTO,
  PermissionCategory,
  PermissionCategoryDTO,
} from "@/domain/models";
import { IExtensionCommunicationService, IPermissionService } from "@/interfaces";
import { NotifyService } from "@/tools/notifyService";
import { inject, injectable } from "tsyringe";

@injectable()
export class PermissionService
  extends NotifyService<PermissionInfos, PermissionInfos>
  implements IPermissionService {
  type: string = "permissions";

  constructor(
    @inject(S.EXTENSIONCOMMUNICATIONSERVICE)
    service: IExtensionCommunicationService
  ) {
    super(service);
  }

  async getCategories(): Promise<PermissionCategory[]> {
    const response = await axios.get(PERMISSIONS_CATEGORIES_URL);
    const dtos: PermissionCategoryDTO[] = response.data;
    return dtos.map((c) => new PermissionCategory(c));
  }

  async getMany(filter: PermissionsFilter): Promise<PermissionInfos[]> {
    const response = await axios.get(buildURL(PERMISSIONS_URL, filter));
    const dto: PermissionInfosDTO[] = response.data;

    const organisationTypes = dto.map((o) => new PermissionInfos(o));
    this.notify({
      action: "reset",
      items: organisationTypes.slice(),
      type: this.type,
    });
    return organisationTypes;
  }
}
