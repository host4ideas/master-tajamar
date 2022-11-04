<template>
    <div>
        <h1 style="color: orange">Padre deportes V2</h1>
        <h2 v-if="data.favorito" style="color: green">
            Favorito 1: {{ data.favorito }}
        </h2>
        <h2 v-if="data.favorito2" style="color: green">
            Favorito 2: {{ data.favorito2 }}
        </h2>
        <h2 v-if="data.favorito3" style="color: green">
            Favorito 3: {{ data.favorito3 }}
        </h2>
        <ul>
            <li v-for="deporte in deportes" :key="deporte">
                <HijoDeporteV2
                    :deporte="deporte"
                    @response="seleccionarFavoritoParent1"
                />
                <HijoDeporteV2
                    :deporte="deporte"
                    @response="seleccionarFavoritoParent2"
                />
                <HijoDeporteV2
                    :deporte="deporte"
                    @response="
                        (nombre) => {
                            this.data.favorito3 = nombre;
                        }
                    "
                />
            </li>
        </ul>
    </div>
</template>

<script setup>
import HijoDeporteV2 from "./HijoDeporteV2.vue";
import { reactive } from "vue";

const deportes = ["Tenis", "Fútbol", "Golf", "Frontón"];

const data = reactive({
    favorito: null,
    favorito2: null,
    favorito3: null,
});

const seleccionarFavoritoParent1 = (nombre) => {
    data.favorito = nombre;
};
const seleccionarFavoritoParent2 = (nombre) => {
    data.favorito2 = nombre;
};
</script>
