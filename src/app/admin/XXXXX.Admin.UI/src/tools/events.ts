import _ from "lodash";
import { CollectionChangedEventArgs } from "@/domain/events";

export function onCollectionChanged<
  T extends { id: string | number },
  TDetails extends T
>(
  accessor: () => T[],
  filter: (el: T) => boolean = (el: T) => true
): (ev: CollectionChangedEventArgs<T>) => void {
  return (ev: CollectionChangedEventArgs<T>) => {
    if (ev.action == "reset") {
      accessor().splice(0, accessor().length, ..._.filter(ev.items, filter));
    } else if (ev.action == "delete") {
      for (const id of ev.items) {
        const index = _.findIndex(accessor(), (i) => i.id == id);
        if (index > -1) {
          accessor().splice(index, 1);
        }
      }
    } else if (ev.action == "update") {
      for (const el of ev.items) {
        const index = _.findIndex(accessor(), (i) => i.id == el.id);
        if (index > -1) {
          accessor().splice(index, 1, el);
        } else {
          accessor().push(el);
        }
      }
      accessor().splice(0, accessor().length, ..._.filter(accessor(), filter));
    } else if (ev.action == "add") {
      for (const item of _.filter(ev.items, filter)) {
        accessor().push(item);
      }
    }
  };
}

export function autoUpdate<T extends { id: string | number }>(equality : (item: T) => boolean, setter: (updated: T) => void): (ev: CollectionChangedEventArgs<T>) => void {
    return (ev: CollectionChangedEventArgs<T>) => {
        if (ev.action === "update") {
            const index = _.findIndex(ev.items, i => equality(i));
            if (index > -1) {
                setter(ev.items[index]);
            }
        }
    }
}

export function autoUpdateArray<T extends { id: string | number }>(equality : (items: T[]) => boolean, setter: (updated: T[]) => void): (ev: CollectionChangedEventArgs<T>) => void {
    return (ev: CollectionChangedEventArgs<T>) => {
        if (ev.action === "update") {
            setter(ev.items);
        }
    }
}

export function autoDelete<T extends { id: string | number }>(equality: (item: string | number) => boolean, callback: () => void): (ev: CollectionChangedEventArgs<T>) => void {
    return (ev: CollectionChangedEventArgs<T>) => {
        if (ev.action === "delete") {
            const index = _.findIndex(ev.items, i => equality(i));
            if (index > -1) {
                callback();
            }
        }
    }
}