import { PermissionsManager, TranslationsManager } from "@/tools";
import _ from "lodash";
import Vue, { PluginFunction } from "vue"

class DativeLib {
    static install: PluginFunction<UserDativeLibOptions> = (vue) => {
        vue.prototype.$pm = PermissionsManager.instance;
        vue.prototype.$tm = TranslationsManager.instance;

        vue.prototype.$tr = (codeLabel: string, defaultLabel: string) => {
            return vue.prototype.$tm.get(codeLabel) ?? defaultLabel;
        };

        vue.prototype.$color = function(colorKey: string){
            return this.$vuetify.theme.currentTheme[colorKey]
        };

        vue.directive('right', {
            bind: function(el, binding, vm) {
                vue.prototype.$pm.addListener(vm);

                if (binding.value.constructor.name === "Array" && binding.value[0].constructor.name === "String") {
                    if (!vue.prototype.$pm.check(binding.value)) {
                        el.style.visibility = "hidden";
                    }
                }
            },
            unbind: function(_el, _unbinding, vm) {
                vue.prototype.$pm.removeListener(vm);
            },
            update: function(el, binding) {
                if (binding.value.constructor.name === "Array" && binding.value[0].constructor.name === "String") {
                    if (!vue.prototype.$pm.check(binding.value)) {
                        el.style.visibility = "hidden";
                    }
                    else {
                        el.style.visibility = 'visible';
                    }
                }
            }
        });
    }
}

export interface UserDativeLibOptions {
    noEmptyInterface: string; // todo: remove
}

Vue.use(DativeLib);

export default new DativeLib();
