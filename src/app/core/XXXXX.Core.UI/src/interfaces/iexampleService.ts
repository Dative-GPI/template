
import { CreateExampleDTO, ExampleDetails, ExampleInfos, UpdateExampleDTO } from '@/domain/models';
import { INotifyService } from './inotifyService';

export interface IExampleService extends INotifyService<ExampleInfos, ExampleDetails> {
    get(organisationId: string, exampleId: string): Promise<ExampleDetails>;
    getMany(organisationId: string): Promise<ExampleInfos[]>;
    create(organisationId: string, payload: CreateExampleDTO): Promise<ExampleDetails>;
    update(organisationId: string, exampleId: string, payload: UpdateExampleDTO): Promise<ExampleDetails>;
    remove(organisationId: string, exampleId: string): Promise<void>;
}