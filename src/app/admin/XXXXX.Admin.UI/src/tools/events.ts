import _ from "lodash";
import { CollectionChangedEventArgs } from '@/domain/events';

export function onCollectionChanged<TInfos extends { id: string | number }, TDetails extends TInfos>(accessor: () => TInfos[], filter: (el: TInfos) => boolean = (el: TInfos) => true): (ev: CollectionChangedEventArgs<TInfos, TDetails>) => void {
    return (ev: CollectionChangedEventArgs<TInfos, TDetails>) => {
        if (ev.action == "reset") {
            accessor().splice(0, accessor().length, ..._.filter(ev.items, filter));
        }
        else if (ev.action == "delete") {
            for (const id of ev.items) {
                const index = _.findIndex(accessor(), (i: TInfos) => i.id == id);
                if (index > -1) {
                    accessor().splice(index, 1);
                }
            }
        }
        else if (ev.action == "update") {
            const index = _.findIndex(accessor(), (i: TInfos) => i.id == ev.item.id);
            if (index > -1) {
                accessor().splice(index, 1, ev.item);
            } else {
                accessor().push(ev.item);
            }
            accessor().splice(0, accessor().length, ..._.filter(accessor(), filter));
        }
        else if (ev.action == "add") {
            for (const item of _.filter(ev.items, filter)) {
                accessor().push(item);
            }
        }
    }
}

export function autoUpdate<TInfos extends { id: string | number }, TDetails extends TInfos>(equality: (item: TDetails) => boolean, setter: (updated: TDetails) => void): (ev: CollectionChangedEventArgs<TInfos, TDetails>) => void {
    return (ev: CollectionChangedEventArgs<TInfos, TDetails>) => {
        if (ev.action === "update") {
            if (equality(ev.item)) {
                setter(ev.item);
            }
        }
    }
}