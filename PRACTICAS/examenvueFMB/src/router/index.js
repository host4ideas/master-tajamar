import { createRouter, createWebHistory } from "vue-router";
// Custom views
import HomeComponentVue from "@/components/HomeComponent.vue";
import PerfilComponent from "@/components/PerfilComponent.vue";
import ComprasUsuarioComponent from "@/components/ComprasUsuario.vue";
import CubosMarcaComponent from "@/components/CubosMarca.vue";
import CubosDetallesComponent from "@/components/CubosDetalles.vue";
import LoginComponent from "@/components/LoginComponent.vue";
import RegisterComponent from "@/components/RegisterComponent.vue";

const routes = [
    {
        path: "/",
        component: HomeComponentVue,
    },
    {
        path: "/perfil",
        component: PerfilComponent,
    },
    {
        path: "/compras-usuario",
        component: ComprasUsuarioComponent,
    },
    {
        path: "/cubos-marca/:marca",
        component: CubosMarcaComponent,
    },
    {
        path: "/cubos-detalles/:idcubo",
        component: CubosDetallesComponent,
    },
    {
        path: "/login",
        component: LoginComponent,
    },
    {
        path: "/register",
        component: RegisterComponent,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default router;
