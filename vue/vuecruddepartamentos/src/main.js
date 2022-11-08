import { createApp } from "vue";
import App from "./App.vue";
import router from "./router/router";

// Import Bootstrap and BootstrapVue CSS files (order is important)
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import "bootstrap/dist/js/bootstrap.bundle";
import "bootstrap-vue/dist/bootstrap-vue";
import "bootstrap-icons/font/bootstrap-icons.css";

const app = createApp(App);

app.use(router);

router.isReady().then(() => {
    app.mount("#app");
});
