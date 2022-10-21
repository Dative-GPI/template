import { API_URL } from "./application";

export const APPLICATION_LANGUAGES_URL = "/api/core/admin/v1/application-languages";

export const TRANSLATIONS_URL = `${API_URL}/translations`;
export const APPLICATION_TRANSLATIONS_URL = `${API_URL}/application-translations`;
export const CURRENT_USER_TRANSLATIONS_URL = `/api/translations`;

export const UPDATE_TRANSLATION_DRAWER_URL = (translationCode: string) => `/translations/${translationCode}/drawer`;
export const IMPORT_TRANSLATIONS_DRAWER_URL = `/translations/import-drawer`;
