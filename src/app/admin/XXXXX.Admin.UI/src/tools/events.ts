import _ from "lodash";
import { CollectionChangedEventArgs } from "@/domain/events";

export function onCollectionChanged<TInfos extends { id: string | number; }, TDetails extends TInfos>(
  accessor: () => TInfos[],
  filter: (el: TInfos) => boolean = (el: TInfos) => true
): (ev: CollectionChangedEventArgs<TInfos, TDetails>) => void {

  return (ev: CollectionChangedEventArgs<TInfos, TDetails>) => {
    switch (ev.action) {
      case "add":
        return onCollectionAdd(accessor, filter)(ev);
      case "delete":
        return onCollectionDelete(accessor, filter)(ev);
      case "reset":
        return onCollectionReset(accessor, filter)(ev);
      case "update":
        return onCollectionUpdate(accessor, filter)(ev);
    }
  }
}

function onCollectionReset<TInfos extends { id: string | number; }, TDetails extends TInfos>(
  accessor: () => TInfos[],
  filter: (el: TInfos) => boolean = (el: TInfos) => true
): (ev: CollectionChangedEventArgs<TInfos, TDetails>) => void {

  return (ev: CollectionChangedEventArgs<TInfos, TDetails>) => {
    if (ev.action == "reset") {
      accessor().splice(0, accessor().length, ..._.filter(ev.items, filter));
    }
  };
}

function onCollectionDelete<TInfos extends { id: string | number; }, TDetails extends TInfos>(
  accessor: () => TInfos[],
  filter: (el: TInfos) => boolean = (el: TInfos) => true
): (ev: CollectionChangedEventArgs<TInfos, TDetails>) => void {

  return (ev: CollectionChangedEventArgs<TInfos, TDetails>) => {
    if (ev.action == "delete") {
      const idToCurrentObject = new Map<string | number, { value: TInfos, index: number }>();

      for (let i = accessor().length - 1; i >= 0; i--) { // Reverse loop for efficiency
        const element = accessor()[i];
        idToCurrentObject.set(element.id, { value: element, index: i });
      }

      for (const id of (ev.items)) {
        if (idToCurrentObject.has(id)) {
          accessor().splice(idToCurrentObject.get(id)!.index, 1);
        }
      }
    }
  };
}

function onCollectionUpdate<TInfos extends { id: string | number; }, TDetails extends TInfos>(
  accessor: () => TInfos[],
  filter: (el: TInfos) => boolean = (el: TInfos) => true
): (ev: CollectionChangedEventArgs<TInfos, TDetails>) => void {

  return (ev: CollectionChangedEventArgs<TInfos, TDetails>) => {
    if (ev.action == "update") {
      const index = _.findIndex(accessor(), (i) => i.id == ev.item.id);

      if (index > -1) {
        accessor().splice(index, 1, ev.item);
      } else {
        accessor().push(ev.item);
      }

      accessor().splice(0, accessor().length, ..._.filter(accessor(), filter));
    }
  };
}

function onCollectionAdd<TInfos extends { id: string | number; }, TDetails extends TInfos>(
  accessor: () => TInfos[],
  filter: (el: TInfos) => boolean = (el: TInfos) => true
): (ev: CollectionChangedEventArgs<TInfos, TDetails>) => void {

  return (ev: CollectionChangedEventArgs<TInfos, TDetails>) => {
    if (ev.action == "add") {
      for (const item of _.filter(ev.items, filter)) {
        accessor().push(item);
      }
    }
  };
}

export function autoUpdate<T extends { id: string | number; }>(
  equality: (item: T) => boolean, 
  setter: (updated: T) => void
): (ev: CollectionChangedEventArgs<T, T>) => void {
  
  return (ev: CollectionChangedEventArgs<T, T>) => {
    if (ev.action === "update") {
      if (equality(ev.item)) {
        setter(ev.item);
      }
    }
  };
}

export function autoUpdateArray<T extends { id: string | number; }>(
  equality: (items: T[]) => boolean, 
  setter: (updated: T[]) => void
): (ev: CollectionChangedEventArgs<T, T>) => void {

  return (ev: CollectionChangedEventArgs<T, T>) => {
    if (ev.action === "reset") {
      setter(ev.items);
    }
  };
}

export function autoDelete<T extends { id: string | number; }>(
  equality: (item: string | number) => boolean, 
  callback: () => void
): (ev: CollectionChangedEventArgs<T, T>) => void {

  return (ev: CollectionChangedEventArgs<T, T>) => {
    if (ev.action === "delete") {
      const index = _.findIndex(ev.items, i => equality(i));
      if (index > -1) {
        callback();
      }
    }
  };
}