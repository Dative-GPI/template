import { JTDSchemaType } from "ajv/dist/core"

export interface IExtensionCommunicationService {
    goTo(path: string): Promise<void>
    setTitle(title: string): void
    setCrumbs(crumbs: any[]): void
    setHeight(height: number, path: string): void
    setWidth(width: number, path: string): void
    openDialog(path: string): Promise<void>
    closeDialog(path: string): Promise<void>
    openDrawer(path: string): Promise<void>
    closeDrawer(path: string, success: boolean): Promise<void>
    subscribe<T>(schema: JTDSchemaType<T>, uri: string, callback: (payload: T) => void): number
    subscribeUnsafe<T>(uri: string, callback: (payload: T) => void,  valid: (payload: T) => boolean): number
    unsubscribe(id: number): void
    notify(payload: any): void
}