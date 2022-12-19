export const API_URL = `/api/admin/v1`;
export const CORE_URL = (organisationId: string) => `/api/core/organisations/${encodeURIComponent(organisationId)}`;

export const CURRENT_APPLICATION_URL = `${API_URL}/applications/current`;