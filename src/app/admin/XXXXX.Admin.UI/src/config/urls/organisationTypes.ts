export const ORGANISATION_TYPES_URL = "/api/admin/v1/organisation-types";

export const ORGANISATION_TYPE_URL = (id: string) => `${ORGANISATION_TYPES_URL}/${encodeURIComponent(id)}`;

export const ORGANISATION_TYPE_PERMISSIONS_URL = (id: string) => ` ${ORGANISATION_TYPE_URL(id)}/permissions`;