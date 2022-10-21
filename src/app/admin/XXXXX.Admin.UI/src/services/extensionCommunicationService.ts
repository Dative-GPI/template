import { IExtensionCommunicationService } from "@/interfaces/iextensionCommunicationService";
import Ajv, { JTDParser, JTDSchemaType } from "ajv/dist/jtd";
import _ from "lodash";
import { injectable } from "tsyringe";

@injectable()
export class ExtensionCommunicationService
  implements IExtensionCommunicationService {
  title: string;
  height: number;
  ajv: Ajv;
  counter = 0;
  subscribers: Subscriber[] = [];
  unsafeSubscribers: UnsafeSubscriber[] = [];
  crumbs: any[] = [];

  constructor() {
    this.ajv = new Ajv();
    this.height = 0;
    this.title = "";
    window.addEventListener(
      "message",
      this.onMessageReceived.bind(this),
      false
    );
  }

  async goTo(path: string): Promise<void> {
    await this.notifyPath(path);
  }

  setTitle(title: string): void {
    // if (this.title != title) {
      this.title = title;
      this.notifyTitle();
    // }
  }
  
  setCrumbs(crumbs: any[]) {
    if (this.crumbs != crumbs) {
      this.crumbs = crumbs;
      this.notifyCrumbs();
    }
  }

  setHeight(height: number, path: string): void {
    if (this.height != height) {
      this.height = height;
      this.notifyHeight(path);
    }
  }

  setWidth(width: number, path: string): void {
    const payload = {
      width,
      path,
    };
    this.notify(payload);
  }

  openDialog(path: string): Promise<void> {
    throw new Error("Method not implemented.");
  }

  closeDialog(path: string): Promise<void> {
    throw new Error("Method not implemented.");
  }

  async openDrawer(path: string): Promise<void> {
    const payload = {
      path,
      drawer: true,
    };
    await this.notify(payload);
  }

  async closeDrawer(path: string, success: boolean = false): Promise<void> {
    const payload = {
      path,
      success,
      drawer: false,
    };
    await this.notify(payload);
  }

  notifyHeight = _.debounce((path) => {
    const payload = {
      height: this.height,
      path: path,
    };
    this.notify(payload);
  }, 50);

  notifyTitle = _.debounce(() => {
    const payload = {
      title: this.title,
    };
    this.notify(payload);
  }, 50);

  notifyCrumbs = _.debounce(() => {
    const payload = {
      crumbs: this.crumbs,
    };
    this.notify(payload);
  }, 50);

  notifyPath = _.debounce((path) => {
    const payload = {
      path: path,
    };
    this.notify(payload);
  }, 50);

  notify(payload: any) {
    if (window.top) {
      window.top.postMessage(JSON.stringify(payload), "*");
    }
  }

  subscribe<T>(
    schema: JTDSchemaType<T>,
    uri: string,
    callback: (payload: T) => void
  ): number {
    this.counter++;
    this.subscribers.push({
      parser: this.ajv.compileParser(schema),
      uri,
      callback,
      id: this.counter,
    });
    return this.counter;
  }

  subscribeUnsafe<T>(
    uri: string,
    callback: (payload: T) => void,
    valid: (payload: T) => boolean
  ): number {
    this.counter++;
    this.unsafeSubscribers.push({
      uri,
      callback,
      valid,
      id: this.counter,
    });
    return this.counter;
  }

  unsubscribe(id: number) {
    const index = _.findIndex(this.subscribers, (s) => s.id == id);
    if (index != -1) {
      this.subscribers.splice(index, 1);
    }
    const unsafeIndex = _.findIndex(this.unsafeSubscribers, (s) => s.id == id);
    if (unsafeIndex != -1) {
      this.unsafeSubscribers.splice(unsafeIndex, 1);
    }
  }

  onMessageReceived(event: MessageEvent) {
    try {
      JSON.parse(event.data);
    } catch (e) {
      return;
    }

    _(this.subscribers)
      // .filter((s) => new URL(event.origin).hostname == new URL(s.uri).hostname)
      .map((s) => ({
        callback: s.callback,
        url: new URL(s.uri),
        data: s.parser(event.data),
      }))
      .filter((s) => !!s.data)
      .forEach((s) => {
        try {
          s.callback(s.data);
        } catch (error) {
          console.log(error);
        }
      });

    _(this.unsafeSubscribers)
      .map((s) => ({
        callback: s.callback,
        url: new URL(s.uri),
        data: JSON.parse(event.data),
        valid: s.valid,
      }))
      .filter((s) => {
        return s.valid(s.data);
      })
      .forEach((s) => {
        try {
          s.callback(s.data);
        } catch (error) {
          console.log(error);
        }
      });
  }
}

interface Subscriber {
  parser: JTDParser;
  uri: string;
  callback: (payload: any) => void;
  id: number;
}

interface UnsafeSubscriber {
  uri: string;
  callback: (payload: any) => void;
  id: number;
  valid: (payload: any) => boolean;
}
