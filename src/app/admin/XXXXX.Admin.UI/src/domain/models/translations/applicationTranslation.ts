export class ApplicationTranslation {
    translationCode: string;
    languageCode: string;
    organisationTypeId: string | null;
    value: string;

    constructor(params: ApplicationTranslationDTO) {
        this.translationCode = params.translationCode
        this.languageCode = params.languageCode;
        this.organisationTypeId = params.organisationTypeId;
        this.value = params.value;
    }
}

export interface ApplicationTranslationDTO {
    translationCode: string;
    languageCode: string;
    organisationTypeId: string | null;
    value: string;
}

export interface UpdateApplicationTranslation {
    translationCode: string;
    languageCode: string;
    organisationTypeId: string | null;
    value: string;
}

export interface ApplicationTranslationsFilter {
    translationCode?: string;
    prefix?: string;
}