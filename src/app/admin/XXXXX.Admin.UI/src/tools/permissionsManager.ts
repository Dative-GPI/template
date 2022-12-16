import { VNode } from "vue";

export class PermissionsManager {
  private static _instance: PermissionsManager;

  public static get instance(): PermissionsManager {
    return this._instance || (this._instance = new this());
  }

  private listeners: VNode[];

  public permissions: string[];


  private constructor() {
    this.listeners = [];
    this.permissions = [];
  }


  public addListener(listener: VNode): void {
    this.listeners.push(listener);
  }

  public removeListener(listener: VNode): void {
    this.listeners = this.listeners.filter(l => l != listener);
  }

  public set(permissions: string[]): void {
    this.permissions = permissions.slice();

    this.listeners.forEach(vue => {
      vue.context?.$forceUpdate();
    });
  }

  public check(codes: string[]): boolean {
    for (var code of codes) {
      if (!this.permissions.includes(code)) {
        return false;
      }
    }
    return true;
  }
}