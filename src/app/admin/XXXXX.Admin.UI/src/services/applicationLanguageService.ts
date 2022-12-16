import axios from "axios";
import _, { DebouncedFunc } from "lodash";

import { Language, LanguageDTO } from "@/domain/models";
import { IApplicationLanguageService } from "@/interfaces";

import { FOUNDATION_APPLICATION_LANGUAGES_URL } from "@/config";

export class ApplicationLanguageService implements IApplicationLanguageService {
    type: string = "ApplicationLanguageService";
    debouncedGetMany: DebouncedFunc<() => Promise<Language[]>>;

    constructor() {
        this.debouncedGetMany = _.debounce(this.getManyRequest, 500, { leading: true });
    }

    async getMany(): Promise<Language[]> {
        const promise = this.debouncedGetMany()
        
        if (!promise) throw new Error();

        return promise.then(l => l.slice());
    }

    async getManyRequest(): Promise<Language[]> {
        return axios.get(FOUNDATION_APPLICATION_LANGUAGES_URL)
            .then(response => {
                const dtos: LanguageDTO[] = response.data;
                return dtos.map(d => new Language(d));
            });
    }

}