import axios from "axios";

import { Translation, TranslationDTO } from "@/domain/models";
import { ITranslationService } from "@/interfaces";

import { TRANSLATIONS_URL } from "@/config";

export class TranslationService implements ITranslationService {
    type: string = "TranslationService";

    async getMany(): Promise<Translation[]> {
        const response = await axios.get(TRANSLATIONS_URL);
        const dtos: TranslationDTO[] = response.data;

        const results = dtos.map(d => new Translation(d));
        return results;
    }
}