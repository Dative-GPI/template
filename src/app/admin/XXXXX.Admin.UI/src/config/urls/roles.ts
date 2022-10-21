import { API_URL } from "./application";

export const ROLES_URL = `${API_URL}/roles`;

export const ROLE_URL = (id: string) => `${ROLES_URL}/${encodeURIComponent(id)}`;

export const ROLE_PERMISSIONS_URL = (id: string) => ` ${ROLE_URL(id)}/permissions`;