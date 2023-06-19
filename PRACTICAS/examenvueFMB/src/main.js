import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";

import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import "bootstrap/dist/js/bootstrap.bundle";
import "bootstrap-vue/dist/bootstrap-vue";

const app = createApp(App);
app.use(router);

router.isReady().then(() => {
    app.mount("#app");
});