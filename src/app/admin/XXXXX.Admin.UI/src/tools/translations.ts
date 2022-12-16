import { ApplicationTranslation, Language, OrganisationTypeInfos, Translation } from "@/domain/models";
import _ from "lodash";

export function buildTranslationCSVContent(
    translations: Translation[],
    applicationTranslations: ApplicationTranslation[],
    languages: Language[],
    organisationTypes: OrganisationTypeInfos[],
    separator: string
): string {
    let content = "";
    let applicationTranslationDict = buildApplicationTranslationDict(applicationTranslations);

    for (const translation of translations) {
        content += (translation.code + separator);
        content += (translation.value + separator);

        for (const language of languages) {
            content += ((applicationTranslationDict[translation.code]?.[language.code]?.["default"] ?? "") + separator);

            for (const orgType of organisationTypes) {
                content += ((applicationTranslationDict[translation.code]?.[language.code]?.[orgType.id] ?? "") + separator);
            }
        }

        content += '\n';
    }

    return content;
}

function buildApplicationTranslationDict(applicationTranslations: ApplicationTranslation[]): TranslationDictionary {
    const dictionary: TranslationDictionary = {};

    for (const appTranslation of applicationTranslations) {
        if (!dictionary[appTranslation.translationCode]) {
            dictionary[appTranslation.translationCode] = {};
        }

        if (!dictionary[appTranslation.translationCode][appTranslation.languageCode]) {
            dictionary[appTranslation.translationCode][appTranslation.languageCode] = {};
        }

        dictionary[appTranslation.translationCode][appTranslation.languageCode][appTranslation.organisationTypeId ?? "default"] = appTranslation.value;
    }

    return dictionary;
}


interface TranslationDictionary {
    [translationCode: string]: LanguageTranslationDictionary;
}

interface LanguageTranslationDictionary {
    [languageCode: string]: OrganisationTypeTranslationDictionary;
}

interface OrganisationTypeTranslationDictionary {
    [organisationTypeId: string]: string;
}