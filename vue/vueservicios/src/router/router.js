import { createRouter, createWebHistory } from "vue-router";
// Custom views
import HomePageVue from "@/views/HomePage.vue";
import CochesPageVue from "@/views/CochesPage.vue";
import EmpleadosDetalle from "@/views/EmpleadosDetalle.vue";
import EmpleadosOficio from "@/views/EmpleadosOficio.vue";

const routes = [
    {
        path: "/",
        component: HomePageVue,
    },
    {
        path: "/coches",
        component: CochesPageVue,
    },
    {
        path: "/empleados",
        component: EmpleadosDetalle,
    },
    {
        path: "/empleados-oficio/:oficio",
        component: EmpleadosOficio,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default router;
