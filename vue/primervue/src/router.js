import { createRouter, createWebHistory } from "vue-router";
import HomeComponentVue from "./components/HomeComponent.vue";
import CineComponentVue from "./components/CineComponent.vue";
import MusicaComponentVue from "./components/MusicaComponent.vue";
import HelloWorldVue from "./components/HelloWorld.vue";

const routes = [
    {
        path: "/",
        component: HomeComponentVue,
    },
    {
        path: "/cine",
        component: CineComponentVue,
    },
    {
        path: "/musica",
        component: MusicaComponentVue,
    },
    {
        path: "/:pathMatch(.*)*",
        component: <HelloWorldVue msg="No deberias de estar aqui..." />,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
