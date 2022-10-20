import Vue from 'vue';
import { PermissionsManager, TranslationsManager } from './tools';

declare module 'vue/types/vue' {
    interface Vue {
        $tr: (codeLabel: string, defaultLabel: string) => string;
        $color: (colorKey: string) => string;
        $pm: PermissionsManager;
        $tm: TranslationsManager;
    }
}