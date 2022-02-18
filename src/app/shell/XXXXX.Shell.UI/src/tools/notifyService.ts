import _ from "lodash";
import { INotifyService } from '@/interfaces';
import { CollectionChangedEvent, CollectionChangedEventArgs } from '@/domain/events';

export abstract class NotifyService<TInfos, TDetails extends TInfos> implements INotifyService<TInfos, TDetails> {

    // eventQueue: IEventQueue;
    counter = 0;

    // constructor(eventQueue: IEventQueue)
    // {
    //     this.eventQueue = eventQueue;
    // }

    subscribers: Subscriber<TInfos, TDetails>[] = [];

    subscribe(event: CollectionChangedEvent, callback: (ev: CollectionChangedEventArgs<TInfos, TDetails>) => void): number {
        this.counter++;
        this.subscribers.push({
            ev: event,
            callback: callback,
            id: this.counter
        })
        return this.counter;
    }

    unsubscribe(id: number): void {
        const index = _.findIndex(this.subscribers, s => s.id == id);
        if (index != -1) {
            this.subscribers.splice(index, 1);
        }
    }

    notify(event: CollectionChangedEventArgs<TInfos, TDetails>) {
        _(this.subscribers)
            .filter(s => s.ev === event.action || s.ev == "all")
            .forEach(s => {
                try {
                    s.callback(event)
                } catch (error) {
                    console.error(error);
                }
            })
    }
}

interface Subscriber<TInfos, TDetails> {
    id: number;
    ev: CollectionChangedEvent;
    callback: (arg: CollectionChangedEventArgs<TInfos, TDetails>) => void;
}