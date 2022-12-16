import Ajv, { JTDParser, JTDSchemaType } from "ajv/dist/jtd";
import { ApplicationTranslation } from "./applicationTranslation";
import { Translation } from "./translation";

export interface TranslationRequest {
    messageType: "translation-request",
    translationCode: string;
}

export interface TranslationResponse {
    messageType: "translation-response",
    translation: Translation,
    applicationTranslations: ApplicationTranslation[];
}

export interface UpdateTranslationsRequest {
    messageType: "update-translation-request",
    translationCode: string,
    applicationTranslations: ApplicationTranslation[];
}


export const translationRequestSchema: JTDSchemaType<TranslationRequest> = {
    properties: {
        messageType: { enum: ["translation-request"] },
        translationCode: { type: "string" }
    }
};



export const translationSchema: JTDSchemaType<Translation> = {
    properties: {
        code: { type: "string" },
        value: { type: "string" }
    }
};

export const applicationTranslationSchema: JTDSchemaType<ApplicationTranslation> = {
    properties: {
        languageCode: { type: "string" },
        organisationTypeId: { type: "string", nullable: true },
        translationCode: { type: "string" },
        value: { type: "string" }
    }
};

export const translationResponseSchema: JTDSchemaType<TranslationResponse> = {
    properties: {
        messageType: { enum: ["translation-response"] },
        translation: translationSchema,
        applicationTranslations: { elements: applicationTranslationSchema }
    }
};


export const updateTranslationsRequestSchema: JTDSchemaType<UpdateTranslationsRequest> = {
    properties: {
        messageType: { enum: ["update-translation-request"] },
        translationCode: { type: "string" },
        applicationTranslations: { elements: applicationTranslationSchema }
    }
};