import { API_URL } from "./application";

export const ORGANISATION_TYPES_URL = `${API_URL}/organisation-types`;
export const FOUNDATION_ORGANISATION_TYPES_URL = `/api/core/admin/v1/organisationTypes`;

export const ORGANISATION_TYPE_URL = (id: string) => `${ORGANISATION_TYPES_URL}/${encodeURIComponent(id)}`;

export const ORGANISATION_TYPE_PERMISSIONS_URL = (id: string) => ` ${ORGANISATION_TYPE_URL(id)}/permissions`;