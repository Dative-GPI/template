import _ from "lodash";
import Vue, { PluginFunction } from "vue"

class DativeLib {
    static install: PluginFunction<UserDativeLibOptions> = (vue) => {

        vue.prototype.$tr = (codeLabel: string, defaultLabel: string) => defaultLabel;

        vue.prototype.$color = function(colorKey: string){
            return this.$vuetify.theme.currentTheme[colorKey]
        };

        vue.directive('right', {
            inserted: function(el, binding) {
                const userRights: string[] = ["rights.device.delete"];

                if (typeof binding.value !== "string" || !userRights.includes(binding.value)) {
                    if (el.parentNode) {
                        const parent = el.parentNode;
                        parent.removeChild(el);
                    }
                }
            }
        })
    }
}

export interface UserDativeLibOptions {
    noEMptyInterface: string; // todo: remove
}

Vue.use(DativeLib);

export default new DativeLib();
