import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";

const app = createApp(App);

app.use(router);

app.config.globalProperties.$filters = {
    getMultiplicacion(num1, num2) {
        return num1 * num2;
    },
};

router.isReady().then(() => {
    app.mount("#app");
});
