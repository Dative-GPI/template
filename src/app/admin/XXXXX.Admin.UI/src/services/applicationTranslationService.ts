import axios from "axios";
import { NotifyService } from "@/tools/notifyService";

import { ApplicationTranslation, ApplicationTranslationDTO, UpdateApplicationTranslation } from "@/domain/models";
import { IApplicationTranslationService, IExtensionCommunicationService } from "@/interfaces";

import { APPLICATION_TRANSLATIONS_URL, CURRENT_USER_TRANSLATIONS_URL, SERVICES as S } from "@/config";
import { inject, injectable } from "tsyringe";
import { buildURL } from "@/tools";

@injectable()
export class ApplicationTranslationService extends NotifyService<ApplicationTranslation> implements IApplicationTranslationService {
    type: string = "ApplicationTranslationService";

    constructor(
        @inject(S.EXTENSIONCOMMUNICATIONSERVICE)
        service: IExtensionCommunicationService
    ) {
        super(service);
    }

    async getMany(): Promise<ApplicationTranslation[]> {
        const response = await axios.get(APPLICATION_TRANSLATIONS_URL);
        const dtos: ApplicationTranslationDTO[] = response.data;

        const results = dtos.map(d => new ApplicationTranslation(d));
        return results;
    }

    async getCurrent(): Promise<ApplicationTranslation[]> {
        const response = await axios.get(buildURL(CURRENT_USER_TRANSLATIONS_URL));
        const dtos: ApplicationTranslationDTO[] = response.data;

        const results = dtos.map(d => new ApplicationTranslation(d));
        return results;
    }

    async update(payload: UpdateApplicationTranslation[]): Promise<void> {
        await axios.post(APPLICATION_TRANSLATIONS_URL, payload);

        this.notifyAll({
            action: "update",
            type: this.type,
            items: payload.map(t => new ApplicationTranslation(t))
        });
    }
}