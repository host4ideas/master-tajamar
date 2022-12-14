import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";

const app = createApp(App).use(router);

app.config.globalProperties.$filters = {
    mayusculas(value) {
        return value.toUpperCase();
    },
};

app.config.globalProperties.$variables = {
    nombre: "pepe",
};

router.isReady().then(() => {
    app.mount("#app");
});
