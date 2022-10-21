import { ApplicationTranslation, UpdateApplicationTranslation } from "@/domain/models";
import { INotifyService } from ".";

export interface IApplicationTranslationService extends INotifyService<ApplicationTranslation, ApplicationTranslation> {
    getMany(): Promise<ApplicationTranslation[]>;
    getCurrent(): Promise<ApplicationTranslation[]>;
    update(payload: UpdateApplicationTranslation[]): Promise<void>;
}