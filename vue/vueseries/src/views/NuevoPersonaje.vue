<template>
    <div>
        <h1>Nuevo personaje</h1>
        <form @submit.prevent="handleSubmit" class="m-3">
            <div class="mb-3">
                <label for="inputNombre" class="form-label">Nombre</label>
                <input
                    type="text"
                    class="form-control"
                    id="inputNombre"
                    v-model="data.nombre"
                />
            </div>
            <div class="mb-3">
                <label for="inputImagen" class="form-label">Imagen</label>
                <input
                    type="text"
                    class="form-control"
                    id="inputImagen"
                    v-model="data.imagen"
                />
            </div>
            <div class="mb-3">
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
            <button type="submit" class="btn btn-primary">Submit</button>
        </form>
    </div>
</template>

<script setup>
import { reactive, inject, onMounted } from "vue";
import seriesService from "../services/SeriesService";
import Swal from "sweetalert2";

const { series, updateSeries } = inject("series");

const data = reactive({
    series: [],
    imagen: null,
    nombre: null,
    serieSelected: null,
});

const handleSubmit = () => {
    if (data.serieSelected && data.imagen && data.nombre) {
        Swal.fire({
            title: "¿Estás seguro de que quieres crear el personaje?",
            showDenyButton: true,
            confirmButtonText: "Crear",
            denyButtonText: `Cancelar`,
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                const nuevoPersonaje = {
                    nombre: data.nombre,
                    imagen: data.imagen,
                    idSerie: data.serieSelected,
                };

                seriesService.createPersonaje(nuevoPersonaje).then(() => {
                    Swal.fire({
                        position: "center",
                        icon: "success",
                        title: "Your work has been saved",
                        showConfirmButton: false,
                        timer: 1500,
                    });
                });
            } else if (result.isDenied) {
                Swal.fire("Personaje no creado", "", "info");
            }
        });
    }
};

onMounted(() => {
    updateSeries().then(() => {
        data.series = series;
    });
});
</script>
