import { createRouter, createWebHistory } from "vue-router";
// import PadreDeportes from "../components/deportes/PadreDeportes.vue";
import PadreDeportesV2 from "../components/deportes/PadreDeportesV2.vue";
// import PadreNumeros from "../components/numeros/PadreNumeros.vue";
import PadreNumerosV2 from "../components/numeros/PadreNumerosV2.vue";
import PadreComic from "../components/comics/PadreComic.vue";
// import PadreComicsV2 from "../components/numeros/PadreComicsV2.vue";

const routes = [
    {
        path: "/",
        redirect: "/numeros",
    },
    {
        path: "/deportes",
        component: PadreDeportesV2,
    },
    {
        path: "/numeros",
        component: PadreNumerosV2,
    },
    {
        path: "/comics",
        component: PadreComic,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default router;
