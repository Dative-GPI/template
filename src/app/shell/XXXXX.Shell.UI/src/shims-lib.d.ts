import Vue from 'vue';

declare module 'vue/types/vue' {
    interface Vue {
        $tr: (codeLabel: string, defaultLabel: string) => string;
        $color: (colorKey: string) => string;
    }
}