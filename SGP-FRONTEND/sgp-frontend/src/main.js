import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";
import Toastification from "vue-toastification";
import "vue-toastification/dist/index.css";
// Import Bootstrap and BootstrapVue CSS files (order is important)
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

// Make BootstrapVue available throughout your project
Vue.use(BootstrapVue);
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin);
Vue.config.productionTip = false;
Vue.use(Toastification, {
  transition: "Vue-Toastification__fade",
  maxToasts: 1,
  newestOnTop: true,
});
new Vue({
  router,
  store,
  render: function (h) {
    return h(App);
  },
}).$mount("#app");
