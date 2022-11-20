import { createRouter, createWebHistory } from "vue-router";
// Custom views
import EmpleadosComp from "@/components/EmpleadosComp.vue";

const routes = [
    {
        path: "/",
        component: EmpleadosComp,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default router;
