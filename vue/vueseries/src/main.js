import { createApp } from "vue";
import App from "./App.vue";
import router from "./router/router";
import VueSweetalert2 from "vue-sweetalert2";
import "sweetalert2/dist/sweetalert2.min.css";

// Import Bootstrap and BootstrapVue CSS files (order is important)
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import "bootstrap/dist/js/bootstrap.bundle";
import "bootstrap-vue/dist/bootstrap-vue";

const app = createApp(App);

app.use(VueSweetalert2);
app.use(router);

router.isReady().then(() => {
    app.mount("#app");
});
