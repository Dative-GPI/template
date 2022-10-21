export const API_URL = `/api/v1`;
export const BASE_ID_URL = (organisationId: string) => `${API_URL}/${encodeURIComponent(organisationId)}`;

export const CURRENT_APPLICATION_URL = `${API_URL}/applications/current`;