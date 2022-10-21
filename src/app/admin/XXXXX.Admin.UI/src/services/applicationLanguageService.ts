import axios from "axios";
import _, { DebouncedFunc } from "lodash";
import { NotifyService } from "@/tools/notifyService";

import { Language, LanguageDTO } from "@/domain/models";
import { IApplicationLanguageService, IExtensionCommunicationService } from "@/interfaces";

import { APPLICATION_LANGUAGES_URL, SERVICES as S } from "@/config";
import { inject, injectable } from "tsyringe";

@injectable()
export class ApplicationLanguageService extends NotifyService<Language> implements IApplicationLanguageService {
    type: string = "ApplicationLanguageService";
    debouncedGetMany: DebouncedFunc<() => Promise<Language[]>>;

    constructor(
        @inject(S.EXTENSIONCOMMUNICATIONSERVICE)
        service: IExtensionCommunicationService
    ) {
        super(service);
        this.debouncedGetMany = _.debounce(this.getManyRequest, 500, { leading: true });
    }

    async getMany(): Promise<Language[]> {
        const promise = this.debouncedGetMany()
        
        if (!promise) throw new Error();

        return promise.then(l => l.slice());
    }

    async getManyRequest(): Promise<Language[]> {
        return axios.get(APPLICATION_LANGUAGES_URL)
            .then(response => {
                const dtos: LanguageDTO[] = response.data;
                return dtos.map(d => new Language(d));
            });
    }

}