import { CollectionChangedEvent, CollectionChangedEventArgs } from '@/domain/events';

export interface INotifyService<TInfos, TDetails extends TInfos> {
    subscribe(event: CollectionChangedEvent, callback: (ev: CollectionChangedEventArgs<TInfos, TDetails>) => void): number;
    unsubscribe(id: number): void;
}