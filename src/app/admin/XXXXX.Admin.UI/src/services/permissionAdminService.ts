import axios from "axios";
import { buildURL } from "@/tools";

import {
  CURRENT_USER_PERMISSIONS_ADMIN_URL,
  PERMISSIONS_ADMIN_CATEGORIES_URL,
  PERMISSIONS_ADMIN_URL,
  SERVICES as S,
} from "@/config";
import {
  PermissionAdminFilter,
  PermissionAdminInfos,
  PermissionAdminInfosDTO,
  PermissionAdminCategory,
  PermissionAdminCategoryDTO,
} from "@/domain/models";
import { IExtensionCommunicationService, IPermissionAdminService } from "@/interfaces";
import { NotifyService } from "@/tools/notifyService";
import { inject, injectable } from "tsyringe";

@injectable()
export class PermissionAdminService
  extends NotifyService<PermissionAdminInfos>
  implements IPermissionAdminService {
  type: string = "permissionadmins";

  constructor(
    @inject(S.EXTENSIONCOMMUNICATIONSERVICE)
    service: IExtensionCommunicationService
  ) {
    super(service);
  }

  async getCategories(): Promise<PermissionAdminCategory[]> {
    const response = await axios.get(PERMISSIONS_ADMIN_CATEGORIES_URL);
    const dtos: PermissionAdminCategoryDTO[] = response.data;
    return dtos.map((c) => new PermissionAdminCategory(c));
  }

  async getMany(filter: PermissionAdminFilter): Promise<PermissionAdminInfos[]> {
    const response = await axios.get(buildURL(PERMISSIONS_ADMIN_URL, filter));
    const dto: PermissionAdminInfosDTO[] = response.data;

    const organisationTypes = dto.map((o) => new PermissionAdminInfos(o));
    this.notify({
      action: "reset",
      items: organisationTypes.slice(),
      type: this.type,
    });
    return organisationTypes;
  }

	async getCurrent(): Promise<string[]> {
		const response = await axios.get(CURRENT_USER_PERMISSIONS_ADMIN_URL);
		const permissions: string[] = response.data;

		return permissions;
	}
}
