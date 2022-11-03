import { createRouter, createWebHistory } from "vue-router";
import TablaMultiplicarPage from "./views/TablaMultiplicarPage.vue";
import TablaMultiplicarFiltersPage from "./views/TablaMultiplicarFiltersPage.vue";
import HomePage from "./views/HomePage.vue";

const routes = [
    {
        path: "/",
        component: HomePage,
    },
    {
        path: "/tabla-multiplicar",
        component: TablaMultiplicarPage,
    },
    {
        path: "/tabla-multiplicar-filters",
        component: TablaMultiplicarFiltersPage,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default router;
