import axios from "axios";
import { NotifyService } from "@/tools/notifyService";

import { Translation, TranslationDTO } from "@/domain/models";
import { IExtensionCommunicationService, ITranslationService } from "@/interfaces";

import { SERVICES as S, TRANSLATIONS_URL } from "@/config";
import { inject, injectable } from "tsyringe";

@injectable()
export class TranslationService extends NotifyService<Translation> implements ITranslationService {
    type: string = "TranslationService";

    constructor(
        @inject(S.EXTENSIONCOMMUNICATIONSERVICE)
        service: IExtensionCommunicationService
    ) {
        super(service);
    }

    async getMany(): Promise<Translation[]> {
        const response = await axios.get(TRANSLATIONS_URL);
        const dtos: TranslationDTO[] = response.data;

        const results = dtos.map(d => new Translation(d));
        return results;
    }
}