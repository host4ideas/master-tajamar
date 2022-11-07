import { createRouter, createWebHistory } from "vue-router";
// import PadreDeportes from "../components/deportes/PadreDeportes.vue";
import PadreDeportesV2 from "../components/deportes/PadreDeportesV2.vue";
// import PadreNumeros from "../components/numeros/PadreNumeros.vue";
import PadreNumerosV2 from "../components/numeros/PadreNumerosV2.vue";
import PadreComic from "../components/comics/PadreComic.vue";
// import PadreComicsV2 from "../components/numeros/PadreComicsV2.vue";
import HomeComponentMultipleMsg from "@/components/HomeComponentMultipleMsg.vue";
import HomeComponent from "@/components/HomeComponent.vue";
import NotFoundPage from "@/components/NotFoundPage.vue";
import NumeroDoble from "@/components/params/NumeroDoble.vue";
import NumeroDobleWatch from "@/components/params/NumeroDobleWatch.vue";

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
    {
        path: "/home/:msg?",
        component: HomeComponent,
    },
    {
        path: "/home-multiple-msg/:msg*",
        component: HomeComponentMultipleMsg,
    },
    {
        path: "/num-doble/:num?",
        component: NumeroDoble,
    },
    {
        path: "/num-doble-watch/:num?",
        component: NumeroDobleWatch,
    },
    {
        path: "/:pathMatch(.*)*",
        component: NotFoundPage,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default router;
