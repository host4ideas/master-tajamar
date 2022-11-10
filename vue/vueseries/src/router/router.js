import { createRouter, createWebHistory } from "vue-router";
import HomePage from "@/views/HomePage.vue";
import NuevoPersonaje from "@/views/NuevoPersonaje.vue";
import ModificarPersonajes from "@/views/ModificarPersonajes.vue";
import SerieDetails from "@/views/SerieDetails.vue";
import PersonajesSerie from "@/views/PersonajesSerie.vue";

const routes = [
    {
        path: "/",
        component: HomePage,
    },
    {
        path: "/nuevo-personaje",
        component: NuevoPersonaje,
    },
    {
        path: "/modificar-personajes/:idPersonaje?",
        component: ModificarPersonajes,
    },
    {
        path: "/serie/:serieId",
        component: SerieDetails,
    },
    {
        path: "/personajes/:serieId",
        component: PersonajesSerie,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default router;
