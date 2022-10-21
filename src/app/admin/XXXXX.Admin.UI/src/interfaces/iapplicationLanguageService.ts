import { Language } from "@/domain/models";
import { INotifyService } from ".";

export interface IApplicationLanguageService extends INotifyService<Language> {
    getMany(): Promise<Language[]>
}