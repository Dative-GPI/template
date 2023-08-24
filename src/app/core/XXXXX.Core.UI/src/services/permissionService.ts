import axios from "axios";

import { IPermissionService } from '@/interfaces';
import { CURRENT_USER_PERMISSIONS_URL, PERMISSION_CATEGORIES_URL } from '@/config';
import { injectable } from "tsyringe";
import { PermissionCategory, PermissionCategoryDTO } from "@/domain/models";

@injectable()
export class PermissionService implements IPermissionService {
	async getCurrent(organisationId: string): Promise<string[]> {
		const response = await axios.get(CURRENT_USER_PERMISSIONS_URL(organisationId));
		const permissions: string[] = response.data;

		return permissions;
	}

	async getCategories(organisationId: string): Promise<PermissionCategory[]> {
		const response = await axios.get(PERMISSION_CATEGORIES_URL(organisationId));
		const dtos: PermissionCategoryDTO[] = response.data;

		const categories = dtos.map(dto => new PermissionCategory(dto));
		return categories;
	}
}