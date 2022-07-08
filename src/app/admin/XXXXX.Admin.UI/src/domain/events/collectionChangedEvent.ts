export type CollectionChangedEvent = "add" | "update" | "delete" | "reset" | "all";

export type CollectionChangedEventArgs<TInfos, TDetails> = CollectionGrows<TInfos> | CollectionShrinks | CollectionUpdate<TDetails> | CollectionReset<TInfos>;

interface CollectionGrows<T> {
    id?: string;
    action: "add";
    type: string;
    items: T[];
}

interface CollectionShrinks {
    id?: string;
    action: "delete";
    type: string;
    items: (number | string)[];
}

interface CollectionUpdate<T> {
    id?: string;
    action: "update";
    type: string;
    item: T;
}

interface CollectionReset<T> {
    id?: string;
    action: "reset";
    type: string;
    items: T[];
}