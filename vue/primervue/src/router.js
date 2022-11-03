import { createRouter, createWebHistory } from "vue-router";
import HomePage from "./views/HomePage.vue";
import CinePage from "./views/CinePage.vue";
import MusicaPage from "./views/MusicaPage.vue";
import NotFoundPage from "./views/NotFoundPage.vue";
import CicloVidaPage from "./components/CicloVidaPage.vue";
import DirectivasPage from "./views/DirectivasPage.vue";
import ConmutadaPage from "./views/ConmutadaPage.vue";
import FiltersPage from "./views/FiltersPage.vue";

const routes = [
    {
        path: "/",
        component: HomePage,
    },
    {
        path: "/cine",
        component: CinePage,
    },
    {
        path: "/musica",
        component: MusicaPage,
    },
    {
        path: "/ciclo-vida",
        component: CicloVidaPage,
    },
    {
        path: "/directivas",
        component: DirectivasPage,
    },
    {
        path: "/propiedad-conmutada",
        component: ConmutadaPage,
    },
    {
        path: "/filters",
        component: FiltersPage,
    },
    {
        path: "/:pathMatch(.*)*",
        component: <NotFoundPage msg="No deberias de estar aqui..." />,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
