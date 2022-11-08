import { createRouter, createWebHistory } from "vue-router";
import HomePage from "@/views/HomePage";
import DepartamentoPage from "@/views/DepartamentoPage.vue";
import UpdateDepartamento from "@/views/UpdateDepartamento.vue";
import CreateDepartamento from "@/views/CreateDepartamento.vue";

const routes = [
    {
        path: "/",
        component: HomePage,
    },
    {
        path: "/departamento/:numero",
        component: DepartamentoPage,
    },
    {
        path: "/modificar-departamento/:numero",
        component: UpdateDepartamento,
    },
    {
        path: "/crear-departamento",
        component: CreateDepartamento,
    },
];

const router = createRouter({
    routes: routes,
    history: createWebHistory(),
});

export default router;
