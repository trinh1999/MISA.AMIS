import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
// import https from 'https';
import VueAxios from 'vue-axios'
import { FormRadioPlugin } from 'bootstrap-vue'

Vue.use(FormRadioPlugin)
export const eventBus = new Vue();

Vue.use(VueAxios, axios)
Vue.config.productionTip = false



new Vue({
  render: h => h(App),
}).$mount('#app')

