

import { ApplicationTranslation, ApplicationTranslationSelector } from '@/domain/models';
import { INotifyService } from './inotifyService';

export interface IApplicationTranslationService extends INotifyService<ApplicationTranslation, ApplicationTranslation> {
    getMany(payload: ApplicationTranslationSelector): Promise<ApplicationTranslation[]>;
}