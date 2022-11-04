<template>
    <div>
        <h1 style="color: orange">Padre deportes</h1>
        <h2 v-if="favorito" style="color: green">Favorito 1: {{ favorito }}</h2>
        <h2 v-if="favorito2" style="color: green">Favorito 2: {{ favorito2 }}</h2>
        <h2 v-if="favorito3" style="color: green">Favorito 3: {{ favorito3 }}</h2>
        <li v-for="deporte in deportes" :key="deporte">
            <HijoDeportes
                :deporte="deporte"
                @response="seleccionarFavoritoParent1"
            />
            <HijoDeportes
                :deporte="deporte"
                @response="seleccionarFavoritoParent2"
            />
            <HijoDeportes
                :deporte="deporte"
                @response="
                    (nombre) => {
                        this.favorito3 = nombre;
                    }
                "
            />
        </li>
    </div>
</template>

<script>
import HijoDeportes from "./HijoDeportes.vue";

export default {
    name: "PadreDeportes",
    components: {
        HijoDeportes,
    },
    data() {
        return {
            deportes: ["Tenis", "Fútbol", "Golf", "Frontón"],
            favorito: null,
            favorito2: null,
            favorito3: null,
        };
    },
    methods: {
        seleccionarFavoritoParent1(nombre) {
            this.favorito = nombre;
        },
        seleccionarFavoritoParent2(nombre) {
            this.favorito2 = nombre;
        },
    },
};
</script>
