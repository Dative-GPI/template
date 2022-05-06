import _, { uniqueId } from "lodash";
import Ajv from "ajv";

import { IExtensionCommunicationService, INotifyService } from "@/interfaces";
import {
  CollectionChangedEvent,
  CollectionChangedEventArgs,
} from "@/domain/events";

export abstract class NotifyService<TInfos, TDetails extends TInfos>
  implements INotifyService<TInfos, TDetails> {
  abstract type: string;
  // eventQueue: IEventQueue;
  counter = 0;
  ajv: Ajv;
  sent: string[] = []

  // constructor(eventQueue: IEventQueue)
  // {
  //     this.eventQueue = eventQueue;
  // }

  extensionCommunicationService: IExtensionCommunicationService;

  constructor(service: IExtensionCommunicationService) {
    this.extensionCommunicationService = service;
    this.ajv = new Ajv();

    const schema = {
      type: "object",
      properties: {
        action: { type: "string" },
        type: { type: "string" },
        items: { type: "array" },
        id: { type: "string" }
      },
      required: ["action", "type", "items"]
    }

    service.subscribeUnsafe<CollectionChangedEventArgs<TInfos, TDetails>>(
      location.href,
      this.notify.bind(this),
      this.ajv.compile(schema)
    );
  }

  subscribers: Subscriber<TInfos, TDetails>[] = [];

  subscribe(
    event: CollectionChangedEvent,
    callback: (ev: CollectionChangedEventArgs<TInfos, TDetails>) => void
  ): number {
    this.counter++;
    this.subscribers.push({
      ev: event,
      callback: callback,
      id: this.counter,
    });
    return this.counter;
  }

  unsubscribe(id: number): void {
    const index = _.findIndex(this.subscribers, (s) => s.id == id);
    if (index != -1) {
      this.subscribers.splice(index, 1);
    }
  }
  
  notify(event: CollectionChangedEventArgs<TInfos, TDetails>) {
    var index;
    if(event.id && (index = this.sent.findIndex(s => s == event.id)) >= 0){
      this.sent.splice(index, 1);
      return
    }

    _(this.subscribers)
      .filter(
        (s) =>
          (s.ev === event.action || s.ev == "all") && this.type === event.type
      )
      .forEach((s) => {
        try {
          s.callback(event);
        } catch (error) {
          console.error(error);
        }
      });
  }

  notifyAll(event: CollectionChangedEventArgs<TInfos, TDetails>) {
    this.notify(event);
    const id = uniqueId();
    this.sent.push(id);
    this.extensionCommunicationService.notify({...event, id});
  }


}

interface Subscriber<TInfos, TDetails> {
  id: number;
  ev: CollectionChangedEvent;
  callback: (arg: CollectionChangedEventArgs<TInfos, TDetails>) => void;
}
