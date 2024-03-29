import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';
import fr from 'vuetify/src/locale/fr';
 
import '@mdi/font/css/materialdesignicons.css';
 
import { Icons } from "@dative-gpi/shards/src/icons";
 
Vue.use(Vuetify);
 
export default new Vuetify({
  icons: {
    iconfont: 'mdi',
    values: Icons,
  },
  theme: {
    options: {
      customProperties: true,
    },
    themes: {
      light: {
        "primary":     '#8EB0B9',
        "white-1":     '#FFFFFF',
        "white-2":     '#F8F8F8',
        "grey-1":      '#D7D7D7',
        "grey-2":      '#989898',
        "grey-3":      '#606060',
        "gray-2":      '#4F4F4F',
        "grey-drawer": '#4F4F4F',
        "black-1":     '#2C2C2C',
        "black-2":     '#000000',
        "blue-1":      '#00B4DC',
        "blue-2":      '#8EB0B9',
        "blue-3":      '#5099AB',
        "blue-4":      '#BEECF7',
        "blue-5":      '#091113',
        "blue-6":      '#87CFE5', 
        "blue-border": '#D6E0E3',
        "green-1":     '#52DD60',
        "red-1":       '#FDDFD8',        
        "red-2":       '#B9968E',
        "red-3":       '#AB6150',
        "red-4":       '#F8937C',
        "alert-red":               '#DA2D2D',
        "alert-red-background":    '#FFBABA',
        "alert-grey":              '#989898',
        "alert-grey-background":   '#F5F5F5',
        "alert-orange":            '#F08303',
        "alert-orange-background": '#FADAB3',
        "alert-blue":              '#1E56E5',
        "alert-blue-background":   '#D2DDFA',
        "alert-green":             '#03AC00',
        "alert-green-background":  '#C5E8C4',
        "page-information-background":   '#DFF6FB',
      },
    },
  },
  lang: {
    locales: { fr },
    current: 'fr',
  },
});