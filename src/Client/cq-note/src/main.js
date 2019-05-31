import Vue from "vue";
import axios from "axios";
import ElementUI from "element-ui";
import "element-ui/lib/theme-chalk/index.css";
import "./assets/common.css";
import mavonEditor from "mavon-editor";
import "mavon-editor/dist/css/index.css";
import App from "./App.vue";
import store from "./store";

axios.defaults.baseURL = "https://localhost:5001";

Vue.use(ElementUI);
Vue.use(mavonEditor);
Vue.config.productionTip = false;
Vue.prototype.$http = axios;

new Vue({
  store,
  render: h => h(App)
}).$mount("#app");
