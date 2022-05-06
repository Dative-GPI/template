
import { CreateExempleDTO, ExempleDetails, ExempleInfos, UpdateExempleDTO } from '@/domain/models';
import { INotifyService } from './inotifyService';

export interface IExempleService extends INotifyService<ExempleInfos, ExempleDetails> {
    get(organisationId: string, exempleId: string): Promise<ExempleDetails>;
    getMany(organisationId: string): Promise<ExempleInfos[]>;
    create(organisationId: string, payload: CreateExempleDTO): Promise<ExempleDetails>;
    update(organisationId: string, exempleId: string, payload: UpdateExempleDTO): Promise<ExempleDetails>;
    remove(organisationId: string, exempleId: string): Promise<void>;
}