export const ROLES_URL = "/api/admin/v1/roles";

export const ROLE_URL = (id: string) => `${ROLES_URL}/${encodeURIComponent(id)}`;

export const ROLE_PERMISSIONS_URL = (id: string) => ` ${ROLE_URL(id)}/permissions`;