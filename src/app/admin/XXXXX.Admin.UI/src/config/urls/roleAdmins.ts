import { API_URL } from "./application";

export const ROLES_ADMIN_URL = `${API_URL}/roles-admin`;

export const ROLE_ADMIN_URL = (id: string) => `${ROLES_ADMIN_URL}/${encodeURIComponent(id)}`;

export const ROLE_ADMIN_PERMISSIONS_URL = (id: string) => ` ${ROLE_ADMIN_URL(id)}/permissions`;