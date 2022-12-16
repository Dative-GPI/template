import { Language } from "@/domain/models";

export interface IApplicationLanguageService {
    getMany(): Promise<Language[]>
}