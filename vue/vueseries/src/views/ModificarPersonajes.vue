<template>
    <div>
        <h1>Modificar personajes</h1>
        <form class="row g-3" @submit.prevent="handleSubmit">
            <div class="col-auto">
                <label for="selectSerie" class="col-form-label">
                    Selecciona una serie
                </label>
                <select
                    class="form-select"
                    aria-label="Default select example"
                    id="selectSerie"
                    v-model="data.serieSelected"
                >
                    <option
                        v-for="serie in data.series"
                        :key="serie"
                        :value="serie.idSerie"
                    >
                        {{ serie.nombre }}
                    </option>
                </select>
            </div>
            <div class="col-auto">
                <label for="selectPersonaje" class="col-form-label">
                    Selecciona un personaje
                </label>
                <select
                    class="form-select"
                    aria-label="Default select example"
                    id="selectPersonaje"
                    v-model="data.personajeSelected"
                >
                    <option
                        v-for="personaje in data.personajes"
                        :key="personaje"
                        :value="personaje.idPersonaje"
                    >
                        {{ personaje.nombre }}
                    </option>
                </select>
            </div>
            <div class="col-auto">
                <button type="submit" class="btn btn-primary mb-3">
                    Cambiar de serie
                </button>
            </div>
        </form>
    </div>
</template>

<script setup>
import { reactive, inject, onMounted, watchEffect } from "vue";
import { useRoute } from "vue-router";
import seriesService from "../services/SeriesService";
import Swal from "sweetalert2";

const route = useRoute();

const { personajes, updatePersonajes } = inject("personajes");
const { series, updateSeries } = inject("series");

const data = reactive({
    personajes: [],
    series: [],
    personajeSelected: null,
    serieSelected: null,
});

const handleSubmit = () => {
    if (data.serieSelected && data.personajeSelected) {
        Swal.fire({
            title: "¿Estás seguro de que quieres modificar la serie del personaje?",
            showDenyButton: true,
            confirmButtonText: "Cambiar",
            denyButtonText: `Cancelar`,
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                seriesService
                    .changePersonajeSerie(
                        data.personajeSelected,
                        data.serieSelected
                    )
                    .then(() => {
                        Swal.fire({
                            position: "top-end",
                            icon: "success",
                            title: "Your work has been saved",
                            showConfirmButton: false,
                            timer: 1500,
                        });
                    });
            } else if (result.isDenied) {
                Swal.fire("Personaje no modificado", "", "info");
            }
        });
    }
};

onMounted(() => {
    if (route.params?.idPersonaje) {
        const selectPersonaje = document.getElementById("selectPersonaje");
        selectPersonaje.disabled = true;
        data.personajeSelected = route.params.idPersonaje;
    }
    updatePersonajes().then(() => {
        data.personajes = personajes;
    });
    updateSeries().then(() => {
        data.series = series;
    });
});

watchEffect(() => {
    const selectPersonaje = document.getElementById("selectPersonaje");
    if (route.params?.idPersonaje) {
        if (selectPersonaje) {
            selectPersonaje.disabled = true;
            data.personajeSelected = route.params.idPersonaje;
        }
    } else {
        selectPersonaje.disabled = false;
        data.personajeSelected = undefined;
    }
});
</script>
