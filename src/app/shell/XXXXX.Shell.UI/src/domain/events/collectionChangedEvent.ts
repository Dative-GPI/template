export type CollectionChangedEvent = "add" | "update" | "delete" | "reset" | "all";

export type CollectionChangedEventArgs<TInfos, TDetails> = CollectionGrows<TInfos> | CollectionShrinks | CollectionUpdate<TDetails> | CollectionReset<TInfos>;

interface CollectionGrows<T> {
    action: "add";
    items: T[];
}

interface CollectionShrinks {
    action: "delete";
    items: (number | string)[];
}

interface CollectionUpdate<T> {
    action: "update";
    item: T;
}

interface CollectionReset<T> {
    action: "reset";
    items: T[];
}