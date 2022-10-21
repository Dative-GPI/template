import { Translation } from "@/domain/models";
import { INotifyService } from ".";

export interface ITranslationService extends INotifyService<Translation> {
    getMany(): Promise<Translation[]>;
}